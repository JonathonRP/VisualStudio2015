using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem_Classes_exersice
{
    class Reservation
    {

        // private data members

        private String arrivalDate;
        private int guests, nights;

        // constructor(s) -- initialize private data members

        public Reservation()
        {

            //Console.WriteLine( " Hotel Reservation System" );
            guests = 1;
            nights = 1;
            arrivalDate = DateTime.Now.ToShortDateString();

        }

        public Reservation(String newArrival, int newGuests, int newNights)
        {

            //Console.WriteLine( "Printed Parameterized Constructor" );
            arrivalDate = newArrival;
            guests = newGuests;
            nights = newNights;
            //Console.WriteLine( "Arriving: {0}, Guests: {1}, Nights: {2}", newArrival, newGuests, newNights );

        }

        // properties -- allowance of access to private members

        public String ArrivalDate
        {
            get
            {
                return arrivalDate;
            }

            set
            {
                arrivalDate = value;
            }
        }

        public int Guests
        {
            get
            {
                return guests;
            }

            set
            {
                guests = value;
            }
        }

        public int Nights
        {
            get
            {
                return nights;
            }

            set
            {
                nights = value;
            }
        }

        // method(s) -- useful functionality

        public void PrintBill()
        {

            double reservationCost, tax, finalCost;

            reservationCost = 75 * guests * nights;
            tax = reservationCost * .091;
            finalCost = reservationCost + tax;

            Console.WriteLine( "{0} Guests are arriving on {1}", guests , arrivalDate );
            Console.WriteLine( "{0,-20}{1,10}", "Reservations Cost: ", reservationCost );
            Console.WriteLine( "{0,-20}{1,10}", "Tax at 9.1%: ", tax );
            Console.WriteLine( "{0,-20}{1,10}", "Total Cost: ", finalCost );

        }

        public override string ToString()
        {
            string temp;

            temp = string.Format( "arrival: {0}, Guests: {1}, Nights: {2}", arrivalDate, guests, nights );

            return temp;
        }

    }
}
