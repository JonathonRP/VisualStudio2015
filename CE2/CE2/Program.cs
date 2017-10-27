using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Reese
 * INFS 2600 003
 * CE2
 * Sept 21, 2016 */

namespace CE2
{
    class Program
    {
        static void Main( string [] args )
        {
            int X = Console.WindowWidth / 2 - 4;
            Console.SetCursorPosition( X / 2, 1);

            Console.WriteLine( "Hotel Reservation System \n" );

            string date = stringPrompt( "What date will you check in? " );
            int nightsStaying = intPrompt( "How many nights are you staying: " );
            int includedPeople = intPrompt( "How many people are staying: " );

            double Reservation, ReservationTax, ReservationTotal;
            double Tax = .091;
            calculate( nightsStaying, includedPeople, Tax, out Reservation, out ReservationTax, out ReservationTotal );

            Console.WriteLine( "\nYou are booked for {0} nights with {1} more people starting {2}.", nightsStaying, includedPeople, date );

            Console.WriteLine( "Hotel reservation cost is ".PadRight(30) + "{0,10:C}", Reservation );
            Console.WriteLine( "Tax with the rate of {0:P1} is ".PadRight(31) + "{1,10:C}", Tax, ReservationTax );
            Console.WriteLine( "Total reservation cost is ".PadRight(30) + "{0,10:C}", ReservationTotal );

            NoKill();

        }

        private static string stringPrompt( string prompt )
        {
            string response;
            Console.Write( prompt );
            response = Console.ReadLine();

            return response;
        }

        private static int intPrompt( string prompt )
        {
            int number;
            Console.Write( prompt );
            number = int.Parse( Console.ReadLine() );

            return number;
        }

        static void calculate(int nightsStaying, int includedPeople, double Tax, out double Reservation, out double ReservationTax, out double ReservationTotal )
        {
            double ReservationCost = 75;

            Reservation = ReservationCost * nightsStaying * includedPeople;

            ReservationTax = Reservation * Tax;

            ReservationTotal = Reservation + ReservationTax;
        }

        static void NoKill()
        {
            Console.ReadKey();
        }
    }
}
