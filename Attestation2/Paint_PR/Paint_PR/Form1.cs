using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint_PR
{
    public partial class Form1 : Form
    {
        Graphics g;
        Bitmap bmp;

        enum Tool
        {
            PEN,
            RECTANGLE,
            TRIANGLE,
            LINE,
            ELLIPSE,
            BRUSH,
        };
        


        Pen pen;
        int thickness;

        Tool tool = Tool.PEN;

        Point before, after;

        bool clicked;

        Queue<Point> q = new Queue<Point>();

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            thickness = 1;
            pen = new Pen(Color.Black, thickness);
            pictureBox1.Image = bmp;
            clicked = false;
        }

        public void Fill(int x, int y, Color color, Color selfcolor)
        {
            if (bmp.GetPixel(x, y) == selfcolor)
            {
                bmp.SetPixel(x, y, color);
                Fill(x + 1, y, color, selfcolor);
                Fill(x - 1, y, color, selfcolor);
                Fill(x, y + 1, color, selfcolor);
                Fill(x, y - 1, color, selfcolor);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            clicked = true;
            before = e.Location;
            if (tool == Tool.BRUSH)
            {
                Color color = bmp.GetPixel(e.X, e.Y);
                q.Enqueue(e.Location);
                Point p;
                int a, b, c, d;
                while (q.Count != 0)
                {
                    p = q.Dequeue();
                    bmp.SetPixel(p.X, p.Y, pen.Color);
                    a = p.X + 1;
                    b = p.X - 1;
                    c = p.Y + 1;
                    d = p.Y - 1;
                    if (bmp.GetPixel(a, p.Y) == color && !q.Contains(new Point(a, p.Y)) && a != pictureBox1.Width - 1) q.Enqueue(new Point(a, p.Y));
                    if (bmp.GetPixel(b, p.Y) == color && !q.Contains(new Point(b, p.Y)) && b != 0) q.Enqueue(new Point(b, p.Y));
                    if (bmp.GetPixel(p.X, c) == color && !q.Contains(new Point(p.X, c)) && c != pictureBox1.Height - 1) q.Enqueue(new Point(p.X, c));
                    if (bmp.GetPixel(p.X, d) == color && !q.Contains(new Point(p.X, d)) && d != 0) q.Enqueue(new Point(p.X, d));
                }
                pictureBox1.Refresh();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            clicked = false;
            switch (tool)
            {
                case Tool.LINE:
                    g.DrawLine(pen, before, after);
                    break;
                case Tool.RECTANGLE:
                    g.DrawRectangle(pen, new Rectangle(Math.Min(before.X, after.X), Math.Min(before.Y, after.Y), Math.Abs(after.X - before.X), Math.Abs(after.Y - before.Y)));
                    break;
                case Tool.ELLIPSE:
                    g.DrawEllipse(pen, new Rectangle(Math.Min(before.X, after.X), Math.Min(before.Y, after.Y), Math.Abs(after.X - before.X), Math.Abs(after.Y - before.Y)));
                    break;
                case Tool.TRIANGLE:
                    g.DrawLine(pen, (before.X + after.X) / 2, Math.Min(before.Y, after.Y), Math.Min(before.X, after.X), Math.Max(before.Y, after.Y));
                    g.DrawLine(pen, (before.X + after.X) / 2, Math.Min(before.Y, after.Y), Math.Max(before.X, after.X), Math.Max(before.Y, after.Y));
                    g.DrawLine(pen, Math.Min(before.X, after.X), Math.Max(before.Y, after.Y), Math.Max(before.X, after.X), Math.Max(before.Y, after.Y));
                    break;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            after = e.Location;
            if (clicked == true)
            {
                switch (tool)
                {
                    case Tool.PEN:
                        g.DrawLine(pen, before, after);
                        before = after;
                        break;
                }
                pictureBox1.Refresh();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics p = e.Graphics;
            switch (tool)
            {
                case Tool.LINE:
                    p.DrawLine(pen, before, after);
                    break;
                case Tool.RECTANGLE:
                    p.DrawRectangle(pen, new Rectangle(Math.Min(before.X, after.X), Math.Min(before.Y, after.Y), Math.Abs(after.X - before.X), Math.Abs(after.Y - before.Y)));
                    break;
                case Tool.ELLIPSE:
                    p.DrawEllipse(pen, new Rectangle(Math.Min(before.X, after.X), Math.Min(before.Y, after.Y), Math.Abs(after.X - before.X), Math.Abs(after.Y - before.Y)));
                    break;
                case Tool.TRIANGLE:
                    p.DrawLine(pen, (before.X + after.X) / 2, Math.Min(before.Y, after.Y), Math.Min(before.X, after.X), Math.Max(before.Y, after.Y));
                    p.DrawLine(pen, (before.X + after.X) / 2, Math.Min(before.Y, after.Y), Math.Max(before.X, after.X), Math.Max(before.Y, after.Y));
                    p.DrawLine(pen, Math.Min(before.X, after.X), Math.Max(before.Y, after.Y), Math.Max(before.X, after.X), Math.Max(before.Y, after.Y));
                    break;
            }
        }

       

        private void tencolors_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            pen.Color = b.BackColor;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "1":
                    thickness = 1;
                    break;
                case "2":
                    thickness = 3;
                    break;
                case "3":
                    thickness = 5;
                    break;
                case "4":
                    thickness = 7;
                    break;
                case "5":
                    thickness = 9;
                    break;
            }
            pen.Width = thickness;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            pictureBox1.Refresh();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bmp.Save(saveFileDialog1.FileName);
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bmp = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Refresh();
                pictureBox1.Image = bmp;
                g = Graphics.FromImage(bmp);
            }
        }

        private void tool_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            switch (b.Text)
            {
                case "Линия":
                    tool = Tool.LINE;
                    break;
                case "Прямоугольник":
                    tool = Tool.RECTANGLE;
                    break;
                case "Элипс":
                    tool = Tool.ELLIPSE;
                    break;
                case "Треугольник":
                    tool = Tool.TRIANGLE;
                    break;
                case "Карандаш":
                    tool = Tool.PEN;
                    break;
                case "Заливка":
                    tool = Tool.BRUSH;
                    break;
            }
        }

    }
}
