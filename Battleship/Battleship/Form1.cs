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
        Graphics g2;
        Bitmap bmp2;
        //List<Point> ships = new List<Point>();
        bool drag = false;
        int x1 = 200, y1=200;

        public class ship
        {
            public List<Point> Points;

            public List<Point> Dump;


            public bool alive = true;
            public ship()
            {
                Points = new List<Point>();
                Dump = new List<Point>();

            }
        } 

        
        public bool ifShip (int x, int y)
        {
            Point p = new Point(x, y);
            if (x < 10 || y < 10 || x >= 160 || y >= 160)
                return false;
            for (int i= 0; i < pl_ships.Count; i++)
            {
                for (int j = 0; j < pl_ships[i].Points.Count; j++)
                    if (x >= pl_ships[i].Points[j].X - 15 && y >= pl_ships[i].Points[j].Y - 15 && x <= pl_ships[i].Points[j].X + 15 && y <= pl_ships[i].Points[j].Y + 15)
                        return false;
            }
            return true;
        }

        public bool ifShip2(int x, int y)
        {
            Point p = new Point(x, y);
            if (x < 10 || y < 10 || x >= 160 || y >= 160)
                return false;
            for (int i = 0; i < c_ships.Count; i++)
            {
                for (int j = 0; j < c_ships[i].Points.Count; j++)
                    if (x >= c_ships[i].Points[j].X - 15 && y >= c_ships[i].Points[j].Y - 15 && x <= c_ships[i].Points[j].X + 15 && y <= c_ships[i].Points[j].Y + 15)
                        return false;
            }
            return true;
        }


        Stack<Point> toCheck = new Stack<Point>();

        public void Strike2()
        {
            bool ifHit = false;
            int x =0;
            int y =0;
            if (toCheck.Count == 0)
            {
                bool boooool = true;
                while (boooool)
                {
                    boooool = false;

                    Random rnd = new Random();
                    Random rnd2 = new Random();
                    x = rnd.Next(10) * 15 + 10;

                    y = rnd.Next(10) * 15 + 10;
                    for (int k = 0; k < pl_empty.Count; k++)
                    {
                        if (pl_empty[k].X == x  && pl_empty[k].Y == y)
                        {
                            boooool = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                Point ptr = toCheck.Pop();
                x = ptr.X;
                y = ptr.Y;
            }

            for (int i = 0; i < pl_ships.Count; i++)
                {
                    for (int j = 0; j< pl_ships[i].Points.Count; j++)
                    {
                        if (x == pl_ships[i].Points[j].X && y == pl_ships[i].Points[j].Y)
                        {
                            ifHit = true;
                            g.DrawLine(new Pen(Color.Blue, 3), x + 1, y + 1, x + 14, y + 14);
                            g.DrawLine(new Pen(Color.Blue, 3), x + 1, y + 14, x + 14, y + 1);
                            pl_ships[i].Dump.Add(pl_ships[i].Points[j]);
                            pl_ships[i].Points.Remove(pl_ships[i].Points[j]);
                            pl_empty.Add(new Point(x, y));

                            bool bl = false;
                            for (int k = 0; k < pl_empty.Count; k++)
                            {
                                if (pl_empty[k].X == x + 15 && pl_empty[k].Y == y)
                                    bl = true;
                            }
                            if (x >= 10 && x + 15 < 160 && y >= 10 && y < 160 && !bl)
                                toCheck.Push(new Point(x + 15, y));

                            bl = false;
                            for (int k = 0; k < pl_empty.Count; k++)
                            {
                                if (pl_empty[k].X == x && pl_empty[k].Y == y + 15)
                                    bl = true;
                            }
                            if (x >= 10 && x < 160 && y + 15 >= 10 && y + 15 < 160 && !bl)
                                toCheck.Push(new Point(x, y + 15));

                            bl = false;
                            for (int k = 0; k < pl_empty.Count; k++)
                            {
                                if (pl_empty[k].X == x && pl_empty[k].Y == y + 15)
                                    bl = true;
                            }
                            if (x >= 10 && x < 160 && y - 15 >= 10 && y < 160 && !bl)
                                toCheck.Push(new Point(x, y - 15));

                            bl = false;
                            for (int k = 0; k < pl_empty.Count; k++)
                            {
                                if (pl_empty[k].X == x - 15 && pl_empty[k].Y == y)
                                    bl = true;
                            }
                            if (x - 15 >= 10 && x - 15 < 160 && y >= 10 && y < 160 && !bl)
                                toCheck.Push(new Point(x - 15, y));

                            if (pl_ships[i].Points.Count == 0)
                            {
                                toCheck.Clear();
                                pl_ships[i].alive = false;
                                for (int k = 0; k < pl_ships[i].Dump.Count; k++)
                                {
                                    int x_ = pl_ships[i].Dump[k].X;
                                    int y_ = pl_ships[i].Dump[k].Y;
                                    Point pt1 = new Point(x, y + 15);
                                    if (pt1.X >= 10 && pt1.X < 160 && pt1.Y >= 10 && pt1.Y < 160)
                                        pl_empty.Add(pt1);
                                    pt1 = new Point(x + 15, y + 15);
                                    if (pt1.X >= 10 && pt1.X < 160 && pt1.Y >= 10 && pt1.Y < 160)
                                        pl_empty.Add(pt1);
                                    pt1 = new Point(x + 15, y - 15);
                                    if (pt1.X >= 10 && pt1.X < 160 && pt1.Y >= 10 && pt1.Y < 160)
                                        pl_empty.Add(pt1);
                                    pt1 = new Point(x - 15, y);
                                    if (pt1.X >= 10 && pt1.X < 160 && pt1.Y >= 10 && pt1.Y < 160)
                                        pl_empty.Add(pt1);
                                    pt1 = new Point(x - 15, y + 15);
                                    if (pt1.X >= 10 && pt1.X < 160 && pt1.Y >= 10 && pt1.Y < 160)
                                        pl_empty.Add(pt1);
                                    pt1 = new Point(x - 15, y - 15);
                                    if (pt1.X >= 10 && pt1.X < 160 && pt1.Y >= 10 && pt1.Y < 160)
                                        pl_empty.Add(pt1);
                                    pt1 = new Point(x + 15, y);
                                    if (pt1.X >= 10 && pt1.X < 160 && pt1.Y >= 10 && pt1.Y < 160)
                                        pl_empty.Add(pt1);
                                    pt1 = new Point(x, y - 15);
                                    if (pt1.X >= 10 && pt1.X < 160 && pt1.Y >= 10 && pt1.Y < 160)
                                        pl_empty.Add(pt1);

                                }
                            }

                        }
                        else
                            pl_empty.Add(new Point(x, y));
                    }
                }

            if (ifHit)
                Strike2();
            turn = 1;

        }

        public void Strike (Point pt)
        {
            turn = 0;
            int x = pt.X ;
            x -= (x-10) % 15;

            int y = pt.Y;
            y -= (y-10) % 15;
            pt = new Point(x, y);
            for (int i = 0; i <c_ships.Count; i++)
                for (int j = 0; j< c_ships[i].Points.Count; j++)
                {
                    if (x== c_ships[i].Points[j].X && y == c_ships[i].Points[j].Y)
                    {
                        //g2.FillRectangle(Brushes.Black, x + 1, y + 1, 14, 14);
                        turn = 1;
                        g2.DrawLine(new Pen(Color.Blue, 3), x + 1, y + 1, x + 14, y + 14);
                        g2.DrawLine(new Pen(Color.Blue, 3), x + 1, y + 14, x + 14, y + 1);
                        c_ships[i].Dump.Add(c_ships[i].Points[j]);
                        c_ships[i].Points.Remove(c_ships[i].Points[j]);
                        if (c_ships[i].Points.Count == 0)
                        {
                            c_ships[i].alive = false;
                            for(int k = 0; k < c_ships[i].Dump.Count; k++)
                            {
                                int x_ = c_ships[i].Dump[k].X;
                                int y_ = c_ships[i].Dump[k].Y;
                                Point pt1 = new Point(x_, y_ + 15);
                                if (pt1.X >= 10 && pt1.X < 160 && pt1.Y >= 10 && pt1.Y < 160)
                                    c_empty.Add(pt1);
                                pt1 = new Point(x_+15, y_ + 15);
                                if (pt1.X >= 10 && pt1.X < 160 && pt1.Y >= 10 && pt1.Y < 160)
                                    c_empty.Add(pt1);
                                pt1 = new Point(x_ +15, y_ - 15);
                                if (pt1.X >= 10 && pt1.X < 160 && pt1.Y >= 10 && pt1.Y < 160)
                                    c_empty.Add(pt1);
                                pt1 = new Point(x_-15, y_ );
                                if (pt1.X >= 10 && pt1.X < 160 && pt1.Y >= 10 && pt1.Y < 160)
                                    c_empty.Add(pt1);
                                pt1 = new Point(x_-15, y_ + 15);
                                if (pt1.X >= 10 && pt1.X < 160 && pt1.Y >= 10 && pt1.Y < 160)
                                    c_empty.Add(pt1);
                                pt1 = new Point(x_-15, y_ - 15);
                                if (pt1.X >= 10 && pt1.X < 160 && pt1.Y >= 10 && pt1.Y < 160)
                                    c_empty.Add(pt1);
                                pt1 = new Point(x_+15, y_ );
                                if (pt1.X >= 10 && pt1.X < 160 && pt1.Y >= 10 && pt1.Y < 160)
                                    c_empty.Add(pt1);
                                pt1 = new Point(x_, y_ -15);
                                if (pt1.X >= 10 && pt1.X < 160 && pt1.Y >= 10 && pt1.Y < 160)
                                    c_empty.Add(pt1);

                            }
                        }

                        c_empty.Add(pt);
                        pictureBox2.Image = bmp2;
                        turn = 1;

                        cnt++;
                        break;
                    }
                }
            g2.FillEllipse(Brushes.Blue, x + 6, y + 6, 4, 4);
            c_empty.Add(pt);
            pictureBox2.Image = bmp2;
        }

        public bool NotEmptyC (int x, int y)
        {
            for (int i = 0; i<c_empty.Count; i++)
            {
                if (x == c_empty[i].X && y == c_empty[i].Y)
                    return false;
            }
            return true;
        }

        List<ship> pl_ships = new List<ship>();

        List<ship> c_ships = new List<ship>();

        List<Point> c_empty = new List<Point>();

        List<Point> pl_empty = new List<Point>();

        ship temp_sh = new ship();

        bool start = false;
        int turn = 1;
        int cnt4 = 1, cnt3 = 1, cnt2 = 2, cnt1 = 3;
        enum shiptype
        {
            FH,
            THH,
            TWH,
            FV,
            THV,
            TWV,
            ONE

        };

        shiptype ShipType = shiptype.FH;
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            g.Clear(Color.White);

            bmp2 = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            g2 = Graphics.FromImage(bmp2);
            g2.Clear(Color.White);

            pen = new Pen(Color.Black, 1);


            for (int i = 10; i<=160; i += 15)
            {
                g.DrawLine(pen, i, 10, i, 160);

                g.DrawLine(pen, 10, i, 160, i);
            }

            g.DrawLine(pen, 200, 10, 260, 10);
            g.DrawLine(pen, 200, 25, 260, 25);
            g.DrawLine(pen, 200, 10, 200, 25);
            g.DrawLine(pen, 215, 10, 215, 25);
            g.DrawLine(pen, 230, 10, 230, 25);
            g.DrawLine(pen, 245, 10, 245, 25);
            g.DrawLine(pen, 260, 10, 260, 25);

            g.DrawLine(pen, 200, 40, 245, 40);
            g.DrawLine(pen, 200, 55, 245, 55);
            g.DrawLine(pen, 200, 40, 200, 55);
            g.DrawLine(pen, 215, 40, 215, 55);
            g.DrawLine(pen, 230, 40, 230, 55);
            g.DrawLine(pen, 245, 40, 245, 55);

            g.DrawLine(pen, 200, 70, 230, 70);
            g.DrawLine(pen, 200, 85, 230, 85);
            g.DrawLine(pen, 200, 70, 200, 85);
            g.DrawLine(pen, 215, 70, 215, 85);
            g.DrawLine(pen, 230, 70, 230, 85);

            g.DrawLine(pen, 200, 100, 215, 100);
            g.DrawLine(pen, 200, 115, 215, 115);
            g.DrawLine(pen, 200, 100, 200, 115);
            g.DrawLine(pen, 215, 100, 215, 115);

            g.DrawLine(pen, 275, 10, 275, 70);
            g.DrawLine(pen, 290, 10, 290, 70);
            g.DrawLine(pen, 275, 10, 290, 10);
            g.DrawLine(pen, 275, 25, 290, 25);
            g.DrawLine(pen, 275, 40, 290, 40);
            g.DrawLine(pen, 275, 55, 290, 55);
            g.DrawLine(pen, 275, 70, 290, 70);
            
            g.DrawLine(pen, 305, 10, 305, 55);
            g.DrawLine(pen, 320, 10, 320, 55);
            g.DrawLine(pen, 305, 10, 320, 10);
            g.DrawLine(pen, 305, 25, 320, 25);
            g.DrawLine(pen, 305, 40, 320, 40);
            g.DrawLine(pen, 305, 55, 320, 55);

            g.DrawLine(pen, 335, 10, 335, 40);
            g.DrawLine(pen, 350, 10, 350, 40);
            g.DrawLine(pen, 335, 10, 350, 10);
            g.DrawLine(pen, 335, 25, 350, 25);
            g.DrawLine(pen, 335, 40, 350, 40);

            pictureBox1.Image = bmp;



            for (int i = 10; i <= 160; i += 15)
            {
                g2.DrawLine(pen, i, 10, i, 160);

                g2.DrawLine(pen, 10, i, 160, i);
            }
            pictureBox2.Image = bmp2;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cnt1 == 0 && cnt2 == 0 && cnt3 == 0 && cnt4 == 0 )
            {
                
                while (c_ships.Count < 1)
                {
                    Random rnd = new Random();
                    Random rnd2 = new Random();
                    Random rnd3 = new Random();

                    int x2 = rnd.Next(10) * 15 + 10;
                    int y2 = rnd2.Next(10) * 15 + 10;

                    int ya = rnd3.Next(2);
                    if (ya == 1)
                    {
                        if (ifShip2(x2, y2) && ifShip2(x2 + 15, y2) && ifShip2(x2 + 30, y2) && ifShip2(x2 + 45, y2))
                        {
                            ship SH = new ship();
                            SH.Points.Add(new Point(x2, y2));

                            SH.Points.Add(new Point(x2 + 15, y2));

                            SH.Points.Add(new Point(x2 + 30, y2));
                            SH.Points.Add(new Point(x2 + 45, y2));

                            c_ships.Add(SH);


                            g2.FillRectangle(Brushes.Red, x2 + 1, y2 + 1, 14, 14);
                            g2.FillRectangle(Brushes.Red, x2 + 31, y2 + 1, 14, 14);
                            g2.FillRectangle(Brushes.Red, x2 + 16, y2 + 1, 14, 14);
                            g2.FillRectangle(Brushes.Red, x2 + 46, y2 + 1, 14, 14);

                            pictureBox2.Image = bmp2;


                        }
                    }
                    else if (ifShip2(x2, y2) && ifShip2(x2, y2 + 15) && ifShip2(x2, y2 + 30) && ifShip2(x2, y2 + 45))
                    {
                        ship SH = new ship();
                        SH.Points.Add(new Point(x2, y2));
                        SH.Points.Add(new Point(x2, y2 + 15));
                        SH.Points.Add(new Point(x2, y2+30));
                        SH.Points.Add(new Point(x2, y2 + 45));


                        c_ships.Add(SH);

                        g2.FillRectangle(Brushes.Red, x2 + 1, y2 + 1, 14, 14);
                        g2.FillRectangle(Brushes.Red, x2 + 1, y2 + 16, 14, 14);
                        g2.FillRectangle(Brushes.Red, x2 + 1, y2 + 31, 14, 14);
                        g2.FillRectangle(Brushes.Red, x2 + 1, y2 + 46, 14, 14);

                        pictureBox2.Image = bmp2;


                    }

                }
                while (c_ships.Count < 2)
                {
                    Random rnd = new Random();
                    Random rnd2 = new Random();
                    Random rnd3 = new Random();

                    int x2 = rnd.Next(10) * 15 + 10;
                    int y2 = rnd2.Next(10) * 15 + 10;

                    int ya = rnd3.Next(2);
                    if (ya == 1)
                    {
                        if (ifShip2(x2, y2) && ifShip2(x2 + 15, y2) && ifShip2(x2 + 30, y2))
                        {
                            ship SH = new ship();
                            SH.Points.Add(new Point(x2, y2));
                            SH.Points.Add(new Point(x2 + 15, y2));
                            SH.Points.Add(new Point(x2 + 30, y2));

                            c_ships.Add(SH);


                            g2.FillRectangle(Brushes.Red, x2 + 1, y2 + 1, 14, 14);
                            g2.FillRectangle(Brushes.Red, x2 + 31, y2 + 1, 14, 14);
                            g2.FillRectangle(Brushes.Red, x2 + 16, y2 + 1, 14, 14);

                            pictureBox2.Image = bmp2;


                        }
                    }
                    else if (ifShip2(x2, y2) && ifShip2(x2, y2 + 15) && ifShip2(x2, y2 + 30))
                    {
                        ship SH = new ship();
                        SH.Points.Add(new Point(x2, y2));
                        SH.Points.Add(new Point(x2, y2 + 15));
                        SH.Points.Add(new Point(x2, y2 + 30));

                        c_ships.Add(SH);

                        g2.FillRectangle(Brushes.Red, x2 + 1, y2 + 1, 14, 14);
                        g2.FillRectangle(Brushes.Red, x2 + 1, y2 + 16, 14, 14);
                        g2.FillRectangle(Brushes.Red, x2 + 1, y2 + 31, 14, 14);

                        pictureBox2.Image = bmp2;


                    }
                }
                while (c_ships.Count < 4)
                {
                    Random rnd = new Random();
                    Random rnd2 = new Random();
                    Random rnd3 = new Random();

                    int x2 = rnd.Next(10) * 15 + 10;
                    int y2 = rnd2.Next(10) * 15 + 10;
                    int ya = 1; rnd3.Next(2);
                    if (ya == 1)
                    {
                        if (ifShip2(x2, y2) && ifShip2(x2 + 15, y2))
                        {
                            ship SH = new ship();
                            SH.Points.Add(new Point(x2, y2));
                            SH.Points.Add(new Point(x2 + 15, y2));

                            c_ships.Add(SH);

                            g2.FillRectangle(Brushes.Red, x2 + 1, y2 + 1, 14, 14);
                            g2.FillRectangle(Brushes.Red, x2 + 16, y2 + 1, 14, 14);

                            pictureBox2.Image = bmp2;


                        }
                    }
                    else if (ifShip2(x2, y2) && ifShip2(x2, y2 + 15))
                    {
                        ship SH = new ship();
                        SH.Points.Add(new Point(x2, y2));
                        SH.Points.Add(new Point(x2, y2 + 15));

                        c_ships.Add(SH);

                        g2.FillRectangle(Brushes.Red, x2 + 1, y2 + 1, 14, 14);
                        g2.FillRectangle(Brushes.Red, x2 + 1, y2 + 16, 14, 14);

                        pictureBox2.Image = bmp2;


                    }
                }
                while (c_ships.Count < 7)
                {
                    Random rnd = new Random();
                    Random rnd2 = new Random();

                    int x2 = rnd.Next(0, 9) * 15 + 10;
                    int y2 = rnd2.Next(0, 9) * 15 + 10;
                    if (ifShip2(x2, y2) && ifShip2(x2 + 15, y2) && ifShip2(x2 + 30, y2))
                    {
                        ship SH = new ship();
                        SH.Points.Add(new Point(x2, y2));

                        c_ships.Add(SH);

                        g2.FillRectangle(Brushes.Red, x2 + 1, y2 + 1, 14, 14);

                        pictureBox2.Image = bmp2;


                    }
                }
                start = true;
                turn = 1;
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }


        int cnt = 0;

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (start)
            {
                int x_ = e.Location.X;
                x_ -= (x_ - 10) % 15;

                int y_ = e.Location.Y;
                y_ -= (y_ - 10) % 15;


                if (turn == 1 && e.Location.X >= 10 && e.Location.X <= 160 && e.Location.Y >= 10 && e.Location.Y <= 160 && NotEmptyC(x_, y_))
                {
                    Strike(e.Location);
                    for (int i = 1; i < c_empty.Count; i++)
                    {
                        g2.FillEllipse(Brushes.Blue, c_empty[i].X + 6, c_empty[i].Y + 6, 4, 4);
                    }
                }

                if (turn == 0)
                {
                    Strike2();
                    for (int i = 1; i < pl_empty.Count; i++)
                    {
                        g.FillEllipse(Brushes.Blue, pl_empty[i].X + 6, pl_empty[i].Y + 6, 4, 4);
                    }
                    pictureBox1.Image = bmp;
                }
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Location.X >= 200 && e.Location.X <= 260 && e.Location.Y <= 25 && e.Location.Y >= 10 && cnt4>0)
            {
                drag = true;
                ShipType = shiptype.FH;
            }
            if (e.Location.X >= 200 && e.Location.X <= 245 && e.Location.Y <= 55 && e.Location.Y >= 40 && cnt3 > 0)
            {
                drag = true;
                ShipType = shiptype.THH;
            }
            if (e.Location.X >= 200 && e.Location.X <= 230 && e.Location.Y <= 85 && e.Location.Y >= 70 && cnt2 > 0)
            {
                drag = true;
                ShipType = shiptype.TWH;
            }
            if (e.Location.X >= 200 && e.Location.X <= 215 && e.Location.Y <= 115 && e.Location.Y >= 100 && cnt1 > 0)
            {
                drag = true;
                ShipType = shiptype.ONE;
            }
            if (e.Location.X >= 275 && e.Location.X <= 290 && e.Location.Y <= 70 && e.Location.Y >= 10 && cnt4 > 0)
            {
                drag = true;
                ShipType = shiptype.FV;
            }
            if (e.Location.X >= 305 && e.Location.X <= 320 && e.Location.Y <= 55 && e.Location.Y >= 10 && cnt3 > 0)
            {
                drag = true;
                ShipType = shiptype.THV;
            }
            if (e.Location.X >= 335 && e.Location.X <= 350 && e.Location.Y <= 40 && e.Location.Y >= 10 && cnt2 > 0)
            {
                drag = true;
                ShipType = shiptype.TWV;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag && ShipType == shiptype.THH)
            {
                if (ifShip(x1, y1) && ifShip(x1 + 15, y1) && ifShip(x1 + 30, y1))
                {
                    g.FillRectangle(Brushes.White, x1 + 1, y1 + 1, 14, 14);
                    g.FillRectangle(Brushes.White, x1 + 31, y1 + 1, 14, 14);
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
            if (drag && ShipType == shiptype.THV)
            {
                if (ifShip(x1, y1) && ifShip(x1 , y1+15) && ifShip(x1 , y1+30))
                {
                    g.FillRectangle(Brushes.White, x1 + 1, y1 + 1, 14, 14);
                    g.FillRectangle(Brushes.White, x1 + 1, y1 + 16, 14, 14);
                    g.FillRectangle(Brushes.White, x1 + 1, y1 + 31, 14, 14);
                }
                x1 = e.Location.X;
                y1 = e.Location.Y;
                x1 -= (x1 - 10) % 15;
                y1 -= (y1 - 10) % 15;
                if (ifShip(x1, y1) && ifShip(x1 , y1 + 15) && ifShip(x1 , y1+30))
                {
                    g.FillRectangle(Brushes.Red, x1 + 1, y1 + 1, 14, 14);
                    g.FillRectangle(Brushes.Red, x1 + 1, y1 + 16, 14, 14);
                    g.FillRectangle(Brushes.Red, x1 + 1, y1 + 31, 14, 14);
                }
                pictureBox1.Image = bmp;
            }

            if (drag && ShipType == shiptype.FV)
            {
                if (ifShip(x1, y1) && ifShip(x1, y1 + 15) && ifShip(x1, y1 + 30)&& ifShip(x1, y1 + 45))
                {
                    g.FillRectangle(Brushes.White, x1 + 1, y1 + 1, 14, 14);
                    g.FillRectangle(Brushes.White, x1 + 1, y1 + 16, 14, 14);
                    g.FillRectangle(Brushes.White, x1 + 1, y1 + 31, 14, 14);
                    g.FillRectangle(Brushes.White, x1 + 1, y1 + 46, 14, 14);
                }
                x1 = e.Location.X;
                y1 = e.Location.Y;
                x1 -= (x1 - 10) % 15;
                y1 -= (y1 - 10) % 15;
                if (ifShip(x1, y1) && ifShip(x1, y1 + 15) && ifShip(x1, y1 + 30) && ifShip(x1, y1 + 45))
                {
                    g.FillRectangle(Brushes.Red, x1 + 1, y1 + 1, 14, 14);
                    g.FillRectangle(Brushes.Red, x1 + 1, y1 + 16, 14, 14);
                    g.FillRectangle(Brushes.Red, x1 + 1, y1 + 31, 14, 14);
                    g.FillRectangle(Brushes.Red, x1 + 1, y1 + 46, 14, 14);
                }
                pictureBox1.Image = bmp;
            }
            if (drag && ShipType == shiptype.FH)
            {
                if (ifShip(x1, y1) && ifShip(x1 + 15, y1) && ifShip(x1 + 30, y1)&&ifShip(x1 + 45, y1))
                {
                    g.FillRectangle(Brushes.White, x1 + 1, y1 + 1, 14, 14);
                    g.FillRectangle(Brushes.White, x1 + 31, y1 + 1, 14, 14);
                    g.FillRectangle(Brushes.White, x1 + 16, y1 + 1, 14, 14);
                    g.FillRectangle(Brushes.White, x1 + 46, y1 + 1, 14, 14);
                }
                x1 = e.Location.X;
                y1 = e.Location.Y;
                x1 -= (x1 - 10) % 15;
                y1 -= (y1 - 10) % 15;
                if (ifShip(x1, y1) && ifShip(x1 + 15, y1) && ifShip(x1 + 30, y1) && ifShip(x1 + 45, y1))
                {
                    g.FillRectangle(Brushes.Red, x1 + 1, y1 + 1, 14, 14);
                    g.FillRectangle(Brushes.Red, x1 + 31, y1 + 1, 14, 14);
                    g.FillRectangle(Brushes.Red, x1 + 16, y1 + 1, 14, 14);
                    g.FillRectangle(Brushes.Red, x1 + 46, y1 + 1, 14, 14);
                }
                pictureBox1.Image = bmp;
            }

            if (drag && ShipType == shiptype.TWH)
            {
                if (ifShip(x1, y1) && ifShip(x1 + 15, y1) )
                {
                    g.FillRectangle(Brushes.White, x1 + 1, y1 + 1, 14, 14);
                    g.FillRectangle(Brushes.White, x1 + 16, y1 + 1, 14, 14);
                }
                x1 = e.Location.X;
                y1 = e.Location.Y;
                x1 -= (x1 - 10) % 15;
                y1 -= (y1 - 10) % 15;
                if (ifShip(x1, y1) && ifShip(x1 + 15, y1) )
                {
                    g.FillRectangle(Brushes.Red, x1 + 1, y1 + 1, 14, 14);
                    g.FillRectangle(Brushes.Red, x1 + 16, y1 + 1, 14, 14);
                }
                pictureBox1.Image = bmp;
            }

            if (drag && ShipType == shiptype.TWV)
            {
                if (ifShip(x1, y1) && ifShip(x1, y1 + 15) )
                {
                    g.FillRectangle(Brushes.White, x1 + 1, y1 + 1, 14, 14);
                    g.FillRectangle(Brushes.White, x1 + 1, y1 + 16, 14, 14);
                }
                x1 = e.Location.X;
                y1 = e.Location.Y;
                x1 -= (x1 - 10) % 15;
                y1 -= (y1 - 10) % 15;
                if (ifShip(x1, y1) && ifShip(x1, y1 + 15) )
                {
                    g.FillRectangle(Brushes.Red, x1 + 1, y1 + 1, 14, 14);
                    g.FillRectangle(Brushes.Red, x1 + 1, y1 + 16, 14, 14);
                }
                pictureBox1.Image = bmp;
            }
            if (drag && ShipType == shiptype.ONE)
            {
                if (ifShip(x1, y1) )
                {
                    g.FillRectangle(Brushes.White, x1 + 1, y1 + 1, 14, 14);
                }
                x1 = e.Location.X;
                y1 = e.Location.Y;
                x1 -= (x1 - 10) % 15;
                y1 -= (y1 - 10) % 15;
                if (ifShip(x1, y1))
                {
                    g.FillRectangle(Brushes.Red, x1 + 1, y1 + 1, 14, 14);
                }
                pictureBox1.Image = bmp;
            }

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (ShipType == shiptype.THH)
            {
                if (ifShip(x1, y1) && ifShip(x1 + 15, y1) && ifShip(x1 + 30, y1))
                {
                    ship SH = new ship();
                    SH.Points.Add(new Point(x1, y1));

                    SH.Points.Add(new Point(x1 + 15, y1));

                    SH.Points.Add(new Point(x1 + 30, y1));

                    pl_ships.Add(SH);
                    x1 = 200;
                    y1 = 200;

                    cnt3--;
                    drag = false;
                }
            }
            if (ShipType == shiptype.THV)
            {
                if (ifShip(x1, y1) && ifShip(x1 , y1+15) && ifShip(x1 , y1+ 30))
                {
                    ship SH = new ship();
                    SH.Points.Add(new Point(x1, y1));

                    SH.Points.Add(new Point(x1 , y1+15));

                    SH.Points.Add(new Point(x1 , y1+30));

                    pl_ships.Add(SH);
                    x1 = 200;
                    y1 = 200;

                    cnt3--;
                    drag = false;
                }
            }
            if (ShipType == shiptype.FH)
            {
                if (ifShip(x1, y1) && ifShip(x1 + 15, y1) && ifShip(x1 + 30, y1) && ifShip(x1 + 45, y1))
                {
                    ship SH = new ship();
                    SH.Points.Add(new Point(x1, y1));
                    SH.Points.Add(new Point(x1 + 15, y1));
                    SH.Points.Add(new Point(x1 + 30, y1));
                    SH.Points.Add(new Point(x1 + 45, y1));

                    pl_ships.Add(SH);
                    x1 = 200;
                    y1 = 200;

                    cnt4--;
                    drag = false;
                }
            }

            if (ShipType == shiptype.FV)
            {
                if (ifShip(x1, y1) && ifShip(x1, y1 + 15) && ifShip(x1, y1 + 30) && ifShip(x1, y1 + 45))
                {
                    ship SH = new ship();
                    SH.Points.Add(new Point(x1, y1));
                    SH.Points.Add(new Point(x1, y1 + 15));
                    SH.Points.Add(new Point(x1, y1 + 30));
                    SH.Points.Add(new Point(x1, y1 + 45));

                    pl_ships.Add(SH);
                    x1 = 200;
                    y1 = 200;

                    cnt4--;
                    drag = false;
                }
            }
            if (ShipType == shiptype.TWH)
            {
                if (ifShip(x1, y1) && ifShip(x1 + 15, y1) )
                {
                    ship SH = new ship();
                    SH.Points.Add(new Point(x1, y1));
                    SH.Points.Add(new Point(x1 + 15, y1));

                    pl_ships.Add(SH);
                    x1 = 200;
                    y1 = 200;

                    cnt2--;
                    drag = false;
                }
            }

            if (ShipType == shiptype.TWV)
            {
                if (ifShip(x1, y1) && ifShip(x1, y1 + 15) )
                {
                    ship SH = new ship();
                    SH.Points.Add(new Point(x1, y1));
                    SH.Points.Add(new Point(x1, y1 + 15));
                    pl_ships.Add(SH);
                    x1 = 200;
                    y1 = 200;

                    cnt2--;
                    drag = false;
                }
            }

            if (ShipType == shiptype.ONE)
            {
                if (ifShip(x1, y1) )
                {
                    ship SH = new ship();
                    SH.Points.Add(new Point(x1, y1));
                    pl_ships.Add(SH);
                    x1 = 200;
                    y1 = 200;

                    cnt1--;
                    drag = false;
                }
            }


            drag = false;
        }
    }
}
