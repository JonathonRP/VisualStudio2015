using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPrompts;

namespace PerryPA5
{
    class Program : ConsolePrompts<int>
    {
        static void Main( string [] args )
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
            Package [] p = new Package [100];

            string result;
            for ( int i = 0; ( result = Console.ReadLine().ToLower() ) == "y"; i++ )
            {
                //Prompts<int> Packageinfo = new Prompts<int>();

                //int length = Packageinfo.Prompt( "Enter Length (in inches): " );
                //int width = Packageinfo.Prompt( "Enter Width  (in inches): " );
                //int height = Packageinfo.Prompt( "Enter Height (in inches): " );

                //double weight = Packageinfo.Prompt<double>( "Enter Weight (in lbs): " );

                int length = Prompt( "Enter length (in inches): " );
                int width = Prompt( "Enter width (in inches): " );
                int height = Prompt( "Enter height (in inches): " );

                double weight = Prompt<double>( "Enter weight (in lbs): " );

                p[i] = new Package( length, width, height, weight );
                p[i].PrintReceipt();
                totalCost += p[i].Cost();

                Console.Write( "Would you like to ship another package? (Y/N): " );
            }

            if ( result == "n" )
            {
                Console.Write( $"Total shipping cost:" );
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine( $"{totalCost,10:C}" );
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
