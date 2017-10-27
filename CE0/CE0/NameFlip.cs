using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameFlip
{
    class NameFlip
    {
        static void Main(string[] args)
        {
            string FirstName;
            string LastName;
            Console.Write("Enter your last name: ");
            LastName = Console.ReadLine();

            Console.Write("Enter your first name: ");
            FirstName = Console.ReadLine();

            System.Console.WriteLine("\n Hello {0} {1}", FirstName, LastName);
            Console.ReadKey();
        }
    }
}
