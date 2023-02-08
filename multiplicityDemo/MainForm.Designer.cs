
namespace multiplicityDemo
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.magnNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.startButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.startYnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.sizeYNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.startXnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.sizeXNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.lineLenghtNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.magnNumericUpDown)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startYnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeYNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startXnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeXNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineLenghtNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 137;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.startYnumericUpDown);
            this.panel2.Controls.Add(this.sizeYNumericUpDown);
            this.panel2.Controls.Add(this.startXnumericUpDown);
            this.panel2.Controls.Add(this.sizeXNumericUpDown);
            this.panel2.Controls.Add(this.lineLenghtNumericUpDown);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.magnNumericUpDown);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.typeComboBox);
            this.panel2.Controls.Add(this.startButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(137, 450);
            this.panel2.TabIndex = 0;
            // 
            // magnNumericUpDown
            // 
            this.magnNumericUpDown.DecimalPlaces = 6;
            this.magnNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.magnNumericUpDown.Location = new System.Drawing.Point(4, 69);
            this.magnNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.magnNumericUpDown.Name = "magnNumericUpDown";
            this.magnNumericUpDown.Size = new System.Drawing.Size(130, 20);
            this.magnNumericUpDown.TabIndex = 4;
            this.magnNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.magnNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            131072});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Picture Size";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Line Lenght";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Magnification";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Multyplicity type";
            // 
            // typeComboBox
            // 
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Items.AddRange(new object[] {
            "Koch curve",
            "Koch triangle right",
            "Koch triangle left"});
            this.typeComboBox.Location = new System.Drawing.Point(3, 25);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(134, 21);
            this.typeComboBox.TabIndex = 1;
            this.typeComboBox.Text = "Koch curve";
            // 
            // startButton
            // 
            this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.startButton.Location = new System.Drawing.Point(3, 413);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(131, 34);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.pictureBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(659, 450);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(3, 3);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(653, 444);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 215);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Start Position";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 233);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "X";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 259);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Y";
            // 
            // startYnumericUpDown
            // 
            this.startYnumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::multiplicityDemo.Properties.Settings.Default, "Ystart", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.startYnumericUpDown.Location = new System.Drawing.Point(29, 257);
            this.startYnumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.startYnumericUpDown.Name = "startYnumericUpDown";
            this.startYnumericUpDown.Size = new System.Drawing.Size(105, 20);
            this.startYnumericUpDown.TabIndex = 4;
            this.startYnumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.startYnumericUpDown.Value = global::multiplicityDemo.Properties.Settings.Default.Ystart;
            this.startYnumericUpDown.ValueChanged += new System.EventHandler(this.NumericUpDown_ValueChanged);
            // 
            // sizeYNumericUpDown
            // 
            this.sizeYNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::multiplicityDemo.Properties.Settings.Default, "Ysize", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sizeYNumericUpDown.Location = new System.Drawing.Point(29, 191);
            this.sizeYNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.sizeYNumericUpDown.Name = "sizeYNumericUpDown";
            this.sizeYNumericUpDown.Size = new System.Drawing.Size(105, 20);
            this.sizeYNumericUpDown.TabIndex = 4;
            this.sizeYNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.sizeYNumericUpDown.Value = global::multiplicityDemo.Properties.Settings.Default.Ysize;
            this.sizeYNumericUpDown.ValueChanged += new System.EventHandler(this.NumericUpDown_ValueChanged);
            // 
            // startXnumericUpDown
            // 
            this.startXnumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::multiplicityDemo.Properties.Settings.Default, "Xstart", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.startXnumericUpDown.Location = new System.Drawing.Point(29, 231);
            this.startXnumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.startXnumericUpDown.Name = "startXnumericUpDown";
            this.startXnumericUpDown.Size = new System.Drawing.Size(105, 20);
            this.startXnumericUpDown.TabIndex = 4;
            this.startXnumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.startXnumericUpDown.Value = global::multiplicityDemo.Properties.Settings.Default.Xstart;
            this.startXnumericUpDown.ValueChanged += new System.EventHandler(this.NumericUpDown_ValueChanged);
            // 
            // sizeXNumericUpDown
            // 
            this.sizeXNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::multiplicityDemo.Properties.Settings.Default, "XSize", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sizeXNumericUpDown.Location = new System.Drawing.Point(29, 165);
            this.sizeXNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.sizeXNumericUpDown.Name = "sizeXNumericUpDown";
            this.sizeXNumericUpDown.Size = new System.Drawing.Size(105, 20);
            this.sizeXNumericUpDown.TabIndex = 4;
            this.sizeXNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.sizeXNumericUpDown.Value = global::multiplicityDemo.Properties.Settings.Default.Xsize;
            this.sizeXNumericUpDown.ValueChanged += new System.EventHandler(this.NumericUpDown_ValueChanged);
            // 
            // lineLenghtNumericUpDown
            // 
            this.lineLenghtNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::multiplicityDemo.Properties.Settings.Default, "LineLenght", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lineLenghtNumericUpDown.Location = new System.Drawing.Point(4, 117);
            this.lineLenghtNumericUpDown.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.lineLenghtNumericUpDown.Name = "lineLenghtNumericUpDown";
            this.lineLenghtNumericUpDown.Size = new System.Drawing.Size(130, 20);
            this.lineLenghtNumericUpDown.TabIndex = 4;
            this.lineLenghtNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.lineLenghtNumericUpDown.Value = global::multiplicityDemo.Properties.Settings.Default.LineLenght;
            this.lineLenghtNumericUpDown.ValueChanged += new System.EventHandler(this.NumericUpDown_ValueChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "Multiplicity Demo";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.magnNumericUpDown)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startYnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeYNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startXnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeXNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineLenghtNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.NumericUpDown magnNumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown lineLenghtNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown sizeYNumericUpDown;
        private System.Windows.Forms.NumericUpDown sizeXNumericUpDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown startYnumericUpDown;
        private System.Windows.Forms.NumericUpDown startXnumericUpDown;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}

