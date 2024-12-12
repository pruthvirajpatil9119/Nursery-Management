using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            float i, fact=1, n;
            Console.WriteLine("enter no to calculate fact: ");
            n = Convert.ToInt32(Console.ReadLine());
            for (i = 1; i <= n; i++)
            {
                fact = fact * i;

            }
            Console.WriteLine("the factorial is: "+fact);
            Console.ReadKey();

        }
    }
}
