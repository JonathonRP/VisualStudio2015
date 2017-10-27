using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HackerRank_Caesar_Cipher
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

                    if ( char.IsLower( r [i] ) && char.IsUpper( c [i] ) || char.IsUpper( r [i] ) && char.IsLower( c [i] ) )
                        r [i] = (char) ( r [i] - 26 );
                }

                if ( r [i] < 'A' || r [i] > 'Z' && r [i] <= 'a' || r [i] > 'z' )
                {
                    if ( char.IsSeparator( c [i] ) || char.IsPunctuation( c [i] ) || char.IsNumber( c [i] ) || char.IsSymbol( c [i] ) )
                        r [i] = (char) ( c [i] );
                    else
                        r [i] = (char) ( ( c [i] - 26 ) + k );
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
