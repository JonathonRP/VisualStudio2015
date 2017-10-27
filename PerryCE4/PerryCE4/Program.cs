using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerryCE4
{
    class Program
    {
        static void Main( string [] args )
        {
            Console.Title = "INFS 2600 Cookie Shopper";

            string [] menu = new string[4] { "Welcome to INFS 2600 Cookie Shopper", "Would you like:", 
                "\t(A) Chocolate Chip", "\t(B) Snickerdoodles" };

            foreach( var element in menu)
            {
                Console.WriteLine( element );
            }

            string choice = Console.ReadLine();

            switch ( choice )
            {
                case "A":
                case "Chocolate Chip":

                    int answer;

                    Console.Write( "How many Chocolate Chip would you like to puchase? " );

                    if ( !( int.TryParse( Console.ReadLine(), out answer ) == true ) )
                    {

                        Console.WriteLine( $"I'm sorry, that is not a valid quantity" );
                        System.Threading.Thread.Sleep( 2000 );
                        Console.Clear();
                        Main( null );
                    }
                    else
                    {
                        Console.WriteLine( $"You have selected {answer} Chocolate Chip cookies! YUM." );
                    }

                    break;

                case "B":
                case "Snickerdoodles":

                    Console.WriteLine( "How many Snickerdoodle would you like to puchase?" );

                    if ( !( int.TryParse( Console.ReadLine(), out answer ) == true ) )
                    {

                        Console.WriteLine( $"I'm sorry, that is not a valid quantity" );
                        System.Threading.Thread.Sleep( 2000 );
                        Console.Clear();
                        Main( null );
                    }
                    else
                    {
                        Console.WriteLine( $"You have selected {answer} Snickerdoodles cookies! YUM." );
                    }

                    break;

                default:
                    Console.Clear();
                    Console.WriteLine( $"I'm sorry, {choice} is not an option. good try" );
                    System.Threading.Thread.Sleep( 4000 );
                    Console.Clear();
                    Main( null );

                    break;
            } 
            
            Console.ReadKey();
        }
    }
}
