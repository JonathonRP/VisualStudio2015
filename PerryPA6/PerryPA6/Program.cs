using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPrompts;

namespace PerryPA6
{
    class Program : ConsolePrompts<int>
    {
        static void Main( string[] args )
        {

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.Write( "Would you like to make ship a package? (Y/N): " );
            Engine();
        }

        static void Engine()
        {
            double totalCost = 0.00;
            Package[] p = new Package[10];

            string result;
            for ( int i = 0; ( result = Console.ReadLine().ToLower() ) == "y"; i++ )
            {
                ErrorMessage = ErrorMessage.Replace( "Invalid", "Error! not a valid" );
                ErrorColor = ConsoleColor.DarkRed;

                Console.Write("\n");

                int length = Prompt( "Enter Length (in inches): " );
                int width = Prompt( "Enter Width  (in inches): " );
                int height = Prompt( "Enter Height (in inches): " );

                double weight = Prompt<double>( "Enter Weight (in lbs): " );

                p[i] = new Package( length, width, height, weight );
                totalCost += p[i].Cost();

                Console.Write( "\nWould you like to ship another package? (Y/N): " );
            }

            if ( result == "n" )
            {
                foreach ( var package in p )
                {
                    if ( package != null && package.Cost() != 0.00 )
                    {
                        package.PrintReceipt();
                    }
                    else
                    {
                        if ( package == null )
                        {
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }

                foreach ( var package in p )
                {
                    if ( package != null && package.Cost() == 0.00 )
                    {
                        package.PrintReceipt();
                    }
                    else
                    {
                        if ( package == null )
                        {
                            Console.Write( "\n_________________________________" );
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }

                Console.WriteLine( "_______________________________________________" );
                Console.Write( $"Total shipping cost:" );
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine( $"{totalCost,16:C}" );
                Console.ReadKey();
            }

            if ( result != "y" && result != "n" )
            {
                ConsoleColor temp;
                temp = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write( "invalid, try again: " );
                Console.ForegroundColor = temp;
                Engine();
            }
        }

    }
}
