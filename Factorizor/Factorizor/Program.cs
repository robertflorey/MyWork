using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor
{
    class Program
    {
        static void Main(string[] args)
        {
            string userFactor;
            int factor;
            int i;
            Console.WriteLine("What number would you like to factor?");
            userFactor = Console.ReadLine();
            int.TryParse(userFactor, out factor);
            int total = 0;
            int count = 1;

            for (i = 1; i < factor; i++)
            {
                if (factor % i == 0)
                    {
                    
                    Console.WriteLine("{0}", i);
                    total = total + i;
                    count = ++count;
                    }
            }
            if (total == factor)
            {
                Console.WriteLine("{0} is a perfect number.", factor);
            }
            if (total == 1)
            {
                Console.WriteLine("{0} is a prime number.", factor);
            }
            else
            {
                Console.WriteLine("{0} is not a prime number.", factor);
            }
            Console.WriteLine("{0} has {1} factors.", factor, count);
            Console.ReadKey();
            return;
            
        }
    }
}
