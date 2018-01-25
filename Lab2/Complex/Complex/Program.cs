using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Complex
{
    class Complex
    {
        public int a, b;

        public Complex (int a, int b)
        {
            this.a = a;
            this.b = b;
        }
        public static Complex operator +(Complex c1, Complex c2)
        {
            Complex c3 = new Complex (0,0);

            c3.a = c1.a + c2.a;
            c3.b = c1.b+c2.b ;

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
            string s = Console.ReadLine();
            string[] token = s.Split();

            string[] arr1 = token[0].Split('/');

            string[] arr2 = token[1].Split('/'); 

            Complex cmp1 = new Complex(int.Parse(arr1[0]), int.Parse(arr1[1]));

            Complex cmp2 = new Complex(int.Parse(arr2[0]), int.Parse(arr2[1]));


            Complex cmp3 = cmp1 + cmp2;
            
            Console.WriteLine(cmp3);

            Console.ReadKey();

        }
    }
}
