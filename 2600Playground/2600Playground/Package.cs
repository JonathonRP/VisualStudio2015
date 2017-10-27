using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2600Playground
{
    class Package
    {
        dynamic length, width, height, weight;

        public Package()
        {

        }

        public Package( int newLength, int newWidth, int newHeight, double newWeight )
        {
            length = newLength;
            width = newWidth;
            height = newHeight;
            weight = newWeight;
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
                cost = ( 0.01 * length * width * height ) + 5.0 * weight;
            }
            return cost;
        }
        public void PrintReceipt()
        {
            if ( Cost() == 0.00 )
            {
                Console.WriteLine( "ERROR: invalid package peramiters" );
            }

            Console.WriteLine( $"{length}X{width}X{height} @ {weight} will cost: {Cost(),10:C}" );
        }
    }
}
