using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT_ZMEYUGA
{

    class Point
    {
        public int x, y;

        public Point(int a, int b)
        {
            x = a;
            y = b;
        }
    }
    class Snake
    {
        public List<Point> body;

        public ConsoleKeyInfo LastKey;

        public Snake (List<Point> _body, ConsoleKeyInfo k)

        {
            LastKey = k;
            body = _body;
        }

        public void move()
        {
            if (LastKey.Key == ConsoleKey.RightArrow)
            {
                for (int i = body.Count - 1; i >= 1; i--)
                {
                    body[i] = body[i - 1];
                }
                body[0].x++;

            }
            if (LastKey.Key == ConsoleKey.LeftArrow)
            {
                for (int i = body.Count - 1; i >= 1; i--)
                {
                    body[i] = body[i - 1];
                }
                body[0].x--;

            }
        }

             
    }
    class Program
    {

        static void Main(string[] args)
        {
        }
    }
}
