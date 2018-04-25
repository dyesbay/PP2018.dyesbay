namespace Paint_PR
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button22 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(-6, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(590, 555);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(590, 518);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 19);
            this.button1.TabIndex = 2;
            this.button1.Text = "Линия";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.tool_Click);
            // 
            // button2
            // 
            this.button2.AutoEllipsis = true;
            this.button2.Location = new System.Drawing.Point(590, 493);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 19);
            this.button2.TabIndex = 3;
            this.button2.Text = "Прямоугольник";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.tool_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(590, 463);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(84, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Элипс";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.tool_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(589, 409);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(85, 22);
            this.button4.TabIndex = 5;
            this.button4.Text = "Треугольник";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.tool_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(589, 437);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(85, 20);
            this.button5.TabIndex = 6;
            this.button5.Text = "Карандаш";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.tool_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(589, 381);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(85, 22);
            this.button7.TabIndex = 8;
            this.button7.Text = "Заливка";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.tool_Click);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.Black;
            this.button11.Location = new System.Drawing.Point(590, 101);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(48, 22);
            this.button11.TabIndex = 14;
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.tencolors_Click);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.White;
            this.button12.Location = new System.Drawing.Point(590, 120);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(48, 22);
            this.button12.TabIndex = 15;
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.tencolors_Click);
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button13.Location = new System.Drawing.Point(590, 214);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(48, 22);
            this.button13.TabIndex = 17;
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.tencolors_Click);
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.Red;
            this.button14.Location = new System.Drawing.Point(590, 139);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(48, 22);
            this.button14.TabIndex = 16;
            this.button14.UseVisualStyleBackColor = false;
            this.button14.Click += new System.EventHandler(this.tencolors_Click);
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.Yellow;
            this.button15.Location = new System.Drawing.Point(590, 177);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(48, 22);
            this.button15.TabIndex = 19;
            this.button15.UseVisualStyleBackColor = false;
            this.button15.Click += new System.EventHandler(this.tencolors_Click);
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.Color.Green;
            this.button16.Location = new System.Drawing.Point(590, 195);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(48, 22);
            this.button16.TabIndex = 18;
            this.button16.UseVisualStyleBackColor = false;
            this.button16.Click += new System.EventHandler(this.tencolors_Click);
            // 
            // button17
            // 
            this.button17.BackColor = System.Drawing.Color.Purple;
            this.button17.Location = new System.Drawing.Point(590, 270);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(48, 22);
            this.button17.TabIndex = 21;
            this.button17.UseVisualStyleBackColor = false;
            this.button17.Click += new System.EventHandler(this.tencolors_Click);
            // 
            // button18
            // 
            this.button18.BackColor = System.Drawing.Color.Blue;
            this.button18.Location = new System.Drawing.Point(590, 158);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(48, 22);
            this.button18.TabIndex = 20;
            this.button18.UseVisualStyleBackColor = false;
            this.button18.Click += new System.EventHandler(this.tencolors_Click);
            // 
            // button19
            // 
            this.button19.BackColor = System.Drawing.Color.SkyBlue;
            this.button19.Location = new System.Drawing.Point(590, 233);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(48, 22);
            this.button19.TabIndex = 23;
            this.button19.UseVisualStyleBackColor = false;
            this.button19.Click += new System.EventHandler(this.tencolors_Click);
            // 
            // button20
            // 
            this.button20.BackColor = System.Drawing.Color.Gray;
            this.button20.Location = new System.Drawing.Point(590, 251);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(48, 22);
            this.button20.TabIndex = 22;
            this.button20.UseVisualStyleBackColor = false;
            this.button20.Click += new System.EventHandler(this.tencolors_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBox1.Location = new System.Drawing.Point(590, 298);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(84, 21);
            this.comboBox1.TabIndex = 25;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.LightGray;
            this.button9.Location = new System.Drawing.Point(590, 27);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(48, 21);
            this.button9.TabIndex = 28;
            this.button9.Text = "Save";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.LightGray;
            this.button10.Location = new System.Drawing.Point(590, -1);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(48, 22);
            this.button10.TabIndex = 29;
            this.button10.Text = "Clear";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button22
            // 
            this.button22.BackColor = System.Drawing.Color.LightGray;
            this.button22.Location = new System.Drawing.Point(589, 54);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(48, 22);
            this.button22.TabIndex = 30;
            this.button22.Text = "Open";
            this.button22.UseVisualStyleBackColor = false;
            this.button22.Click += new System.EventHandler(this.button22_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(677, 549);
            this.Controls.Add(this.button22);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button19);
            this.Controls.Add(this.button20);
            this.Controls.Add(this.button17);
            this.Controls.Add(this.button18);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Paint";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }

}

