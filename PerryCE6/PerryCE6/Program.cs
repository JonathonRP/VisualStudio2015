using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerryCE6
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] WeekDays = new string[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thrusday", "Friday", "Saturday" };
            int[] visitors = new int[7];
            string WeekMax = "";
            string WeekMin = "";


            for ( int i = 0; i < WeekDays.Length; i++ )
            {
                visitors[i] = Prompt<int>( $"Enter number of visitors for{WeekDays[i],10}: " );
            }

            for ( int i = 0; i < WeekDays.Length; i++ )
            {
                WeekDays[i] = $"{WeekDays[i]} with {visitors[i]} visitors";

                if ( visitors[i] == visitors.Min() )
                {
                    WeekMin = WeekDays[i];
                }

                if ( visitors[i] == visitors.Max() )
                {
                    WeekMax = WeekDays[i];
                }
            }

            Console.WriteLine( $"Sum of visitors this week: {visitors.Sum(),4}" );
            Console.WriteLine( $"Average visitors this week: {visitors.Average(),3}" );
            Console.WriteLine( $"the day with max visits was {WeekMax}" );
            Console.WriteLine( $"the day with min visits was {WeekMin}" );

            Console.ReadKey();
        }
        public static T Prompt<T>( string prompt )
        {
            Console.Write(prompt);
            object responce = Console.ReadLine();

            T value;
            bool result = TryParse<T>(responce, out value);

            if (result == false)
            {
                Console.Write($"{prompt}try again ");
                responce = Console.ReadLine();

                result = TryParse<T>(responce, out value);
            }

            return value;
        }
        public static bool TryParse<S>( object input, out S value )
        {
            try
            {
                value = (S) Convert.ChangeType(input, typeof(S));
                return true;
            }
            catch
            {
                value = default (S);
                return false;
            }
        }
    }
}
