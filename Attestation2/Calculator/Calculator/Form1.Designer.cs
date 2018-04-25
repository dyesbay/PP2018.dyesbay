namespace Calculator
{
    partial class Form1
    {

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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.button25 = new System.Windows.Forms.Button();
            this.button26 = new System.Windows.Forms.Button();
            this.button27 = new System.Windows.Forms.Button();
            this.button28 = new System.Windows.Forms.Button();
            this.Equal = new System.Windows.Forms.Button();
            this.point = new System.Windows.Forms.Button();
            this.button31 = new System.Windows.Forms.Button();
            this.change_sign = new System.Windows.Forms.Button();
            this.button33 = new System.Windows.Forms.Button();
            this.delete_last = new System.Windows.Forms.Button();
            this.C = new System.Windows.Forms.Button();
            this.CE = new System.Windows.Forms.Button();
            this.Clear_Memory = new System.Windows.Forms.Button();
            this.Call_Memory = new System.Windows.Forms.Button();
            this.Subtract_From_Memory = new System.Windows.Forms.Button();
            this.Add_To_Memory = new System.Windows.Forms.Button();
            this.MS = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Bold);
            this.textBox1.Location = new System.Drawing.Point(5, 17);
            this.textBox1.MaxLength = 9;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(236, 40);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox1.Click += new System.EventHandler(this.Mono_operations);
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button1.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(199, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 41);
            this.button1.TabIndex = 1;
            this.button1.Text = "sqrt";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Mono_operations);
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button13.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button13.Location = new System.Drawing.Point(151, 151);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(42, 35);
            this.button13.TabIndex = 16;
            this.button13.Text = "÷";
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.Bi_operations);
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button16.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button16.Location = new System.Drawing.Point(199, 151);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(42, 35);
            this.button16.TabIndex = 13;
            this.button16.Text = "%";
            this.button16.UseVisualStyleBackColor = false;
            this.button16.Click += new System.EventHandler(this.Bi_operations);
            // 
            // button17
            // 
            this.button17.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button17.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button17.Location = new System.Drawing.Point(151, 192);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(42, 35);
            this.button17.TabIndex = 20;
            this.button17.Text = "х";
            this.button17.UseVisualStyleBackColor = false;
            this.button17.Click += new System.EventHandler(this.Bi_operations);
            // 
            // button18
            // 
            this.button18.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button18.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button18.Location = new System.Drawing.Point(103, 151);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(42, 35);
            this.button18.TabIndex = 19;
            this.button18.Text = "9";
            this.button18.UseVisualStyleBackColor = false;
            this.button18.Click += new System.EventHandler(this.input);
            // 
            // button19
            // 
            this.button19.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button19.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button19.Location = new System.Drawing.Point(55, 151);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(42, 35);
            this.button19.TabIndex = 18;
            this.button19.Text = "8";
            this.button19.UseVisualStyleBackColor = false;
            this.button19.Click += new System.EventHandler(this.input);
            // 
            // button20
            // 
            this.button20.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button20.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button20.Location = new System.Drawing.Point(6, 151);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(43, 35);
            this.button20.TabIndex = 17;
            this.button20.Text = "7";
            this.button20.UseVisualStyleBackColor = false;
            this.button20.Click += new System.EventHandler(this.input);
            // 
            // button21
            // 
            this.button21.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button21.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button21.Location = new System.Drawing.Point(151, 233);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(42, 35);
            this.button21.TabIndex = 24;
            this.button21.Text = "-";
            this.button21.UseVisualStyleBackColor = false;
            this.button21.Click += new System.EventHandler(this.Bi_operations);
            // 
            // button22
            // 
            this.button22.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button22.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button22.Location = new System.Drawing.Point(103, 192);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(42, 35);
            this.button22.TabIndex = 23;
            this.button22.Text = "6";
            this.button22.UseVisualStyleBackColor = false;
            this.button22.Click += new System.EventHandler(this.input);
            // 
            // button23
            // 
            this.button23.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button23.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button23.Location = new System.Drawing.Point(55, 192);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(42, 35);
            this.button23.TabIndex = 22;
            this.button23.Text = "5";
            this.button23.UseVisualStyleBackColor = false;
            this.button23.Click += new System.EventHandler(this.input);
            // 
            // button24
            // 
            this.button24.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button24.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button24.Location = new System.Drawing.Point(7, 192);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(42, 35);
            this.button24.TabIndex = 21;
            this.button24.Text = "4";
            this.button24.UseVisualStyleBackColor = false;
            this.button24.Click += new System.EventHandler(this.input);
            // 
            // button25
            // 
            this.button25.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button25.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button25.Location = new System.Drawing.Point(151, 274);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(40, 35);
            this.button25.TabIndex = 28;
            this.button25.Text = "+";
            this.button25.UseVisualStyleBackColor = false;
            this.button25.Click += new System.EventHandler(this.Bi_operations);
            // 
            // button26
            // 
            this.button26.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button26.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button26.Location = new System.Drawing.Point(103, 233);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(42, 35);
            this.button26.TabIndex = 27;
            this.button26.Text = "3";
            this.button26.UseVisualStyleBackColor = false;
            this.button26.Click += new System.EventHandler(this.input);
            // 
            // button27
            // 
            this.button27.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button27.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button27.Location = new System.Drawing.Point(55, 233);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(42, 35);
            this.button27.TabIndex = 26;
            this.button27.Text = "2";
            this.button27.UseVisualStyleBackColor = false;
            this.button27.Click += new System.EventHandler(this.input);
            // 
            // button28
            // 
            this.button28.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button28.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button28.Location = new System.Drawing.Point(6, 233);
            this.button28.Name = "button28";
            this.button28.Size = new System.Drawing.Size(43, 35);
            this.button28.TabIndex = 25;
            this.button28.Text = "1";
            this.button28.UseVisualStyleBackColor = false;
            this.button28.Click += new System.EventHandler(this.input);
            // 
            // Equal
            // 
            this.Equal.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Equal.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Equal.Location = new System.Drawing.Point(199, 233);
            this.Equal.Name = "Equal";
            this.Equal.Size = new System.Drawing.Size(42, 76);
            this.Equal.TabIndex = 32;
            this.Equal.Text = "=";
            this.Equal.UseVisualStyleBackColor = false;
            this.Equal.Click += new System.EventHandler(this.Equal_Click);
            // 
            // point
            // 
            this.point.BackColor = System.Drawing.SystemColors.ControlLight;
            this.point.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.point.Location = new System.Drawing.Point(105, 274);
            this.point.Name = "point";
            this.point.Size = new System.Drawing.Size(42, 35);
            this.point.TabIndex = 31;
            this.point.Text = ",";
            this.point.UseVisualStyleBackColor = false;
            this.point.Click += new System.EventHandler(this.point_Click);
            // 
            // button31
            // 
            this.button31.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button31.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button31.Location = new System.Drawing.Point(7, 274);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(90, 35);
            this.button31.TabIndex = 30;
            this.button31.Text = "0";
            this.button31.UseVisualStyleBackColor = false;
            this.button31.Click += new System.EventHandler(this.input);
            // 
            // change_sign
            // 
            this.change_sign.BackColor = System.Drawing.SystemColors.ControlLight;
            this.change_sign.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.change_sign.Location = new System.Drawing.Point(151, 107);
            this.change_sign.Name = "change_sign";
            this.change_sign.Size = new System.Drawing.Size(42, 38);
            this.change_sign.TabIndex = 29;
            this.change_sign.Text = "±";
            this.change_sign.UseVisualStyleBackColor = false;
            this.change_sign.Click += new System.EventHandler(this.change_sign_Click);
            // 
            // button33
            // 
            this.button33.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button33.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button33.Location = new System.Drawing.Point(199, 192);
            this.button33.Name = "button33";
            this.button33.Size = new System.Drawing.Size(42, 35);
            this.button33.TabIndex = 36;
            this.button33.Text = "1/x";
            this.button33.UseVisualStyleBackColor = false;
            this.button33.Click += new System.EventHandler(this.Mono_operations);
            // 
            // delete_last
            // 
            this.delete_last.BackColor = System.Drawing.SystemColors.ControlLight;
            this.delete_last.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.delete_last.Location = new System.Drawing.Point(105, 107);
            this.delete_last.Name = "delete_last";
            this.delete_last.Size = new System.Drawing.Size(40, 38);
            this.delete_last.TabIndex = 35;
            this.delete_last.Text = "⮾";
            this.delete_last.UseVisualStyleBackColor = false;
            this.delete_last.Click += new System.EventHandler(this.delete_last_Click);
            // 
            // C
            // 
            this.C.BackColor = System.Drawing.SystemColors.ControlLight;
            this.C.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.C.Location = new System.Drawing.Point(55, 107);
            this.C.Name = "C";
            this.C.Size = new System.Drawing.Size(42, 38);
            this.C.TabIndex = 34;
            this.C.Text = "C";
            this.C.UseVisualStyleBackColor = false;
            this.C.Click += new System.EventHandler(this.C_Click);
            // 
            // CE
            // 
            this.CE.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CE.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CE.Location = new System.Drawing.Point(5, 107);
            this.CE.Name = "CE";
            this.CE.Size = new System.Drawing.Size(44, 38);
            this.CE.TabIndex = 33;
            this.CE.Text = "CE";
            this.CE.UseVisualStyleBackColor = false;
            this.CE.Click += new System.EventHandler(this.CE_Click);
            // 
            // Clear_Memory
            // 
            this.Clear_Memory.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Clear_Memory.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Clear_Memory.Location = new System.Drawing.Point(5, 66);
            this.Clear_Memory.Name = "Clear_Memory";
            this.Clear_Memory.Size = new System.Drawing.Size(44, 38);
            this.Clear_Memory.TabIndex = 37;
            this.Clear_Memory.Text = "MC";
            this.Clear_Memory.UseVisualStyleBackColor = false;
            this.Clear_Memory.Click += new System.EventHandler(this.Clear_Memory_Click);
            // 
            // Call_Memory
            // 
            this.Call_Memory.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Call_Memory.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Call_Memory.Location = new System.Drawing.Point(55, 66);
            this.Call_Memory.Name = "Call_Memory";
            this.Call_Memory.Size = new System.Drawing.Size(42, 38);
            this.Call_Memory.TabIndex = 38;
            this.Call_Memory.Text = "MR";
            this.Call_Memory.UseVisualStyleBackColor = false;
            this.Call_Memory.Click += new System.EventHandler(this.Call_Memory_Click);
            // 
            // Subtract_From_Memory
            // 
            this.Subtract_From_Memory.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Subtract_From_Memory.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Subtract_From_Memory.Location = new System.Drawing.Point(151, 66);
            this.Subtract_From_Memory.Name = "Subtract_From_Memory";
            this.Subtract_From_Memory.Size = new System.Drawing.Size(42, 38);
            this.Subtract_From_Memory.TabIndex = 40;
            this.Subtract_From_Memory.Text = "M-";
            this.Subtract_From_Memory.UseVisualStyleBackColor = false;
            this.Subtract_From_Memory.Click += new System.EventHandler(this.Subtract_From_Memory_Click);
            // 
            // Add_To_Memory
            // 
            this.Add_To_Memory.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Add_To_Memory.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Add_To_Memory.Location = new System.Drawing.Point(199, 66);
            this.Add_To_Memory.Name = "Add_To_Memory";
            this.Add_To_Memory.Size = new System.Drawing.Size(42, 38);
            this.Add_To_Memory.TabIndex = 39;
            this.Add_To_Memory.Text = "M+";
            this.Add_To_Memory.UseVisualStyleBackColor = false;
            this.Add_To_Memory.Click += new System.EventHandler(this.Add_To_Memory_Click);
            // 
            // MS
            // 
            this.MS.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.MS.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MS.Location = new System.Drawing.Point(105, 66);
            this.MS.Name = "MS";
            this.MS.Size = new System.Drawing.Size(40, 38);
            this.MS.TabIndex = 41;
            this.MS.Text = "MS";
            this.MS.UseVisualStyleBackColor = false;
            this.MS.Click += new System.EventHandler(this.MS_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(243, 309);
            this.Controls.Add(this.MS);
            this.Controls.Add(this.Subtract_From_Memory);
            this.Controls.Add(this.Add_To_Memory);
            this.Controls.Add(this.Call_Memory);
            this.Controls.Add(this.Clear_Memory);
            this.Controls.Add(this.button33);
            this.Controls.Add(this.delete_last);
            this.Controls.Add(this.C);
            this.Controls.Add(this.CE);
            this.Controls.Add(this.Equal);
            this.Controls.Add(this.point);
            this.Controls.Add(this.button31);
            this.Controls.Add(this.change_sign);
            this.Controls.Add(this.button25);
            this.Controls.Add(this.button26);
            this.Controls.Add(this.button27);
            this.Controls.Add(this.button28);
            this.Controls.Add(this.button21);
            this.Controls.Add(this.button22);
            this.Controls.Add(this.button23);
            this.Controls.Add(this.button24);
            this.Controls.Add(this.button17);
            this.Controls.Add(this.button18);
            this.Controls.Add(this.button19);
            this.Controls.Add(this.button20);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.Button button23;
        private System.Windows.Forms.Button button24;
        private System.Windows.Forms.Button button25;
        private System.Windows.Forms.Button button26;
        private System.Windows.Forms.Button button27;
        private System.Windows.Forms.Button button28;
        private System.Windows.Forms.Button Equal;
        private System.Windows.Forms.Button point;
        private System.Windows.Forms.Button button31;
        private System.Windows.Forms.Button change_sign;
        private System.Windows.Forms.Button button33;
        private System.Windows.Forms.Button delete_last;
        private System.Windows.Forms.Button C;
        private System.Windows.Forms.Button CE;
        private System.Windows.Forms.Button Clear_Memory;
        private System.Windows.Forms.Button Call_Memory;
        private System.Windows.Forms.Button Subtract_From_Memory;
        private System.Windows.Forms.Button Add_To_Memory;
        private System.Windows.Forms.Button MS;
        public System.Windows.Forms.TextBox textBox1;
    }
}


