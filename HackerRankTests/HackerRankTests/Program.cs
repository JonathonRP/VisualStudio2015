using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HackerRankTests
{
    class Program
    {

        static void Main( String [] args )
        {

            string [] NKQ_temp = Console.ReadLine().Split( ' ' );
            int [] NKQ = Array.ConvertAll( NKQ_temp, Int32.Parse );

            int n = NKQ [0], k = NKQ [1], q = NKQ [2];

            string [] arr_temp = Console.ReadLine().Split( ' ' );
            int [] array = Array.ConvertAll( arr_temp, Int32.Parse );

            int [] m = new int [q];

            for ( int i = 0; i < q; i++ )
            {
                m [i] = Convert.ToInt32( Console.ReadLine() );
            }

            for ( int i = 0; i < q; i++ )
            {
                Console.WriteLine( "{0}", array [( m [i] - ( k % n ) + n ) % n] );
            }

            Console.ReadKey();

        }
    }
}
