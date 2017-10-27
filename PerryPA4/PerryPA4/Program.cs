using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerryPA4
{
    class Program
    {
        static void Main( string [] args )
        {
            do
            {
                Console.Title = "Rug Purchasing Application";

                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();

                string [] menu = new string [5]{ "Welcome to the Rug Purchasing App \n", "Please choose your Rug size:",
                "\t A. Small (4' x 6') ",
                "\t B. Medium (7' x 10') ",
                "\t C. Large (10' x 14') " };

                string [] menu2 = new string [3] { "\nPlease choose your Rug matarial:",
                    "\t A. Wool ($1.75 per square foot) ",
                    "\t B. Synthetic ($1.00 per square foot) " };

                double Cost;

                foreach ( string element in menu )
                {
                    Console.WriteLine( element );
                }

                string choice1 = Console.ReadLine();

                MenuDecisionEngine( choice1, menu, menu2, out Cost );
            }
            while ( Enter() == false );
        }

        static void MenuDecisionEngine( string choice1, string [] menu, string [] menu2, out double Cost )
        {
            switch ( choice1.ToLower() )
            {
                case "a":

                    Console.Clear();

                    Cost = 4*6;

                    printMenu( menu, menu2, 3, 2 );

                    string choice2 = Console.ReadLine();
                    SecondMenuDecisionEngine( choice2, menu, menu2, Cost, 3, 2 );

                    break;

                case "b":

                    Console.Clear();

                    Cost = 7*10;

                    printMenu( menu, menu2, 4, 3 );

                    choice2 = Console.ReadLine();
                    SecondMenuDecisionEngine( choice2, menu, menu2, Cost, 4, 3 );

                    break;

                case "c":

                    Console.Clear();

                    Cost = 10*14;

                    printMenu( menu, menu2, 5, 4 );

                    choice2 = Console.ReadLine();
                    SecondMenuDecisionEngine( choice2, menu, menu2, Cost, 5, 4 );

                    break;

                case "":

                    Console.Clear();
                    foreach ( var element in menu )
                    {
                        Console.WriteLine( element );
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition( 0, 7 );
                    Console.WriteLine( "Please make a selection, try again" );
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition( 0, 6 );
                    choice1 = Console.ReadLine();
                    MenuDecisionEngine( choice1, menu, menu2, out Cost );
                    break;

                default:

                    Console.Clear();
                    foreach ( var element in menu )
                    {
                        Console.WriteLine( element );
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition( 0, 7 );
                    Console.WriteLine( "Invalid answer, try again" );
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition( 0, 6 );
                    choice1 = Console.ReadLine();
                    MenuDecisionEngine( choice1, menu, menu2, out Cost );
                    break;
            }
        }

        static void SecondMenuDecisionEngine( string choice2, string [] menu, string [] menu2, double Cost, int i, int j )
        {
            if ( choice2.ToLower() == "a" )
            {
                Console.Clear();
                printMenu( menu, menu2, i, j, 8, 1 );

                Cost *= 1.75;

                Console.Write( $"\nYour Cost is " );
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine( $"{Cost:C}" );

                Console.CursorVisible = false;
            }
            else if ( choice2.ToLower() == "b" )
            {
                Console.Clear();
                printMenu( menu, menu2, i, j, 9, 2 );

                Cost *= 1.00;

                Console.Write( $"\nYour Cost is " );
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine( $"{Cost:C}" );

                Console.CursorVisible = false;
            }
            else if ( choice2 == "" )
            {
                Console.Clear();
                printMenu( menu, menu2, i, j );
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition( 0, 11 );
                Console.WriteLine( "Please make a selection, try again" );
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition( 0, 10 );
                choice2 = Console.ReadLine();
                SecondMenuDecisionEngine( choice2, menu, menu2, Cost, i, j );
            }
            else
            {
                Console.Clear();
                printMenu( menu, menu2, i, j );
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition( 0, 11 );
                Console.WriteLine( "Invalid answer, try again" );
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition( 0, 10 );
                choice2 = Console.ReadLine();
                SecondMenuDecisionEngine( choice2, menu, menu2, Cost, i, j );
            }
        }

        static string Highlight( string s )
        {
            ConsoleColor temp;  // declaring temporary consolecolor
            temp = Console.BackgroundColor;

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine( s );
            Console.BackgroundColor = temp;     // returns text to previous color
            return s;
        }

        static void printMenu( string [] menu, string [] menu2, int i, int j )
        {
            foreach ( var element in menu )
            {
                Console.WriteLine( element );
            }
            Console.SetCursorPosition( 0, i );
            string highligh = menu [j].Replace( menu [j], Highlight( menu [j] ) );
            Console.SetCursorPosition( 0, 1 + menu.Length );
            foreach ( var item in menu2 )
            {
                Console.WriteLine( item );
            }
        }

        static void printMenu( string [] menu, string [] menu2, int i, int j, int k, int l )
        {
            foreach ( var element in menu )
            {
                Console.WriteLine( element );
            }
            Console.SetCursorPosition( 0, i );
            string highligh = menu [j].Replace( menu [j], Highlight( menu [j] ) );
            Console.SetCursorPosition( 0, 1 + menu.Length );
            foreach ( var item in menu2 )
            {
                Console.WriteLine( item );
            }
            Console.SetCursorPosition( 0, k );
            string secondHighligh = menu2 [l].Replace( menu2 [l], Highlight( menu2 [l] ) );
            Console.SetCursorPosition( 0, 10 );
        }

        static bool Enter()
        {
            if ( Console.ReadKey().Key == ConsoleKey.Enter )
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
