using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_007
{
    class _007
    {
        static void Main(string[] args)
        {
            string x = "007";
            int Y = 12;

            Console.WriteLine("Hello, the name is Bond, James Bond. just call me {0}. {1}", x, "\nI work in the background, the shadows for your program.\nPress enter to confirm.");
            Console.ReadLine();

            Console.WriteLine("this message is going to selfdestruct!\n");

            Console.Write("Timer: ".PadLeft(20));
            
            //Console.Write(" \t \t ");

            Console.Beep();

            while (Y > 0)
            {
                Console.Write("{0:00}", Y);
                Console.Write("\b\b");
                //Console.Write(" \b\b");
                //Console.Write("\r");
                //Console.Write(" \t \t ");
                Y--;
                System.Threading.Thread.Sleep(1000);
                Console.Beep();
            }
            Console.Write("\r".PadLeft(20));
            Console.Write("Goodbye".PadLeft(20));
            Console.Beep(); Console.Beep(); Console.Beep(); Console.Beep(); Console.Beep();
            //System.Threading.Thread.Sleep(1000);

            Environment.Exit(0);
        }
    }
}
