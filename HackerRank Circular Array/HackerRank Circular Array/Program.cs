using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HackerRank_Circular_Array
{
    class Program
    {

        static void Main( String [] args )
        {
            string [] tokens_n = Console.ReadLine().Split( ' ' );
            int n = Convert.ToInt32( tokens_n [0] );
            int k = Convert.ToInt32( tokens_n [1] );
            int q = Convert.ToInt32( tokens_n [2] );

            string [] a_temp = Console.ReadLine().Split( ' ' );
            int [] a = Array.ConvertAll( a_temp, Int32.Parse );

            int[] m = new int [q];

            for ( int a0 = 0; a0 < q; a0++ )
            {
                m[a0] = Convert.ToInt32( Console.ReadLine() );
            }

            for ( int i = 0; i < q; i++ )
            {
                Console.WriteLine( "{0}", a [ ( m[i] - ( k % n ) + n ) % n] );
            }

            Console.WriteLine( "press any key to exit" );
            Console.ReadKey();
        }
    }
}
