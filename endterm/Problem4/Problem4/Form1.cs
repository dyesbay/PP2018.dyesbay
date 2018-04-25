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

namespace Problem4
{
    public partial class Form1 : Form
    {
        int score = 20;
        public void func()
        {

        }
        public Form1()
        {
            InitializeComponent();

            label1.Text = score.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void red (object sender, EventArgs e)
        {
            score += 20;
            label1.Text = score.ToString();
            //Controls.Remove(object sender);
        }
        public void blue(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Controls.Remove(btn);
            score /= 2;
            label1.Text = score.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread thrd = new Thread(func);
            thrd.Start();
            /*while (true)
            {
                Thread.Sleep(200);*/
                Button b = new Button();
                b.Size = new Size(30, 30);
                Random rnd1 = new Random();
                Random rnd2 = new Random();
            Random rnd3 = new Random();
            int x = rnd1.Next(300);

                int y = rnd1.Next(300);
                int clr = rnd3.Next(2);

                b.Location = new Point(x, y);
                if (clr == 1)
                {
                    b.ForeColor = Color.Blue;
                b.Click += new EventHandler(blue);

                b.BackColor = Color.Blue;
                }
                else
                {

                b.BackColor = Color.Red;

                b.Click += new EventHandler(red);

                b.ForeColor = Color.Red;
                }
            Controls.Add(b);
            //}
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
