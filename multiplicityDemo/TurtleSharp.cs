using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multiplicityDemo
{
    class TurtleSharp
    {
        private int X_turtle = 0; // current X coordinate
        private int Y_turtle = 0; // current Y coordinate
        private double A_turtle_degrees = 0; // Angle to move in degrees
        private double A_turtle_radians = 0; // Angle to move in radians

        private double X_endpoint = 0; // X coordinate endpoint for drawing
        private double Y_endpoint = 0; // Y coordinate endpoint for drawing

        Bitmap bitmapOut = null;
        Pen drawingPen = new Pen(Color.Black, 1);

        bool isPenDown = false;

        public delegate void IsDone();

        public event IsDone LineIsDone;

        public double magnification = 1;
        public TurtleSharp(Bitmap example)
        {
            bitmapOut = example;
        }

        private double DegreesToRadians(double Degrees)
        {
            return ((Degrees * Math.PI) / 180);
        }

        public Bitmap GetResult()
        {
            return bitmapOut;
        }

        public void fd(int points)
        {
            A_turtle_radians = DegreesToRadians(A_turtle_degrees);
            X_endpoint += ((double)points * Math.Cos(A_turtle_radians) * magnification);
            Y_endpoint += ((double)points * Math.Sin(A_turtle_radians) * magnification);
            DrawLine();
        }

        public void forward(int points)
        {
            fd(points);
        }

        public void right(double degrees)
        {
            A_turtle_degrees += degrees;
            if (A_turtle_degrees > 360) degrees -= 360;
            A_turtle_radians = DegreesToRadians(A_turtle_degrees);
        }

        public void left(double degrees)
        {
            A_turtle_degrees -= degrees;
            if (A_turtle_degrees < -360) degrees += 360;
            A_turtle_radians = DegreesToRadians(A_turtle_degrees);
        }

        public void MoveToPoint(double x, double y)
        {
            X_endpoint = x;
            Y_endpoint = y;
            DrawLine();
        }

        public void MoveToCenter()
        {
            X_endpoint = bitmapOut.Width / 2;
            Y_endpoint = bitmapOut.Height / 2;
            DrawLine();
        }

        public void MoveToVerticalCenter()
        {
            Y_endpoint = bitmapOut.Height / 2;
            DrawLine();
        }

        public void MoveToDown()
        {
            Y_endpoint = bitmapOut.Height-1;
            DrawLine();
        }

        public void PenUp()
        {
            isPenDown = false;
        }

        public void PenDown()
        {
            isPenDown = true;
        }

        private void DrawLine()
        {
            if (isPenDown)
            {
                using (var graphics = Graphics.FromImage(bitmapOut))
                {
                    graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    graphics.DrawLine(drawingPen, X_turtle, Y_turtle, (int)X_endpoint, (int)Y_endpoint);
                }
            }
            X_turtle = (int)X_endpoint;
            Y_turtle = (int)Y_endpoint;
            if (LineIsDone!=null) LineIsDone();
        }
    }
}
