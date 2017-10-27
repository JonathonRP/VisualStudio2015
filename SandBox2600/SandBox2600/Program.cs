using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBox2600
{
    class Program
    {
        static void Main(string[] args)
        {
            int age;
            string name;

            name = namePrompt("whats your name: ");
            age = agePrompt("what is your age: ");

            Console.WriteLine("{0} will be {1} next year.", name, age + 1);


            System.Threading.Thread.Sleep(3000);

            Greeter(name);

            System.Threading.Thread.Sleep(1000);
            int x = Add(10, 13);
            Console.WriteLine("The Added Result {0}", x);

            System.Threading.Thread.Sleep(1000);
            int y = Max3(10, 6, 4);
            Console.WriteLine("The Max Result {0}", y);

            TheEnd();
        }

        static string namePrompt(string prompt)
        {
            string result;
            Console.Write(prompt);
            result = Console.ReadLine();

            return result;
        }
        static int agePrompt(string prompt)
        {
            int result;
            Console.Write(prompt);
            result = int.Parse(Console.ReadLine());

            return result;
        }

        static void TheEnd()
        {
            Console.Write("Good Bye!");
            System.Threading.Thread.Sleep(2000);
            Environment.Exit(0);

            //Console.ReadKey();
        }

        static void Greeter(String name)
        {
            Console.WriteLine("Hello {0}", name);
        }

        static int Add(int Val1, int Val2)
        {
            int result = Val1 + Val2;
            return result;
        }

        static int Max3(int Val1, int Val2, int Val3)
        {
            int firstMax = Math.Max(Val1, Val2);
            int finalMax = Math.Max(firstMax, Val3);

            return finalMax;
        }
    }
}
