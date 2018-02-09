using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Complex
{
    class Complex
    {
        public int a, b;


        public static int gcd (int a, int b)
        {
            int g=1;
            for (int i= 2; i <= Math.Min(a,b); i++)
            {
                if (a%i== 0 && b% i == 0)
                {
                    g = i;
                }
            }
            return g;
        }
        public static Complex sokr (Complex c)
        {
            int temp = gcd(c.a, c.b);
            c.a /= temp;
            c.b /= temp;
            return c;
        }

        public Complex (int a, int b)
        {
            this.a = a;
            this.b = b;
        }
        public static Complex operator +(Complex c1, Complex c2)
        {
            Complex c3 = new Complex (0,0);

            c3.a = c1.a*c2.b/gcd(c1.b, c2.b) + c2.a*c1.b/ gcd(c1.b, c2.b);
            c3.b = c1.b*c2.b/ gcd(c1.b, c2.b);
            sokr(c3);

            return c3;
        }
        public static Complex operator -(Complex c1, Complex c2)
        {
            Complex c3 = new Complex(0, 0);

            c3.a = c1.a * c2.b / gcd(c1.b, c2.b) - c2.a * c1.b / gcd(c1.b, c2.b);
            c3.b = c1.b * c2.b / gcd(c1.b, c2.b);
            sokr(c3);
            
            return c3;
        }
        public static Complex operator *(Complex c1, Complex c2)
        {
            Complex c3 = new Complex(0, 0);

            c3.a = c1.a * c2.a ;
            c3.b = c1.b * c2.b;
            sokr(c3);

            return c3;
        }
        public static Complex operator /(Complex c1, Complex c2)
        {
            Complex c3 = new Complex(0, 0);

            c3.a = c1.a * c2.b;
            c3.b = c1.b * c2.a;
            sokr(c3);

            return c3;
        }

        public override string ToString()
        {
            string value = a + "/" + b;
            return value;

        }



    }
    

    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("in.txt");
             
            string s = sr.ReadLine();

            StreamWriter sw = new StreamWriter("o.txt");
            string[] token = s.Split();

            string[] arr1 = token[0].Split('/');

            string[] arr2 = token[1].Split('/'); 

            Complex cmp1 = new Complex(int.Parse(arr1[0]), int.Parse(arr1[1]));

            Complex cmp2 = new Complex(int.Parse(arr2[0]), int.Parse(arr2[1]));


            Complex cmp3 = cmp1 + cmp2;

            Complex cmp4 = cmp1 - cmp2;
            Complex cmp5 = cmp1 * cmp2;
            Complex cmp6 = cmp1 / cmp2;
            sw.WriteLine(cmp3);
            sw.WriteLine(cmp4);
            sw.WriteLine(cmp5);
            sw.WriteLine(cmp6);
            sw.Close();
            Console.ReadKey();

        }
    }
}
