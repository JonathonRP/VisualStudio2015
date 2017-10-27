using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Find_Digits
{
    class Program
    {
        static void Main( string [] args )
        {
            int t = Convert.ToInt32( Console.ReadLine() );

            int[] result = new int [t];

            for ( int a0 = 0; a0 < t; a0++ )
            {

                var ns = Console.ReadLine();
                var n = Convert.ToInt32( ns );

                result[a0] = ns.Select( t1 => Convert.ToInt32( "" + t1 ) )
                 .Count( x => x != 0 && n % x == 0 );
            }

            foreach ( var item in result )
            {
                Console.WriteLine( item );
            }
            Console.ReadKey();
        }
    }
}
