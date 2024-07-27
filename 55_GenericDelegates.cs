using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp6Net46._1_CSharpBasics;

namespace CSharp6Net46._2_CSharpAdvanced
{
    class GenericDelegates
    {
        public delegate void MyGenericDelegate<T>(T info);

        public static void Example()
        {

            MyGenericDelegate<int> intTarget = new MyGenericDelegate<int>(PrintMessageFromCar);
            intTarget(34); //invoke

            MyGenericDelegate<string> strTarget = new MyGenericDelegate<string>(PrintMessageFromCar2);
            strTarget("Test"); //invoke


        }

        public static void PrintMessageFromCar(int message)
        {
            Console.WriteLine("Print Message One: {0}", message.ToString());
        }

        public static void PrintMessageFromCar2(string message)
        {
            Console.WriteLine("Print Message Two: {0}", message);
        }
    }
    
}
