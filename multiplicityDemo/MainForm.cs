using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multiplicityDemo
{
    public partial class MainForm : Form
    {
        Bitmap workingBitmap;
        TurtleSharp turtle;
        LSystem2D l_sys;
        public MainForm()
        {
            InitializeComponent();
            workingBitmap = new Bitmap((int)sizeXNumericUpDown.Value, (int)sizeYNumericUpDown.Value);
            turtle = new TurtleSharp(workingBitmap);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Xsize = sizeXNumericUpDown.Value;
            Properties.Settings.Default.Ysize = sizeYNumericUpDown.Value;
            Properties.Settings.Default.Xstart = startXnumericUpDown.Value;
            Properties.Settings.Default.Ystart = startYnumericUpDown.Value;
            Properties.Settings.Default.LineLenght = lineLenghtNumericUpDown.Value;
            Properties.Settings.Default.Speed = speedNumericUpDown.Value;
            Properties.Settings.Default.Steps = stepsNumericUpDown.Value;
            Properties.Settings.Default.LSysAngle = LsysAngelNumericUpDown.Value;
            Properties.Settings.Default.LsysAxioma = LsysAxiomtextBox.Text;
            Properties.Settings.Default.Save();

            workingBitmap = new Bitmap((int)sizeXNumericUpDown.Value, (int)sizeYNumericUpDown.Value);
            pictureBox.Image = workingBitmap;
            turtle = new TurtleSharp(workingBitmap);
            turtle.LineIsDone += Turtle_LineIsDone;
            turtle.magnification = (double)magnNumericUpDown.Value;
            turtle.speed((int)speedNumericUpDown.Value);
            turtle.MoveToPoint((double)startXnumericUpDown.Value, (double)startYnumericUpDown.Value);
            turtle.Down();

            Thread trd = new Thread(Threader);


            if (typeComboBox.Text == "Koch curve")
            {
                trd.Start();
                //Koch();
            }
            if (typeComboBox.Text == "Koch triangle right")
            {
                trd.Start("right");
                //Koch("right");
            }

            if (typeComboBox.Text == "Koch triangle left")
            {
                trd.Start("left");
                //Koch("left");
            }
            if (typeComboBox.Text == "Koch L-sys")
            {
                trd.Start("l-sys");
            }

        }

        private void Threader(object objtype)
        {
            string type = "";
            if (objtype != null) type = objtype.ToString();
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
            else if (type == "l-sys")
            {
                string axioma = LsysAxiomtextBox.Text;
                double angle = (double)LsysAngelNumericUpDown.Value;
                l_sys = new LSystem2D(turtle, axioma, 1, (int)lineLenghtNumericUpDown.Value, angle);
                //l_sys.add_rules(("F", "F+F--F+F"));
                //l_sys.add_rules(("F", "F+FF-FF-F-F+F+FF-F-F+F+FF+FF-F"));
                //l_sys.add_rules(("F", "F+S-FF+F+FF+FS+FF-S+FF-F-FF-FS-FFF"),("S","SSSSSS"));
                //l_sys.add_rules(("FX", "FX+FY+"), ("FY", "-FX-FY")); // dragon
                l_sys.add_rules(("F", "FF"), ("X", "--FXF++FXF++FXF--"));//serpinsky
                //l_sys.add_rules(("X","-YF+XFX+FY-"),("Y","+XF-YFY-FX+"));//gilbert
                l_sys.gen_path((int)stepsNumericUpDown.Value);
                l_sys.draw_turtle((int)startXnumericUpDown.Value, (int)startYnumericUpDown.Value, 0);
            }
            Turtle_LineIsDone();
        }
        private void KochSegment(int line)
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
            if (pictureBox.InvokeRequired)
            {
                pictureBox.Invoke((MethodInvoker)delegate
               {
                   workingBitmap = turtle.GetResult();
                   pictureBox.Image = workingBitmap;
                   pictureBox.Refresh();
               });
            }
            else
            {
                workingBitmap = turtle.GetResult();
                pictureBox.Image = workingBitmap;
                pictureBox.Refresh();
            }
        }

        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void typeComboBox_TextChanged(object sender, EventArgs e)
        {
            if (typeComboBox.Text == "Koch L-sys")
            {
                Lsyspanel.Enabled = true;
                tabControl.SelectTab(L_sys_Tab);
            }
            else
            {
                Lsyspanel.Enabled = false;
            }
        }
    }
}
