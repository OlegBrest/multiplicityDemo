using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace multiplicityDemo
{
    public partial class MainForm : Form
    {
        Bitmap workingBitmap;
        TurtleSharp turtle;
        LSystem2D l_sys;
        bool isAutoStarted = false;
        bool isdrawingComlete = true;
        long progressValue = 0;

        private Point mousePos1;
        private Point mousePos2;

        decimal minXJuliaMandel = 0;
        decimal maxXJuliaMandel = 0;
        decimal minYJuliaMandel = 0;
        decimal maxYJuliaMandel = 0;


        public MainForm()
        {
            InitializeComponent();
            workingBitmap = new Bitmap((int)sizeXNumericUpDown.Value, (int)sizeYNumericUpDown.Value);
            turtle = new TurtleSharp(workingBitmap);
            //Complex c = new Complex((double)realNumericUpDown.Value, (double)imaginaryNumericUpDown.Value);
            DecimalComplex c = new DecimalComplex(realNumericUpDown.Value, imaginaryNumericUpDown.Value);
            comlexModuleLabel.Text = "Complexmodule =" + c.Magnitude.ToString();
            progressBar.Value = 0;
        }

        private void startButton_Click(object sender = null, EventArgs e = null)
        {
            if (isdrawingComlete)
            {
                isdrawingComlete = false;
                startButton.Enabled = false;
                if (!isAutoStarted)
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
                    Properties.Settings.Default.MuliType = typeComboBox.Text;
                    Properties.Settings.Default.RealJylia = realNumericUpDown.Value;
                    Properties.Settings.Default.ImagJulia = imaginaryNumericUpDown.Value;
                    Properties.Settings.Default.AutoStart = autoStartCheckBox.Checked;
                    Properties.Settings.Default.SelectedTab = tabControl.SelectedIndex;
                    Properties.Settings.Default.Save();
                }
                //pictureBox.Image = null;
                workingBitmap = new Bitmap((int)sizeXNumericUpDown.Value, (int)sizeYNumericUpDown.Value);
                //pictureBox.Image = workingBitmap;
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
                if (typeComboBox.Text == "Julia")
                {
                    trd.Start("Julia");
                }
                if (typeComboBox.Text == "Mandel")
                {
                    trd.Start("Mandel");
                }
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
            else if (type == "Julia" || type == "Mandel")
            {
                int iters = 100;
                minXJuliaMandel = xMinNumericUpDown.Value;
                maxXJuliaMandel = xMaxNumericUpDown.Value;
                minYJuliaMandel = yMinNumericUpDown.Value;
                maxYJuliaMandel = yMaxNumericUpDown.Value;

                decimal xLenght = maxXJuliaMandel - minXJuliaMandel;
                decimal yLenght = maxYJuliaMandel - minYJuliaMandel;

                int xPicMax = (int)sizeXNumericUpDown.Value;
                int yPicMax = (int)sizeYNumericUpDown.Value;

                long progressMax = xPicMax * yPicMax;
                long progressCurrent = 0;

                decimal pic2XMult = (decimal)xPicMax / xLenght;
                decimal pic2YMult = (decimal)yPicMax / yLenght;

                decimal middleX = (minXJuliaMandel + maxXJuliaMandel) / 2;
                decimal middleY = (minYJuliaMandel + maxYJuliaMandel) / 2;

                BigInteger picCenterX = ((BigInteger)xPicMax / 2 - (BigInteger)(middleX * pic2XMult));
                BigInteger picCenterY = ((BigInteger)yPicMax / 2 - (BigInteger)(middleY * pic2YMult));

                //Complex z = new Complex();
                //Complex c = new Complex(-0.2, 0.75); 
                //Complex c = new Complex();
                DecimalComplex z = new DecimalComplex();
                DecimalComplex c = new DecimalComplex();

                //if (type == "Julia") c = new Complex((double)realNumericUpDown.Value, (double)imaginaryNumericUpDown.Value);
                if (type == "Julia") c = new DecimalComplex(realNumericUpDown.Value, imaginaryNumericUpDown.Value);
                
                Pen drawingPen = new Pen(Color.Black, 1);

                byte[] pictArray = ImageWrapper.ImageToArray(workingBitmap, yPicMax, xPicMax);

                for (long picY = 0; picY < yPicMax; picY++)
                //Parallel.For(0, yPicMax, picY =>
                {
                    //for (int picX = 0; picX < xPicMax; picX++)
                    Parallel.For(0, xPicMax, picX =>
                    {
                        lock (pictArray)
                        {
                            decimal decX = ((decimal)(picX - picCenterX)) / pic2XMult;
                            decimal decY = ((decimal)(picY - picCenterY)) / pic2YMult;
                            if (type == "Julia")
                            {
                                //z = new Complex((double)decX, (double)decY);
                                z= new DecimalComplex(decX, decY);
                            }
                            if (type == "Mandel")
                            {
                                z = new DecimalComplex(0, 0);
                                c = new DecimalComplex(decX, decY);
                            }
                            int n = 0;
                            for (n = 0; n <= iters; n++)
                            {
                                z = z * z + c; // formula for drawing default (z * z + c)
                                if (z.Magnitude > 2)
                                {
                                    break;
                                }
                            }
                            if (n >= (iters - 1))
                            {
                                byte medclr = 0; //(int)( 255 - (255 * z.Magnitude / 2));
                                                 //Color clr = Color.FromArgb(255, medclr, medclr, medclr);
                                                 //workingBitmap.SetPixel(picX, picY, clr);
                                pictArray[0 + picY * xPicMax * 3 + picX * 3] = medclr;
                                pictArray[1 + picY * xPicMax * 3 + picX * 3] = medclr;
                                pictArray[2 + picY * xPicMax * 3 + picX * 3] = medclr;
                            }
                            else
                            {
                                byte r = (byte)(255 - n % 18 * 12);
                                byte g = (byte)(255 - n % 13 * 16);
                                byte b = (byte)(255 - n % 7 * 33);
                                if (r < 0) r = 0;
                                if (g < 0) g = 0;
                                if (b < 0) b = 0;
                                /*Color clr = Color.FromArgb(255, r, g, b);
                                workingBitmap.SetPixel(picX, picY, clr);*/
                                pictArray[0 + picY * xPicMax * 3 + picX * 3] = b;
                                pictArray[1 + picY * xPicMax * 3 + picX * 3] = g;
                                pictArray[2 + picY * xPicMax * 3 + picX * 3] = r;
                            }
                            long prevProgres = progressValue;
                            progressCurrent += 100;
                            progressValue = (progressCurrent / progressMax);
                            if (prevProgres != progressValue)
                            {
                                progressChange();
                            }
                        }
                    });
                }//);

                workingBitmap = ImageWrapper.ArrayToImage(workingBitmap, pictArray, yPicMax, xPicMax);
            }
            progressValue = 0;
            progressChange();
            Turtle_LineIsDone();
        }

        private void progressChange()
        {
            if (progressBar.InvokeRequired)
            {
                progressBar.Invoke((MethodInvoker)delegate
                {
                    progressBar.Value = (int)progressValue;
                });
            }
            else
            {
                progressBar.Value = (int)progressValue;
            }
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
                   startButton.Enabled = true;
               });
            }
            else
            {
                workingBitmap = turtle.GetResult();
                pictureBox.Image = workingBitmap;
                pictureBox.Refresh();
                startButton.Enabled = true;
            }
            isdrawingComlete = true;
            startButton.Enabled = true;
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
            else if (typeComboBox.Text == "Julia")
            {
                Lsyspanel.Enabled = true;
                tabControl.SelectTab(Julia_tab);
            }
            else
            {
                Lsyspanel.Enabled = false;
            }
        }

        private void ComplexNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!isAutoStarted)
            {
                isAutoStarted = true;
                Complex c = new Complex((double)realNumericUpDown.Value, (double)imaginaryNumericUpDown.Value);
                comlexModuleLabel.Text = "Complexmodule =" + c.Magnitude.ToString();
                if (autoStartCheckBox.Checked) startButton_Click();
                isAutoStarted = false;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.SaveFileQuality = saveFileQualityNumericUpDown.Value;
            Properties.Settings.Default.Save();
            DialogResult dialogResult = saveFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, (long)saveFileQualityNumericUpDown.Value);
                myEncoderParameters.Param[0] = myEncoderParameter;
                ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);
                workingBitmap.Save(saveFileDialog.FileName, jgpEncoder, myEncoderParameters);
            }
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mousePos2 = e.Location;
            }
            else
            {
                mousePos1 = mousePos2 = e.Location;
            }
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (mousePos1 != mousePos2)
            {
                Rectangle rect = GetRect(mousePos1, mousePos2);
                ControlPaint.DrawFocusRectangle(e.Graphics, rect);//рисуем рамку
                // recalc points
                recalcMinMax(rect);
            }
        }

        private void recalcMinMax(Rectangle rectangleInImage)
        {
            decimal xLenght = maxXJuliaMandel - minXJuliaMandel;
            decimal yLenght = maxYJuliaMandel - minYJuliaMandel;

            long xPicMax = (long)sizeXNumericUpDown.Value;
            long yPicMax = (long)sizeYNumericUpDown.Value;

            decimal pic2XMult = (decimal)xPicMax / xLenght;
            decimal pic2YMult = (decimal)yPicMax / yLenght;

            decimal middleX = (minXJuliaMandel + maxXJuliaMandel) / 2;
            decimal middleY = (minYJuliaMandel + maxYJuliaMandel) / 2;

            BigInteger picCenterX = ((BigInteger)xPicMax / 2 - (BigInteger)(middleX * pic2XMult));
            BigInteger picCenterY = ((BigInteger)yPicMax / 2 - (BigInteger)(middleY * pic2YMult));

            xMinNumericUpDown.Value = ((decimal)(rectangleInImage.X - picCenterX)) / pic2XMult;
            xMaxNumericUpDown.Value = ((decimal)(rectangleInImage.X + rectangleInImage.Width - picCenterX)) / pic2XMult;
            yMinNumericUpDown.Value = ((decimal)(rectangleInImage.Y - picCenterY)) / pic2YMult;
            yMaxNumericUpDown.Value = ((decimal)(rectangleInImage.Y + rectangleInImage.Height - picCenterY)) / pic2YMult;

        }

        /// <summary>
        /// Getting rectangle from 2 points
        /// </summary>
        /// <param name="p1">First point</param>
        /// <param name="p2">Second point</param>
        /// <returns></returns>
        Rectangle GetRect(Point p1, Point p2)
        {
            var x1 = Math.Min(p1.X, p2.X);
            var x2 = Math.Max(p1.X, p2.X);
            var y1 = Math.Min(p1.Y, p2.Y);
            var y2 = Math.Max(p1.Y, p2.Y);
            return new Rectangle(x1, y1, x2 - x1, y2 - y1);
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox.Invalidate();
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            //пользователь выделил фрагмент и отпустил мышь?
            if (mousePos1 != mousePos2)
            {
                //создаем DraggedFragment
                var rect = GetRect(mousePos1, mousePos2);
            }
            pictureBox.Invalidate();
        }
    }
}
