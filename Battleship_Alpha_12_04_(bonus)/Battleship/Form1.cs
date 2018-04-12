using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship
{
    public partial class Form1 : Form
    {
        Graphics g;
        Bitmap bmp;
        Pen pen;
        List<Point> ships = new List<Point>();
        bool drag = false;
        int x1 = 200, y1=200;
        
        public bool ifShip (int x, int y)
        {
            Point p = new Point(x, y);
            for (int i= 0; i < ships.Count; i++)
            {
                if (ships[i] == p)
                    return false;
            }
            return true;
        }  
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            pen = new Pen(Color.Black, 1);
            for (int i = 10; i<=160; i += 15)
            {
                g.DrawLine(pen, i, 10, i, 160);

                g.DrawLine(pen, 10, i, 160, i);
            }

            g.DrawLine(pen, 200, 10, 245, 10);
            g.DrawLine(pen, 200, 25, 245, 25);
            g.DrawLine(pen, 200, 10, 200, 25);
            g.DrawLine(pen, 215, 10, 215, 25);
            g.DrawLine(pen, 230, 10, 230, 25);
            g.DrawLine(pen, 245, 10, 245, 25);
            pictureBox1.Image = bmp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Location.X >= 200 && e.Location.X <= 245 && e.Location.Y <= 25 && e.Location.Y >= 10)
                drag = true;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag && e.Location.X >= 10 && e.Location.X < 160 && e.Location.Y >= 10 && e.Location.Y < 160)
            {

                if (ifShip(x1, y1) && ifShip(x1 + 15, y1) && ifShip(x1 + 30, y1))
                {
                    //if (bmp.GetPixel(x1+5, y1+5) != Color.Blue)
                    g.FillRectangle(Brushes.White, x1 + 1, y1 + 1, 14, 14);
                    //if (bmp.GetPixel(x1 + 33, y1 + 5) != Color.Blue)
                    g.FillRectangle(Brushes.White, x1 + 31, y1 + 1, 14, 14);
                    //if (bmp.GetPixel(x1 +20, y1 + 5) != Color.Blue)
                    g.FillRectangle(Brushes.White, x1 + 16, y1 + 1, 14, 14);
                }
                x1 = e.Location.X;
                y1 = e.Location.Y;
                x1 -= (x1 - 10) % 15;
                y1 -= (y1 - 10) % 15;
                if (ifShip(x1, y1) && ifShip(x1 + 15, y1) && ifShip(x1 + 30, y1))
                {
                    g.FillRectangle(Brushes.Red, x1 + 1, y1 + 1, 14, 14);
                    g.FillRectangle(Brushes.Red, x1 + 31, y1 + 1, 14, 14);
                    g.FillRectangle(Brushes.Red, x1 + 16, y1 + 1, 14, 14);
                }
                pictureBox1.Image = bmp;

            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (ifShip(x1, y1) && ifShip(x1 + 15, y1) && ifShip(x1 + 30, y1))
            {
                ships.Add(new Point(x1, y1));
                ships.Add(new Point(x1 + 15, y1));
                ships.Add(new Point(x1 + 30, y1));
                ships.Add(new Point(x1 - 15, y1));
                ships.Add(new Point(x1 + 45, y1));
                ships.Add(new Point(x1, y1 + 15));
                ships.Add(new Point(x1 + 15, y1 + 15));
                ships.Add(new Point(x1 + 30, y1 + 15));
                ships.Add(new Point(x1 - 15, y1 + 15));
                ships.Add(new Point(x1 + 45, y1 + 15));

                ships.Add(new Point(x1, y1 - 15));
                ships.Add(new Point(x1 + 15, y1 - 15));
                ships.Add(new Point(x1 + 30, y1 - 15));
                ships.Add(new Point(x1 - 15, y1 - 15));
                ships.Add(new Point(x1 + 45, y1 - 15));
                x1 = 200;
                y1 = 200;
                drag = false;
            }
        }
    }
}
