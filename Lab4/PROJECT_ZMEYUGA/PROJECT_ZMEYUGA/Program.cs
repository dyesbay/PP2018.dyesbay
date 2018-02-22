using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Xml.Serialization;

namespace PROJECT_ZMEYUGA
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
        public eda (Snake sn, stena wl)
        {
            bool a = true;
            Random rnd = new Random();
            int _x  = rnd.Next(0, Console.WindowWidth);
            int _y = rnd.Next(0, 23);
            while (a)
            {
                _x = rnd.Next(0, Console.WindowWidth);
                _y = rnd.Next(0, 23);
                a = false;
                foreach (Point crd in sn.body)
                {
                    if (_x==crd.x && _y == crd.y)
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
        public void generate (Snake sn, stena wl) //генерирует еду в новом месте
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
        public void draw () //рисует еду
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

        public Snake (List<Point> _body)

        {
            
            body = _body;
        }

        public void move() // змейка движется
        {
            if (direction== "Right")//LastKey.Key == ConsoleKey.RightArrow)
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

            if (body[0].x <0 )
                body[0].x = Console.BufferWidth-1;
            if (body[0].y >= 23)
                body[0].y = 0;

            if (body[0].y < 0)
                body[0].y = 22;

        }

        public void draw () //рисует змею
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
        public void grow() // увеличивает змейку
        {
            Point n = new Point(body[body.Count - 1].x, body[body.Count - 1].y);
            body.Add(n);
        }

        public bool Collides() // проверяет не ест ли змейка себя
        {
            for (int i = 1; i <body.Count; i++)
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




    }

    [Serializable]
    public class stena //класс стены
    {
        public List<Point> wall;
        public stena()
        {

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
                Console.SetCursorPosition(pnt.x,pnt.y);
                Console.Write('#');
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
         

    }
    class Program
    {
        const int reso = 23;


        static ConsoleKeyInfo Pressed = new ConsoleKeyInfo();
        static void func() // функция для треда: параллельно читает клавиши
        {
            while (true)
            {
                Pressed = Console.ReadKey();
            }
        }

        static int speed = 150;

        static void menu()
        {
            int cursor = 0;
            List<string> lines = new List<string>();
            lines.Add("continue");
            lines.Add("new game");
            lines.Add("save");
            lines.Add("speed: <medium>");
            lines.Add("exit");
            ConsoleKeyInfo button = new ConsoleKeyInfo();
            Console.Clear();
            if (speed == 150)
                lines[3] = "speed: <medium>";

            if (speed == 75)
                lines[3] = "speed: <fast>";

            if (speed == 250)
                lines[3] = "speed: <slow>";
            while (true)
            {
                Console.Clear();

                if (speed == 150)
                    lines[3] = "speed: <medium>";

                if (speed == 75)
                    lines[3] = "speed: <fast>";

                if (speed == 250)
                    lines[3] = "speed: <slow>";

                for (int i=0; i < lines.Count; i++)

                {
                    Console.SetCursorPosition(35, 10 + i);
                    if (i == cursor)
                        Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine(lines[i]);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                button = Console.ReadKey();
                if (button.Key == ConsoleKey.DownArrow && cursor < lines.Count - 1)
                    cursor++;
                if (button.Key == ConsoleKey.UpArrow && cursor >0)
                    cursor--;
                if (button.Key == ConsoleKey.Enter)
                {
                    if (cursor == 0)
                        break;
                    if (cursor == 2)
                    {
                        StreamWriter sw = new StreamWriter("oldsnake.xml");
                        sw.Write(' ');
                        sw.Close();
                        StreamWriter swe = new StreamWriter("food.xml");
                        swe.Write(' ');
                        swe.Close();
                        using (FileStream fs2 = new FileStream("oldsnake.xml", FileMode.OpenOrCreate))
                        {
                            snfrm.Serialize(fs2, Cobra);
                        }
                        using (FileStream fse = new FileStream("food.xml", FileMode.OpenOrCreate))
                        {
                            edafrm.Serialize(fse, korm);

                        }
                    }
                    if (cursor == 4)
                    {
                        stop = true;
                    }

                }
                if (cursor == 3)
                {
                    if (button.Key == ConsoleKey.LeftArrow)
                    {
                        if (speed == 150)
                            speed = 250;
                        if (speed == 75)
                            speed = 150;

                    }
                    if (button.Key == ConsoleKey.RightArrow)
                    {
                        if (speed == 150)
                            speed = 75;
                        if (speed == 250)
                            speed = 150;

                    }
                }
            }
            
        }
        static bool stop= false;
        static Snake Cobra;
        static eda korm;
        static XmlSerializer snfrm = new XmlSerializer(typeof(Snake));
        static XmlSerializer edafrm = new XmlSerializer(typeof(eda));

        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.BufferWidth, reso);

            List<Point> cheshuya = new List<Point>();
            for (int i = 0; i <5; i++)
            {
                Point a = new Point(35-i, 10);
                cheshuya.Add(a);
            }

            Cobra = new Snake(cheshuya/*, Pressed*/);

            StreamReader sr = new StreamReader("wall.txt");

            string s = sr.ReadToEnd();

            stena beton = new stena(s);

            korm = new eda(Cobra, beton);

            
            //интерфейс для загрузки игры
            Console.WriteLine("Do you want to continue from the last save? (y/n)");
            while (true)
            {
                Pressed = Console.ReadKey();
                if (Pressed.Key == ConsoleKey.Y)
                {
                    using (FileStream fs = new FileStream("oldsnake.xml", FileMode.OpenOrCreate))
                    {
                        Cobra = (Snake)snfrm.Deserialize(fs);
                    }
                    using (FileStream fse = new FileStream("food.xml", FileMode.OpenOrCreate))
                    {
                        korm = (eda)edafrm.Deserialize(fse);

                    }
                    break;
                }
                if (Pressed.Key == ConsoleKey.N)
                    break;
            }        
            
            using (FileStream fs1 = new FileStream("snake.xml", FileMode.OpenOrCreate))
            {
                snfrm.Serialize(fs1, Cobra);
                
            }
            Thread thrd = new Thread(func);
            thrd.Start();
            
            while (true)
            {
                Console.Clear();
                Cobra.draw();
                korm.draw();
                beton.draw();
                if (Cobra.Collides() || Cobra.Collides(beton))
                {
                    thrd.Abort();
                    Console.SetCursorPosition(Cobra.body[0].x, Cobra.body[0].y);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write('X');
                    Console.ForegroundColor = ConsoleColor.White;
                    //Console.ReadKey();

                    break;
                }
                /*if (Pressed.Key == ConsoleKey.S)//сохранение текущего состояния
                {
                    StreamWriter sw= new StreamWriter("oldsnake.xml");
                    sw.Write(' ');
                    sw.Close();
                    StreamWriter swe = new StreamWriter("food.xml");
                    swe.Write(' ');
                    swe.Close();
                    using (FileStream fs2 = new FileStream("oldsnake.xml", FileMode.OpenOrCreate))
                    {
                        snfrm.Serialize(fs2, Cobra);
                    }
                    using (FileStream fse = new FileStream("food.xml", FileMode.OpenOrCreate))
                    {
                        edafrm.Serialize(fse, korm);

                    }


                }*/
                if (( Cobra.direction == "Right" || Cobra.direction == "Left")/* Cobra.LastKey.Key == ConsoleKey.RightArrow || Cobra.LastKey.Key == ConsoleKey.LeftArrow)*/ && Pressed.Key == ConsoleKey.UpArrow )
                {
                    Cobra.direction = "Up";
                }
                if ((Cobra.direction == "Right" || Cobra.direction == "Left")/* Cobra.LastKey.Key == ConsoleKey.RightArrow || Cobra.LastKey.Key == ConsoleKey.LeftArrow)*/ && Pressed.Key == ConsoleKey.DownArrow)
                {
                    Cobra.direction = "Down";
                }
                if ((Cobra.direction == "Up" || Cobra.direction == "Down")/* Cobra.LastKey.Key == ConsoleKey.RightArrow || Cobra.LastKey.Key == ConsoleKey.LeftArrow)*/ && Pressed.Key == ConsoleKey.LeftArrow)
                {
                    Cobra.direction = "Left";
                }
                if ((Cobra.direction == "Up" || Cobra.direction == "Down")/* Cobra.LastKey.Key == ConsoleKey.RightArrow || Cobra.LastKey.Key == ConsoleKey.LeftArrow)*/ && Pressed.Key == ConsoleKey.RightArrow)
                {
                    Cobra.direction = "Right";
                }
                /*if ((Pressed.Key == ConsoleKey.RightArrow || Pressed.Key == ConsoleKey.LeftArrow) && (Cobra.LastKey.Key == ConsoleKey.UpArrow || Cobra.LastKey.Key == ConsoleKey.DownArrow))
                {
                    Cobra.LastKey = Pressed;
                }
                Cobra.LastKey = Pressed;*/
                if (Pressed.Key == ConsoleKey.Escape)//выход, потом прикручу меню
                {
                    // menu();
                    thrd.Abort();
                    menu();
                    if (stop)
                        break;

                    thrd = new Thread(func);
                    thrd.Start();
                    Pressed = new ConsoleKeyInfo('a', ConsoleKey.Spacebar, false,false,false);
                    //break;
                    
                }
                Cobra.move();

                //змея ест еду
                if (Cobra.body[0].x == korm.place.x && Cobra.body[0].y == korm.place.y)
                {
                    Cobra.grow();
                    korm.generate(Cobra, beton);

                }
                
                Thread.Sleep(speed);

            }
        }
    }
}
