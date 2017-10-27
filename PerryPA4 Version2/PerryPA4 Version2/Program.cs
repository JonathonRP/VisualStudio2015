using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PerryPA4_Version2
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
                Console.CursorVisible = false;

                string [] menu = new string [5]{ "Welcome to the Rug Purchasing App \n", "Please choose your Rug size:",
                "\t A. Small (4' x 6') ",
                "\t B. Medium (7' x 10') ",
                "\t C. Large (10' x 14') " };

                string [] menu2 = new string [3] { "Please choose your Rug matarial:",
                    "\t A. Wool ($1.75 per square foot) ",
                    "\t B. Synthetic ($1.00 per square foot) " };

                foreach ( string element in menu )
                {
                    Console.WriteLine( element );
                }

                Console.WriteLine( "\nPress the Up Arrow to highligh selection, and Enter to select" );


                MenuSelect( menu, menu2 );
            }
            while ( Enter() == false );
        }

        static void MenuPrint( string [] menu, string [] menu2, int i, int j )
        {
            foreach ( var element in menu )
            {
                Console.WriteLine( element );
            }

            Console.SetCursorPosition( 0, i );
            menu [j] = menu [j].Replace( menu [j], Highlight( menu [j] ) );
            Console.SetCursorPosition( 0, menu.Length + 2 );

            foreach ( var item in menu2 )
            {
                Console.WriteLine( item );
            }
        }

        static void MenuSelect( string [] menu, string [] menu2 )
        {
            int i = 6;
            int j = 5;
            string highligh = "";
            double cost;

            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.UpArrow)
                {
                    i = i - 1;
                    j = j - 1;

                    for (; i >= 3;)
                    {
                        Console.Clear();

                        foreach (var element in menu)
                        {
                            Console.WriteLine(element);
                        }

                        Console.SetCursorPosition(0, i);

                        for (; j >= 2;)
                        {
                            highligh = menu[j].Replace(menu[j], Highlight(menu[j]));

                            if (j == 2)
                            {
                                j = 5;
                                i = 6;
                            }
                            break;
                        }
                        break;
                    }
                }
            } while (key.Key != ConsoleKey.Enter && menu.Contains(highligh));

            if (j == 5 && menu.Contains(highligh))
            {
                j = 2;
                i = 3;
            }

            MenuEngine(menu, menu2, highligh, i, j, out cost);
        }

        static void SecondMenuPrint( string [] menu, string [] menu2, int i, int j, int k, int l )
        {
            foreach ( var element in menu )
            {
                Console.WriteLine( element );
            }

            Console.SetCursorPosition( 0, i );
            menu [j] = menu [j].Replace( menu [j], Highlight( menu [j] ) );
            Console.SetCursorPosition( 0, menu.Length + 2 );

            foreach ( var item in menu2 )
            {
                Console.WriteLine( item );
            }

            Console.SetCursorPosition( 0, k );
            menu2 [l] = menu2 [l].Replace( menu2 [l], Highlight( menu2 [l] ) );
            Console.SetCursorPosition( 0, 10 );
        }

        static void SecondMenuSelect( string [] menu, string [] menu2, int i, int j, double cost )
        {
            int k = 10;
            int l = 3;
            string highligh2 = "";
            string highlight = "";

            ConsoleKeyInfo key2;

            do
            {
                key2 = Console.ReadKey(true);

                if (key2.Key == ConsoleKey.UpArrow)
                {
                    k = k - 1;
                    l = l - 1;

                    for (; k >= 7;)
                    {
                        Console.Clear();

                        foreach (var element in menu)
                        {
                            Console.WriteLine(element);
                        }

                        Console.SetCursorPosition(0, i);
                        highlight = menu[j].Replace(menu[j], Highlight(menu[j]));
                        Console.SetCursorPosition(0, menu.Length + 2);

                        foreach (var item in menu2)
                        {
                            Console.WriteLine(item);
                        }

                        Console.SetCursorPosition(0, k);

                        for (; l >= 1;)
                        {
                            highligh2 = menu2[l].Replace(menu2[l], Highlight(menu2[l]));

                            if (l == 1)
                            {
                                l = 3;
                                k = 10;
                            }
                            break;
                        }
                        break;
                    }
                }
            } while (key2.Key != ConsoleKey.Enter && menu2.Contains(highligh2));

            if (l == 3 && menu2.Contains(highligh2))
            {
                l = 1;
                k = 8;
            }

            SecondMenuEngine(menu, menu2, highlight, i, j, k, l, cost);
        }

        static void MenuEngine( string [] menu, string [] menu2, string highligh, int i, int j, out double cost )
        {
            try
            {
                var validChoice = menu [j].Contains( highligh );
                switch ( validChoice )
                {
                    case true:
                        cost = 1;
                        Console.Clear();

                        MenuPrint( menu, menu2, i, j );
                        SecondMenuSelect( menu, menu2, i, j, cost );
                        break;

                    default:
                        cost = 0;
                        break;
                }
            }
            catch ( Exception )
            {
                cost = 0;
                Console.SetCursorPosition( 0, i );
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine( "\nPress the Up Arrow to highligh selection" );
                Console.ForegroundColor = ConsoleColor.Black;
            }
        }

        static void SecondMenuEngine( string [] menu, string [] menu2, string highligh, int i, int j, int k, int l, double cost )
        {
            try
            {
                if ( menu2 [l].Contains( "A" ) )
                {

                    Console.Clear();

                    SecondMenuPrint( menu, menu2, i, j, k, l );

                    var result = from c in highligh.Where( char.IsNumber )
                                 select c.ToString();

                    int length;
                    int width;

                    if ( result.Count() == 4 )
                    {
                        length = Convert.ToInt32( result.ElementAt( 0 ) + result.ElementAt( 1 ) );
                        width = Convert.ToInt32( result.ElementAtOrDefault( 2 ) + result.ElementAtOrDefault( 3 ) );
                    }
                    else
                    {
                        length = Convert.ToInt32( result.ElementAt( 0 ) );
                        width = Convert.ToInt32( result.ElementAt( 1 ) + result.ElementAtOrDefault( 2 ) );
                    }

                    cost *= ( length * width ) * 1.75;

                    Console.Write( $"\nYour Cost is " );
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write( $"{cost:C}" );
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine( $" for a {length} X {width} wool rug" );
                }

                if ( menu2 [l].Contains( "B" ) )
                {

                    Console.Clear();

                    SecondMenuPrint( menu, menu2, i, j, k, l );

                    var result = from c in highligh.Where( char.IsNumber )
                                 select c.ToString();

                    int length;
                    int width;

                    if ( result.Count() == 4 )
                    {
                        length = Convert.ToInt32( result.ElementAt( 0 ) + result.ElementAtOrDefault( 1 ) );
                        width = Convert.ToInt32( result.ElementAtOrDefault( 2 ) + result.ElementAtOrDefault( 3 ) );
                    }
                    else
                    {
                        length = Convert.ToInt32( result.ElementAt( 0 ) );
                        width = Convert.ToInt32( result.ElementAt( 1 ) + result.ElementAtOrDefault( 2 ) );
                    }

                    cost *= ( length * width )* 1.00;

                    Console.Write( $"\nYour Cost is " );
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write( $"{cost:C}" );
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.Write( $" for a {length} X {width} synthetic rug" );
                }
            }
            catch
            {
                cost = 0;
                Console.Clear();
                MenuPrint( menu, menu2, i, j );
                Console.SetCursorPosition( 0, 10 );
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write( "\nPress the Up Arrow to highligh selection" );
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine( ", and Enter to select" );
            }
        }

        static string Highlight( string s )
        {
            ConsoleColor temp;  // declaring temporary consolecolor
            temp = Console.BackgroundColor;

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write( s );
            Console.BackgroundColor = temp;     // returns text to previous color
            return s;
        }

        static bool Enter()
        {
            while ( Console.ReadKey().Key == ConsoleKey.Enter )
            {
                return true;
            }
            return false;
        }
    }
}
