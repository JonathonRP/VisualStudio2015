using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerryFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Your First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Your Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            Console.Write("Re-Enter Password: ");
            string passwordReEntered = Console.ReadLine();

            while( password != passwordReEntered )
            {
                Console.WriteLine("\nDid Not Match, Try Again!");
                Console.Write("Password: ");
                password = Console.ReadLine();

                Console.Write("Re-Enter Password: ");
                passwordReEntered = Console.ReadLine();
            }

            SecurityClearance SC1 = new SecurityClearance(firstName, lastName, password, 1);

            Console.WriteLine(SC1.ToString());

            Console.Write("\nYour Password to access secure data entry: ");
            string _password = Console.ReadLine();

            bool passCheck = SC1.CheckPassword(_password);

            if( passCheck == true )
            {
                Console.WriteLine("Access Granted. Please enter 5 integer codes");
                int[] array = new int[5];

                for( int i = 0; i < array.Length; i++ )
                {
                    Console.Write($"Enter code {i + 1} ");
                    bool result = int.TryParse(Console.ReadLine(), out array[i]);

                    if( result == false )
                    {
                        Console.Write($"Enter code {i + 1} ");
                        result = int.TryParse(Console.ReadLine(), out array[i]);
                    }
                }

                Console.Write($"\nThe Secret Result is { array.Average() }");
                Console.ReadKey();
            }

            if( passCheck == false )
            {
                Console.Write("Authentication Failed");
                System.Threading.Thread.Sleep(4000);
            }
        }
    }
}
