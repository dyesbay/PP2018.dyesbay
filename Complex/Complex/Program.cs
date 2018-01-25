using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex
{
    class Complex
    {
        int a, b;

        public Complex {
            }
        public Complex (int a, int b)
        {
            this.a = a;
            this.b = b;
        }
        public static Complex operator +(Complex c1, Complex c2)
        {
            Complex c3;

            c3.a = c1.a + c2.a;
            c3.b = c1.b+c2.b;

            return c3;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string[] arr = s.Split(' ');

            Complex z(int.Parse(s[0])
        }
    }
}
