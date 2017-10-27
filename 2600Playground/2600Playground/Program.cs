using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2600Playground
{
    class Program
    {
        static void Main( string [] args )
        {

            int length, width, height;
            double weight;
            List<Package> p = new List<Package>();
            List<double> totalCost = new List<double>();

            Console.Write( "Would you like to ship a package? (Y/N): " );
            string result;

            while ( ( result = Console.ReadLine().ToLower() ) == "y" )
            {

                length = Prompt<int>( "Enter length (in inches): " );
                width = Prompt<int>( "Enter width (in inches): " );
                height = Prompt<int>( "Enter height (in inches): " );

                weight = Prompt<double>( "Enter weight (in lbs):" );

                p.Add( new Package( length, width, height, weight ) );

                for ( int i = 0; i < p.Count; i++ )
                {
                    totalCost.Add( p [i].Cost() );
                }
                Console.WriteLine( "Would you like to ship another package? (Y/N): " );
            }
            if ( result.ToLower() == "n" )
            {
                foreach( var packge in p )
                {
                    packge.PrintReceipt();
                }

                Console.WriteLine( "{0,-10}", "total cost:" + $"{totalCost.Sum(),25:C}" );
                Console.ReadKey();
            }
            else if ( result.ToLower() != "y" || result.ToLower() != "n" )
            {
                Console.Clear();
                Main(null);
            }
        }
        static T Prompt<T>( string prompt )
        {
            T value;
            Console.WriteLine( prompt );
            object responce = Console.ReadLine();

            bool result = TryParse( responce, out value );

            while ( result == false )
            {
                Console.WriteLine( $"invalid, {prompt}" );
                responce = Console.ReadLine();
                result = TryParse( responce, out value );
            }
            return value;
        }
        static bool TryParse<T>( object input, out T value )
        {
            try
            {
                value = (T) Convert.ChangeType( input, typeof( T ) );
                return true;
            }
            catch
            {
                value = default( T );
                return false;
            }
        }
    }
}
