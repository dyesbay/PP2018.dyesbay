using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace bot_for_snake
{
    [Serializable]
    public class Point
    {
        public int x, y;

        public Point()
        {

        }
        public Point(int a, int b)
        {
            x = a;
            y = b;
        }
    }

    [Serializable]
    public class eda
    {
        public Point place;

        public eda()
        {

        }
        public eda (Point p)
        {
            place = p;
        }
        public eda(Snake sn, stena wl)
        {
            bool a = true;
            Random rnd = new Random();
            int _x = rnd.Next(0, Console.WindowWidth);
            int _y = rnd.Next(0, 23);
            while (a)
            {
                _x = rnd.Next(0, Console.WindowWidth);
                _y = rnd.Next(0, 23);
                a = false;
                foreach (Point crd in sn.body)
                {
                    if (_x == crd.x && _y == crd.y)
                    {
                        a = true;
                        break;
                    }
                }
                foreach (Point pnt in wl.wall)
                {
                    if (_x == pnt.x && _y == pnt.y)
                    {
                        a = true;
                        break;
                    }
                }
            }
            Point _place = new Point(_x, _y);
            place = _place;
        }
        public void generate(Snake sn, stena wl) //генерирует еду в новом месте
        {
            bool a = true;
            Random rnd = new Random();
            int _x = rnd.Next(0, Console.WindowWidth);
            int _y = rnd.Next(0, 23);

            while (a)
            {
                _x = rnd.Next(0, Console.WindowWidth);
                _y = rnd.Next(0, 23);
                a = false;
                foreach (Point crd in sn.body)
                {
                    if (_x == crd.x && _y == crd.y)
                    {
                        a = true;
                        break;
                    }
                }
                foreach (Point pnt in wl.wall)
                {
                    if (_x == pnt.x && _y == pnt.y)
                    {
                        a = true;
                        break;
                    }
                }
            }
            place.x = _x;
            place.y = _y;
        }
        public void draw() //рисует еду
        {
            Console.SetCursorPosition(place.x, place.y);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write('*');
            Console.ForegroundColor = ConsoleColor.White;
        }
    }



    [Serializable]
    public class Snake
    {
        public List<Point> body;

        public string direction = "Right";

        //public ConsoleKeyInfo LastKey = new ConsoleKeyInfo('a', ConsoleKey.RightArrow, false, false, false) ;

        public Snake()
        {

        }

        public Snake(List<Point> _body)

        {

            body = _body;
        }

        public void move() // змейка движется
        {
            if (direction == "Right")//LastKey.Key == ConsoleKey.RightArrow)
            {
                for (int i = body.Count - 1; i >= 1; i--)
                {
                    body[i].x = body[i - 1].x;
                    body[i].y = body[i - 1].y;
                }
                body[0].x = body[0].x + 1;

            }
            if (direction == "Left")//LastKey.Key == ConsoleKey.LeftArrow)
            {
                for (int i = body.Count - 1; i >= 1; i--)
                {
                    body[i].x = body[i - 1].x;
                    body[i].y = body[i - 1].y;
                }
                body[0].x--;

            }
            if (direction == "Up")//LastKey.Key == ConsoleKey.UpArrow)
            {
                for (int i = body.Count - 1; i >= 1; i--)
                {

                    body[i].x = body[i - 1].x;
                    body[i].y = body[i - 1].y;
                }
                body[0].y--;

            }

            if (direction == "Down")//LastKey.Key == ConsoleKey.DownArrow)
            {
                for (int i = body.Count - 1; i >= 1; i--)
                {

                    body[i].x = body[i - 1].x;
                    body[i].y = body[i - 1].y;
                }
                body[0].y++;

            }
            if (body[0].x >= Console.BufferWidth)
                body[0].x = 0;

            if (body[0].x < 0)
                body[0].x = Console.BufferWidth - 1;
            if (body[0].y >= 23)
                body[0].y = 0;

            if (body[0].y < 0)
                body[0].y = 22;

        }

        public void draw() //рисует змею
        {

            /*Console.SetCursorPosition(0, 0);
            foreach (Point crd in this.body)
            {
                Console.WriteLine(crd.x);
                Console.WriteLine(crd.y);
            }*/
            foreach (Point crd in this.body)
            {
                Console.SetCursorPosition(crd.x, crd.y);

                Console.Write('O');
            }
            Console.SetCursorPosition(body[0].x, body[0].y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write('O');
            Console.ForegroundColor = ConsoleColor.White;


        }
        public void clear()
        {
            foreach (Point crd in this.body)
            {
                Console.SetCursorPosition(crd.x, crd.y);

                Console.Write(' ');
            }
            Console.SetCursorPosition(body[0].x, body[0].y);
        }
        public void grow() // увеличивает змейку
        {
            Point n = new Point(body[body.Count - 1].x, body[body.Count - 1].y);
            body.Add(n);
        }

        public bool Collides() // проверяет не ест ли змейка себя
        {
            for (int i = 1; i < body.Count; i++)
            {
                if (body[i].x == body[0].x && body[i].y == body[0].y)
                    return true;

            }
            return false;
        }
        public bool Collides(stena a) // проверяет на столкновение со стеной
        {
            foreach (Point pnt in a.wall)
            {
                if (body[0].x == pnt.x && body[0].y == pnt.y)
                    return true;
            }
            return false;
        }

        public int getdir()
        {
            if (body[0].x == body[1].x+ 1)
                return 6;
            if (body[0].x == body[1].x- 1)
                return 4;

            if (body[0].y == body[1].y - 1)
                return 2;

            if (body[0].y == body[1].y + 1)
                return 8;
            return 0;
        }




    }

    [Serializable]
    public class stena //класс стены
    {
        public List<Point> wall;
        public stena()
        {

        }
        public stena (List<Point> l)
        {
            wall = l;
        }
        public stena(string s) //считывает стенку со стринга
        {
            List<Point> w = new List<Point>();
            string[] one = s.Split('\n');
            for (int i = 0; i < one.Length; i++)
            {
                for (int j = 0; j < one[i].Length; j++)
                    if (one[i][j] == '#')

                    {
                        Point r = new Point(j, i);
                        w.Add(r);
                    }
            }
            wall = w;
        }
        public void draw()
        {
            foreach (Point pnt in wall)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(pnt.x, pnt.y);
                Console.Write('#');
                Console.ForegroundColor = ConsoleColor.White;
            }
        }


    }

    class Program
    {
        static int RoadToFood (Point head, eda havka)
        {
            int xr, xl;
            if (havka.place.x >= head.x)
            {
                xr = havka.place.x - head.x;
                xl = Console.BufferWidth - xr;
            }
            else
            {
                xl = head.x - havka.place.x;
                xr = Console.BufferWidth - xl;
            }
            int yr, yl;
            if (havka.place.y >= head.y)
            {
                yr = havka.place.y - head.y;
                yl = Console.BufferWidth - yr;
            }
            else
            {
                yl = head.y - havka.place.y;
                yr = Console.BufferWidth - yl;
            }
            int a = Math.Min(xl, xr) + Math.Min(yr, yl);
            return a;

        } 

        static void Main(string[] args)
        {
            while (true)
            {
                // чтение змей, стены и еды
                StreamReader sr = new StreamReader("snake1.txt");
                List<Point> snake_b1 = new List<Point>();
                List<Point> snake_b2 = new List<Point>();

                string s = sr.ReadLine();
                int n = int.Parse(s);
                for (int i = 0; i < n; i++)
                {
                    s = sr.ReadLine();
                    string[] a = s.Split();
                    int x1 = int.Parse(a[0]);

                    int y1 = int.Parse(a[1]);
                    Point p1 = new Point(x1, y1);
                    snake_b1.Add(p1);
                }
                StreamReader sr2 = new StreamReader("snake2.txt");
                s = sr2.ReadLine();
                n = int.Parse(s);
                for (int i = 0; i < n; i++)
                {
                    s = sr2.ReadLine();
                    string[] a = s.Split();
                    int x1 = int.Parse(a[0]);

                    int y1 = int.Parse(a[1]);
                    Point p1 = new Point(x1, y1);
                    snake_b2.Add(p1);
                }
                Snake snake1 = new Snake(snake_b1);
                Snake snake2 = new Snake(snake_b2);
                StreamReader sr3 = new StreamReader("wall.txt");
                s = sr3.ReadLine();
                n = int.Parse(s);
                List<Point> w = new List<Point>();
                for (int i = 0; i < n; i++)
                {
                    s = sr3.ReadLine();
                    string[] a = s.Split();
                    int x1 = int.Parse(a[0]);

                    int y1 = int.Parse(a[1]);
                    Point p1 = new Point(x1, y1);
                    w.Add(p1);
                }
                stena Wall = new stena(w);

                StreamReader sr4 = new StreamReader("food.txt");
                s = sr4.ReadLine();
                string[] a1 = s.Split();
                int x2 = int.Parse(a1[0]);

                int y2 = int.Parse(a1[1]);
                Point p = new Point(x2, y2);
                eda Food = new eda(p);

                int direction = snake1.getdir();
                int direction6, direction8, direction4 , direction2;

                Point head = snake1.body[0];
                head.x++;
                direction6 = RoadToFood(head, Food);

                head = snake1.body[0];
                head.x--;
                direction4 = RoadToFood(head, Food);

                head = snake1.body[0];
                head.y++;
                direction2 = RoadToFood(head, Food);

                head = snake1.body[0];
                head.y--;
                direction8 = RoadToFood(head, Food);
                if (snake1.getdir() == 4)
                {
                    int m = Math.Min( Math.Min(direction8,direction6), direction2);
                    if ( m== direction2)
                    {
                        direction = 2;
                    }
                    if (m == direction6)
                    {
                        direction = 6;
                    }
                    if (m == direction8)
                    {
                        direction = 8;
                    }

                }
                if (snake1.getdir() == 6)
                {
                    int m = Math.Min(Math.Min(direction8, direction6), direction4);
                    if (m == direction2)
                    {
                        direction = 2;
                    }
                    if (m == direction4)
                    {
                        direction = 4;
                    }
                    if (m == direction8)
                    {
                        direction = 8;
                    }

                }
                if (snake1.getdir() == 8)
                {
                    int m = Math.Min(Math.Min(direction4, direction6), direction2);
                    if (m == direction2)
                    {
                        direction = 2;
                    }
                    if (m == direction6)
                    {
                        direction = 6;
                    }
                    if (m == direction4)
                    {
                        direction = 4;
                    }

                }
                if (snake1.getdir() == 2)
                {
                    int m = Math.Min(Math.Min(direction8, direction6), direction4);
                    if (m == direction4)
                    {
                        direction = 4;
                    }
                    if (m == direction6)
                    {
                        direction = 6;
                    }
                    if (m == direction8)
                    {
                        direction = 8;
                    }

                }
                

                int dirx = 0, diry = 0;
                if (direction == 2)
                    diry++;
                if (direction == 4)
                    dirx--;
                if (direction == 6)
                    dirx++;
                if (direction == 8)
                    diry--;
                StreamWriter sw = new StreamWriter("direction1.txt");
                sw.WriteLine(dirx);
                sw.WriteLine(diry);
                sw.Close();

            }


        }
    }
}
