using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE1
{
    class Program
    {
        static void Main(string[] args)
        {
            double cash = .17;
            int crystals;
                Console.Write("Enter the amount of Golden Crystals to purchase: ");
            crystals = int.Parse(System.Console.ReadLine());
                Console.Write("Your cost is {0:C}", cash * crystals);
            Console.ReadKey();
        }
    }
}
