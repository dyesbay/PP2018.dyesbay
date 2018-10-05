using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trajectory
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
            g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            pen = new Pen(Color.Black, 1);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            double x0 = double.Parse(textBox4.Text);
            double y0 = double.Parse(textBox5.Text);
            double speed = double.Parse(textBox3.Text);
            double angle = double.Parse(textBox2.Text)*Math.PI/180;
            double ballAngle = double.Parse(textBox1.Text) * Math.PI / 180;
            double length = Math.Sqrt(pictureBox1.Width * pictureBox1.Width + pictureBox1.Height * pictureBox1.Height);
            Point p = new Point((int)(x0 + length * Math.Cos(angle)),(int)(y0 + length * Math.Sin(angle)));
            g.DrawLine(pen, new Point ((int)x0,(int)y0), p);
            pictureBox1.Image = bmp;
            Ball ball = new Ball(x0, y0 ,speed,-ballAngle);
            while (ball.x<pictureBox1.Width-10 && ball.y < pictureBox1.Height-10)
            {
                if (Math.Atan((ball.y - y0) / (ball.x - x0)) >= angle && Math.Atan(ball.speedY / ball.speedX) >= angle)
                    ball.reflect(angle);
                ball.Tick();
                if (ball.x>0 && ball.y>0)
                    bmp.SetPixel((int)ball.x, (int)ball.y, Color.Brown);

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
