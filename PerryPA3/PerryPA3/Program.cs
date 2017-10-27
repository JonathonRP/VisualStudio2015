using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerryPA3
{
    class Program
    {
        static void Main( string [] args )
        {

            new Package().PrintShipping();

            new Package( 4, 5, 6, 1.5 ).PrintShipping();

            Console.ReadKey();
        }
    }
}
