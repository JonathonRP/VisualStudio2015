using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerryCE3
{
    class Program
    {
        static void Main( string [] args )
        {

            Part aPart = new Part();
            Part aPart2 = new Part();
            Part aPart3 = new Part( "PartY", .04, 1999 );

            Console.WriteLine( aPart.ToString() );

            aPart2.Name = "PartX";
            aPart2.CostPerPart = .175;
            aPart2.Quantity = 333;

            Console.WriteLine( aPart2.ToString() );

            Console.WriteLine( aPart3.ToString() );

            Console.ReadKey();

        }
    }
}
