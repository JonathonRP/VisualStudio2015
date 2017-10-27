using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPlayGround
{
    class Program
    {
        static void Main( string [] args )
        {

            string [] menu = new string [5]{ "Welcome to the Rug Purchasing App \n", "Please choose your Rug size:",
                "\t A. Small (4' x 6') ",
                "\t B. Medium (7' x 10') ",
                "\t C. Large (10' x 14') " };

            string [] menu2 = new string [3] { "Please choose your Rug matarial:",
                    "\t A. Wool ($1.75 per square foot) ",
                    "\t B. Synthetic ($1.00 per square foot) " };

            var result = from i in menu [3].Where( char.IsNumber )
                         select i.ToString();

            int length = Convert.ToInt32( result.ElementAt( 0 ) + result.ElementAtOrDefault( 1 ) );
            int width =  Convert.ToInt32( result.ElementAtOrDefault( 1 ) + result.ElementAtOrDefault( 2 ) + result.ElementAtOrDefault( 3 ) );

            Console.WriteLine( $"{length} X {width}" );

            Print( length, width );

            Console.ReadKey();

        }

        static void Print( int length, int width )
        {
            for ( int row = 1; row < length; row++ )
            {
                Console.SetCursorPosition( 0, row );

                for ( int cols = 0; cols < width; cols++ )
                {
                    Console.Write( "W" );
                }
            }
        }
    }
}
