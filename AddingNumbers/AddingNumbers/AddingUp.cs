using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddingNumbers
{
    class AddingUp
    {
        static void Main(string[] args)
        {
            Double x, y, z, a;

            Console.Write("Enter your first number: ");
            x = Double.Parse(System.Console.ReadLine());

            Console.Write("Enter your second number: ");
            y = Double.Parse(System.Console.ReadLine());

            Console.Write("Enter your third number: ");
            z = Double.Parse(System.Console.ReadLine());

            Console.Write("Enter your last number: ");
            a = Double.Parse(System.Console.ReadLine());

            Console.WriteLine("\nYour average is {0}", x + y + z + a / 4);
            Console.ReadKey();
        }
    }
}
