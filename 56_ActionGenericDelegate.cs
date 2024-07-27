using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._2_CSharpAdvanced
{

    /*
        Sometimes you just want a delegate that takes in a number of arguements and returns something
        The name of the delegate is irrelevant
        In this case framework provides two types of built in deletages
        Action<>: You can pass in up to 10 parameters! See example below. Can only point at methods that return void
        Func<>: Same as above but can have a return value. Final parameter is always return value

        So whats the point of having customer delegates?
        ================================================
        If you need to have one with a name so that things are clearer use a customer delegate
        If you need to ensure consistency a defined type might be usefull
    */

    class ActionGenericDelegate
    {
        public static void Example()
        {
            //Action Generic delegate
            Action<int, string> myActionTarget = new Action<int, string>(PrintMessageFromCar);
            myActionTarget(34,"test");

            //Function generic delegate
            Func<int, int, int> myFunctionTarget = new Func<int, int, int>(Add);
            var i = myFunctionTarget(1, 2);

            //Function generic delegate
            Func<int, int, string> myFunctionTarget2 = new Func<int, int, string>(SumFormatted);
            var text = myFunctionTarget2(1, 2);
        }

        //Method of action generic delegate
        public static void PrintMessageFromCar(int messageNo, string message)
        {
            Console.WriteLine("{0} Print Message One: {1}", messageNo, message.ToString());
        }

        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static string SumFormatted(int a, int b)
        {
            return (a + b).ToString();
        }
    }
}
