using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
         static bool ifPrime(int n)
        {
            for (int i = 2; i < n; i++)
                if (n % i == 0)
                    return false;
            return true;
        }
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            string s = sr.ReadLine();
            StreamWriter sw = new StreamWriter("output.txt");
            string[] a = s.Split(' ');
            int mini = int.Parse(a[0]);
            int maxi = mini;
            int minprime=0;
            for (int i =1; i< a.Length; i++)
            {
                if (int.Parse(a[i]) > maxi)
                    maxi = int.Parse(a[i]);
                if (int.Parse(a[i]) <mini)
                    mini = int.Parse(a[i]);
                if ((ifPrime(int.Parse(a[i]))) && ((int.Parse(a[i]) < minprime) || (minprime == 0)))
                    minprime = int.Parse(a[i]);
                

            }

            sw.WriteLine(mini);
            sw.WriteLine(maxi);
            sw.WriteLine(minprime);
            sw.Close();

        }
    }
}
