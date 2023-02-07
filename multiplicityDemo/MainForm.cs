using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multiplicityDemo
{
    public partial class MainForm : Form
    {
        Bitmap workingBitmap;
        TurtleSharp turtle;
        public MainForm()
        {
            InitializeComponent();
            workingBitmap = new Bitmap((int)sizeXNumericUpDown.Value, (int)sizeYNumericUpDown.Value);
            turtle = new TurtleSharp(workingBitmap);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (typeComboBox.Text == "Koch curve")
            {
                Koch();
            }
            if (typeComboBox.Text == "Koch triangle right")
                {
                Koch("right");
            }

            if (typeComboBox.Text == "Koch triangle left")
            {
                Koch("left");
            }
        }

        private void Koch(string type = "")
        {
            workingBitmap = new Bitmap((int)sizeXNumericUpDown.Value, (int)sizeYNumericUpDown.Value);
            turtle = new TurtleSharp(workingBitmap);
            turtle.magnification = (double) magnNumericUpDown.Value;
            turtle.MoveToPoint((double)startXnumericUpDown.Value, (double) startYnumericUpDown.Value);
            turtle.PenDown();
            int line = (int)lineLenghtNumericUpDown.Value;
            if (type == "")
            {
                KochSegment(line);
            }
            else if (type == "right")
            {
                KochSegment(line);
                turtle.right(120);
                KochSegment(line);
                turtle.right(120);
                KochSegment(line);
            }
            else if (type == "left")
            {
                KochSegment(line);
                turtle.left(120);
                KochSegment(line);
                turtle.left(120);
                KochSegment(line);
            }
            Turtle_LineIsDone();
        }
        private void KochSegment (int line)
        {
            if (line > 6)
            {
                int newline = line / 3;
                KochSegment(newline);
                turtle.left(60);
                KochSegment(newline);
                turtle.right(120);
                KochSegment(newline);
                turtle.left(60);
                KochSegment(newline);
            }
            else
            {
                turtle.fd(line);
                turtle.left(60);
                turtle.fd(line);
                turtle.right(120);
                turtle.fd(line);
                turtle.left(60);
                turtle.fd(line);
            }
        }

        private void Turtle_LineIsDone()
        {
            workingBitmap = turtle.GetResult();
            pictureBox.Image = workingBitmap;
        }

        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}
