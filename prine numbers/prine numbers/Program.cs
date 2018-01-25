using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prine_numbers
{
    class Program
    {

        static bool ifPrime (int n)
        {
            if (n == 1)
                return false;
            for (int i = 2; i < n; i++)
                if (n % i == 0)
                    return false;
            return true;

        }
        static void Main(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (ifPrime(int.Parse(args[i])))
                    Console.WriteLine(args[i]);
            }

            Console.ReadKey();

        }
    }
}
