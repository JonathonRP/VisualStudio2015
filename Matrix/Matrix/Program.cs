using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Program
    {
        // fields
        static Random rand = new Random();

        // properties
        static char AsciiCharacter
        {
            get
            {
                int t = rand.Next(10);
                if (t <= 2)
                    // returns a number
                    return (char)('0' + rand.Next(10));
                else if (t <= 4)
                    // small letter
                    return (char)('a' + rand.Next(27));
                else if (t <= 6)
                    // capital letter
                    return (char)('A' + rand.Next(27));
                else
                    // any ascii character
                    return (char)(rand.Next(32, 255));
            }
        }

        // methods
        static void Main()
        {

            Matrix();
            
        }

        static void Matrix()
        {
            Console.Title = "tH3 M7tr1x 3ff3<t";
            Console.WindowLeft = Console.WindowTop = 0;
            Console.WindowHeight = Console.BufferHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.BufferWidth = Console.LargestWindowWidth;

            int X, Y;
            string choice;
            MatrixPrompt( out X, out Y, out choice );

            if (choice == "Red" || choice == "red" || choice == "RED")
            {
                Console.CursorVisible = false;

                int width, height;
                // setup array of starting y values
                int[] y;

                // width was 209, height was 81
                // setup the screen and initial conditions of y
                Initialize(out width, out height, out y);

                // do the Matrix effect
                // every loop all y's get incremented by 1
                while (true)
                {
                    MatrixText( width, height );
                    UpdateAllColumns( width, height, y );
                }
            }
            else if (choice == "Blue" || choice == "blue" || choice == "BLUE")
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition( X, Y );
                Console.Write( "GoodBye" );
                System.Threading.Thread.Sleep( 1000 );
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition( X - "Try again".Length / 2, Y );
                Console.Write( "Try again" );
                System.Threading.Thread.Sleep( 1000 );
                Console.Clear();
                Main();
            }
        }

        static void MatrixPrompt(out int X, out int Y, out string choice)
        {

            X = Console.WindowWidth / 2; Y = Console.WindowHeight / 2;

            string quote = "If you take the blue pill, the story ends. If you take the red pill, you stay in wonderland.";

            Console.SetCursorPosition(X - "THE MATRIX".Length / 2, Y);
            darkGreenText("THE MATRIX");
            System.Threading.Thread.Sleep(10000);

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Clear();

            Console.SetCursorPosition(X - "THE MATRIX".Length / 2, Y);
            BlackText("THE MATRIX");
            System.Threading.Thread.Sleep(100);

            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.SetCursorPosition(X - quote.Length / 2, Y - 4);
            System.Threading.Thread.Sleep(1000);

            darkGreenText("If you take the");
            BlueText(" blue pill");
            darkGreenText(", the story ends. If you take the");
            RedText(" red pill");
            darkGreenText(", you stay in wonderland.");

            Console.SetCursorPosition(X - "Your Choice".Length / 2, Y - 2);
            System.Threading.Thread.Sleep(2000);

            darkGreenText("Your Choice");

            Console.SetCursorPosition(X - "Red or Blue".Length / 2, Y);
            System.Threading.Thread.Sleep(1000);

            RedText("Red ");
            System.Threading.Thread.Sleep(600);

            darkGreenText("or");
            System.Threading.Thread.Sleep(1000);

            BlueText(" Blue");

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(X - 2, Y + 2);
            choice = Console.ReadLine();
        }

        static void typewriting( String word )
        {
            for ( int i = 0; i < word.Length; i++ )
            {
                Console.Write( word.ElementAt( i ) );
                Console.CursorVisible = true;
                System.Threading.Thread.Sleep( 50 );
            }
        }

        static void BlueText(string prompt)
        {
             Console.ForegroundColor = ConsoleColor.Blue;
             typewriting(prompt);
        }

        static void RedText(string prompt)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            typewriting(prompt);
        }

        static void darkGreenText(string prompt)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            typewriting(prompt);
        }

        static void BlackText(string prompt)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            typewriting(prompt);
        }

        private static void UpdateAllColumns(int width, int height, int[] y)
        {
            int x;
            // draws 3 characters in each x column each time... 
            // a dark green, light green, and a space

            // y is the position on the screen
            // y[x] increments 1 each time so each loop does the same thing but down 1 y value
            for (x = 0; x < width; ++x)
            {
                // the bright green character
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(x, y[x]);
                Console.Write(AsciiCharacter);

                // the dark green character -  2 positions above the bright green character
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                int temp = y[x] - 2;
                Console.SetCursorPosition(x, inScreenYPosition(temp, height));
                Console.Write(AsciiCharacter);

                // the 'space' - 20 positions above the bright green character
                int temp1 = y[x] - 20;
                Console.SetCursorPosition(x, inScreenYPosition(temp1, height));
                Console.Write(' ');

                // increment y
                y[x] = inScreenYPosition(y[x] + 1, height);
            }
            
            // F5 to reset, F11 to pause and unpause
            if (Console.KeyAvailable)
            {
                if (Console.ReadKey().Key == ConsoleKey.F5)
                    Initialize(out width, out height, out y);
                if (Console.ReadKey().Key == ConsoleKey.F11)
                    System.Threading.Thread.Sleep(1);
            }

        }

        public static void MatrixText(int width, int height)
        {
            int X = width / 2, Y = height / 2;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(X, Y);
            
            Console.Write(" THE MATRIX ");
        }

        // Deals with what happens when y position is off screen
        public static int inScreenYPosition(int yPosition, int height)
        {
            if (yPosition < 0)
                return yPosition + height;
            else if (yPosition < height)
                return yPosition;
            else
                return 0;
        }

        // only called once at the start
        private static void Initialize(out int width, out int height, out int[] y)
        {
            height = Console.WindowHeight;
            width = Console.WindowWidth - 1;

            // 209 for me.. starting y positions of bright green characters
            y = new int[width];

            Console.Clear();
            // loops 209 times for me
            for (int x = 0; x < width; ++x)
            {
                // gets random number between 0 and 81
                y[x] = rand.Next(height);
            }
        }
    }
}
