using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerryCE5
{
    class Program
    {
        static void Main( string [] args )
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;


            while (true)
            {
                Console.WriteLine( "Would you like to ship a package? Y/N" );
                if ( Console.ReadLine().ToLower() == "y" )
                {
                    PackageCalc();
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine( "GoodBye " );
            System.Threading.Thread.Sleep( 2000 );
            Environment.Exit( 0 );
        }

        static void PackageCalc()
        {
            int length;
            int width;
            int height;

            double weight;

            intPrompt( "Enter Length of package ", out length );
            intPrompt( "Enter width of package ", out width );
            intPrompt( "Enter height of package ", out height );

            doublePrompt( "Enter weight of package ", out weight );

            double cost = ( .01 * length * width * height ) + 5.0 * weight;

            Console.Write( $"The cost for a {length} X {width} X {height} @ {weight} lb is : " );
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"{cost:C}");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine( "-----------------------------------------------------" );
        }

        static void intPrompt( string prompt, out int value )
        {
            Console.Write( prompt );
            Console.ForegroundColor = ConsoleColor.Black;
            bool result = int.TryParse( Console.ReadLine(), out value );

            if ( result == false )
            {
                Console.ForegroundColor = ConsoleColor.Red;
                intPrompt( "invalid, try again ", out value );
            }
        }

        static void doublePrompt( string prompt, out double value )
        {
            Console.Write( prompt );
            Console.ForegroundColor = ConsoleColor.Black;
            bool result = double.TryParse( Console.ReadLine(), out value );

            if ( result == false )
            {
                Console.ForegroundColor = ConsoleColor.Red;
                doublePrompt( "invalid, try again ", out value );
            }
        }
    }
}
