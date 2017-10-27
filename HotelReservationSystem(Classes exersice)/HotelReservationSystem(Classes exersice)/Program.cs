using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem_Classes_exersice
{
    class Program
    {
        static void Main( string [] args )
        {

            Reservation Hotel = new Reservation();
            Reservation Hotel2 = new Reservation( "Sept 25, 2060", 2, 6 );
            Reservation Hotel3 = new Reservation();

            Console.WriteLine( "     Hotel Reservation System\n" );

            Console.WriteLine( "{0, 20}", "\n\t Hotel toString\n" );

            Console.WriteLine( Hotel.ToString() );

            Console.WriteLine( "{0, 20}", "\n\t Hotel Bill\n" );

            Hotel.PrintBill();

            Console.WriteLine( "{0, 20}", "\n\t Hotel2 Bill\n" );
            Hotel2.PrintBill();

            Console.WriteLine( "{0, 20}", "\n\t Hotel3 Prompting\n" );

            Console.Write( "Enter a date you wish for reservations: " );
            Hotel3.ArrivalDate = Console.ReadLine();

            Console.Write( "Enter guests: " );
            Hotel3.Guests = int.Parse( Console.ReadLine() );

            Console.Write( "Enter nights you will be staying: " );
            Hotel3.Nights = int.Parse( Console.ReadLine() );

            Console.WriteLine( "{0, 20}", "\n\t Hotel3 Bill\n" );
            Hotel3.PrintBill();

            Console.ReadKey();

        }
    }
}
