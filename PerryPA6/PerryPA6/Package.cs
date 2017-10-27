using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerryPA6
{
    class Package
    {
        ConsoleColor temp;
        private int length, width, height;
        private double weight;

        public Package()
        {

        }

        public Package( int newLength, int newWidth, int newHeight, double newWeight )
        {
            temp = Console.ForegroundColor;

            if ( newLength <= 0 || newWidth <= 0 || newHeight <= 0 || newWeight <= 0 )
            {
                length = default( int );
                width = default( int );
                height = default( int );
                weight = default( double );
            }
            else
            {
                length = newLength;
                width = newWidth;
                height = newHeight;
                weight = newWeight;
            }
        }

        public double Cost()
        {
            double cost = 0.00;
            if ( length <= 0 || width <= 0 || height <= 0 || weight <= 0 )
            {
                length = 0; width = 0; height = 0; weight = 0;
            }
            else
            {
                cost = ( .01 * length * width * height ) + ( 5.0 * weight );
            }
            return cost;
        }

        public void PrintReceipt()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write( $"\n{length,3} x{width,3} x{height,3} @{weight,4} lb {Cost(),13:C}" );

            if ( Cost() == 0.00 )
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write( " Error in creating package" );
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            Console.ForegroundColor = temp;
        }
    }
}
