using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipherImproved
{
    class Program
    {
        static void Main( string [] args )
        {

            int n = Convert.ToInt32( Console.ReadLine() );
            string s = Console.ReadLine();
            int k = Convert.ToInt32( Console.ReadLine() );

            char [] c = s.ToCharArray();
            char [] r = new char [n];

            while ( k > 26 )
            {
                k = k - 26;
            }

            for ( int i = 0; i < n; i++ )
            {
                if ( char.IsLetter( c [i] ) )
                {
                    r [i] = (char) ( c [i] + k );

                    if ( !( ( char.IsLower( r [i] ) == char.IsLower( c [i] ) ) && ( char.IsUpper( r [i] ) == char.IsUpper( c [i] ) ) ) )
                    {
                        r [i] = (char) ( r [i] - 26 );
                    }
                }

                else
                {
                    r [i] = (char) ( c [i] );
                }
            }

            for ( int i = 0; i < n; i++ )
            {
                Console.Write( r [i] );
            }

            Console.ReadKey();

        }
    }
}

