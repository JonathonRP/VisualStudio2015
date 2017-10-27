using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace PerryPA2
{
    class Program
    {
        static void Main(string[] args)
        {
            // prompt user for name and store name in ShipTo value
            string ShipTo = stringPrompt("Enter Customer Name: ");

            // propmt user for Zipcode and store Zipcode in Zipcode value
            int Zipcode = intPrompt("Enter Shipping Zipcode: ");

            // prompt user for purchase amount of Envelopes and store Envelope amount in EnvelopeNumber value
            int EnvelopesNumber = intPrompt("Enter a number to purchase Envelopes: ");

            // prompt user for purchase amount of SmallPackages and store SmallPackages amount in SmallPackagesNumber
            int SmallPackagesNumber = intPrompt("Enter a number to purchase SmallPackages: ");

            // initiate values to calculate and store
            double ShippingCost, TotalTax, ShippingTotal;

            // calculate values and store
            calculations(EnvelopesNumber, SmallPackagesNumber, out ShippingCost, out TotalTax, out ShippingTotal);

            // write ShipTo, Zipcode and calculations to console while aligning output
            receiptPrint(ShipTo, Zipcode, ShippingCost, TotalTax, ShippingTotal);

            // prevent self-kill
            exitPrevention();
        }

        private static string stringPrompt(string prompt)
        {
            string response;
            Console.Write(prompt);
            response = Console.ReadLine();

            return response;
        }

        private static int intPrompt(string prompt)
        {
            int number;
            Console.Write(prompt);
            number = int.Parse(Console.ReadLine());

            return number;
        }

        private static void calculations(int EnvelopesNumber, int SmallPackagesNumber, out double ShippingCost, out double TotalTax, out double ShippingTotal)
        {
            // initiate and set initiated values to use in calculations
            double EnvelopesCost = .89, SmallPackagesCost = 3.50, Tax = .10;

            // calculate initiated values and store
            ShippingCost = EnvelopesNumber * EnvelopesCost + SmallPackagesNumber * SmallPackagesCost;

            TotalTax = ShippingCost * Tax;

            ShippingTotal = ShippingCost + TotalTax;
        }

        private static void receiptPrint(string ShipTo, int Zipcode, double ShippingCost, double TotalTax, double ShippingTotal)
        {
            Console.WriteLine("\nShip To: {0}", ShipTo.PadLeft(14));
            Console.WriteLine("Shipping Zipcode: ".PadRight(15) + Zipcode);
                Console.WriteLine("Shipping Cost: ".PadRight(20) + "{0,10:C}", ShippingCost);
                Console.WriteLine("Tax: ".PadRight(20) + "{0,10:C}", TotalTax);
                Console.WriteLine("Shipping Total: ".PadRight(20) + "{0,10:C}", ShippingTotal);
        }

        static void exitPrevention()
        {
            Console.ReadKey();
        }
    }
}
