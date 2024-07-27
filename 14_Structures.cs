using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._1_CSharpBasics
{
    class Structures
    {
        struct Point
        {
            public int X;
            public int Y;

            public void Increment()
            {
                X++;Y++;
            }

            public void Decrement()
            {
                X--; Y--;
            }

            public void Print()
            {
                Console.WriteLine("X={0} and Y={1}", X, Y);
            }
        }

        public static void Example()
        {

            //Structures are like classes
            //but when you need to create a set of related objects use actual classes

            //Value type vs Reference Type:
            //Structures are value types and derive form System.ValueTYPE
            //Value Type: as soon as it goes out of scope memory for sturcuture is cleared

            Point testOne;

            testOne.X = 100;
            testOne.Y = 100;

            testOne.Print();

            //Creating a structure using NEW
            //Different all the properties have a default value

            Point testTwo =  new Point();

            testTwo.X = 100;
            testTwo.Y = 100;

            testTwo.Print();

            Console.ReadLine();


        }
    }
}
