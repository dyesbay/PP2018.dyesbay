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

namespace Asteroid
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        Graphics g;

        public void drawStar(int x, int y)
        {
            Point[] points = new Point[3];
            points[0] = new Point(x + 15, y);
            points[1] = new Point(x , y+26);
            points[2] = new Point(x + 30, y+26);
            g.FillPolygon(new SolidBrush(Color.Yellow), points);
            points[0] = new Point(x + 15, y+35);
            points[1] = new Point(x, y + 9);
            points[2] = new Point(x + 30, y + 9);

            g.FillPolygon(new SolidBrush(Color.Yellow), points);
        }
        
         

        public void drawStar2 (int x, int y)
        {
            g.FillEllipse(new SolidBrush(Color.LightGray), x, y, 25, 25);
        }

        public void drawBullet (int x, int y)
        {
            //g.FillEllipse(new SolidBrush(Color.Aquamarine), x, y, 50, 12);

            //g.FillEllipse(new SolidBrush(Color.Aquamarine), x+19, y-19, 12, 50);

            g.FillPolygon(new SolidBrush(Color.Aquamarine), new Point[8] { new Point(x, y), new Point(x+15, y-5), new Point(x+20, y-20), new Point(x+25, y-5), new Point(x+40, y), new Point(x+25, y+5), new Point(x+20, y+20), new Point(x+15, y+5) });
        }
        public void drawShip (int x,  int y)
        {

            Point[] points = new Point[6];
            points[0] = new Point(x + 30, y);
            points[1] = new Point(x + 65, y );
            points[2] = new Point(x + 80, y+30);
            points[3] = new Point(x + 65, y+60);
            points[4] = new Point(x + 30, y+60);
            points[5] = new Point(x+15 , y+30);
            g.FillPolygon(new SolidBrush(Color.Maroon), points);
            Point[] points2 = new Point[3];
            points2[0] = new Point(x + 47, y);
            points2[1] = new Point(x + 65, y + 60);
            points2[2] = new Point(x + 30, y + 60);
            g.FillPolygon(new SolidBrush(Color.Green), points2);
            points2[0] = new Point(x + 47, y-20);
            points2[1] = new Point(x + 65, y );
            points2[2] = new Point(x + 30, y );
            g.FillPolygon(new SolidBrush(Color.Black), points2);
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.Clear(Color.DarkBlue);
            drawStar(50, 50);
            drawStar(200, 350);
            drawStar(450, 80);
            drawStar(600, 400);
            drawStar(550, 130);
            drawStar(70, 320);
            drawStar(220, 150);
            drawStar(400, 250);
            drawStar(50, 50);
            drawStar2(160, 40);
            drawStar2(250, 240);
            drawStar2(50, 240);
            drawStar2(550, 280);
            drawStar2(160, 40);
            drawShip(320, 170);
            g.DrawString("Score: 0", new Font(FontFamily.GenericSansSerif, 12), new SolidBrush(Color.White), 600, 10);
            drawBullet(340, 120);
        }
    }
}
