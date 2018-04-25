using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Problem2
{

    public partial class Form1 : Form

    {
        Graphics g;
        Bitmap bmp;
        Pen pen;
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pen = new Pen(Color.Black, 2);
            g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            pictureBox1.Image = bmp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            int x, y;
            x = int.Parse(textBox1.Text);
            y = int.Parse(textBox2.Text);
            Rectangle rect = new Rectangle(x, y, 40,40);
            g.DrawRectangle(pen, rect);
            pictureBox1.Image = bmp;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            int x, y;
            x = int.Parse(textBox1.Text);
            y = int.Parse(textBox2.Text);
            g.DrawEllipse(pen,x,y, 40, 40);
            pictureBox1.Image = bmp;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            int x, y;
            x = int.Parse(textBox1.Text);
            y = int.Parse(textBox2.Text);
            g.DrawLine(pen, x, y + 40, x + 40, y + 40);

            g.DrawLine(pen, x, y + 40, x + 20, y );

            g.DrawLine(pen, x+40, y + 40, x + 20, y);
            pictureBox1.Image = bmp;
        }
    }
}
