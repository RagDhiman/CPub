using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp6Net46._1_CSharpBasics;

namespace CSharp6Net46._2_CSharpAdvanced
{
    /*

    */

    class DelegateNotificationExample
    {
        public static void Example()
        {
            var ferrari = new RaceCar("Ferrari","F40");

            //Using registration method: register method witht he objects delegate member
            ferrari.RegisterWithCarEngine(new RaceCar.CarEngineHandler(PrintMessageFromCar));
            ferrari.RegisterWithCarEngine(PrintMessageFromCar2); //Theres also a shortcut to just pass the method name in!

            RaceCar.CarEngineHandler Handler3 = new RaceCar.CarEngineHandler(PrintMessageFromCar3);
            ferrari.RegisterWithCarEngine(Handler3);

            ferrari.UnRegisterWithCarEngine(Handler3);

            ferrari.Accelerate(); //Object methods that involves the delegate method

        }

        public static void PrintMessageFromCar(string message)
        {
            Console.WriteLine("Print Message One: {0}", message);
        }

        public static void PrintMessageFromCar2(string message)
        {
            Console.WriteLine("Print Message Two: {0}", message);
        }

        public static void PrintMessageFromCar3(string message)
        {
            Console.WriteLine("Print Message Three: {0}", message);
        }
    }

    class RaceCar: Car
    {
        public RaceCar(string manufacturer, string carName) : base(manufacturer, carName) { }

        //1. Define a delegate type with signature for the methods it will invoke. Note: Delegate does not have to be delcared as part of class
        public delegate void CarEngineHandler(string messageForCalled);

        //2. Define a member of the delegate type (Always declare as private: So that we can control or restrcit what the calling code can do with it: Instead use methods to ineterace with it)
        private CarEngineHandler listOfHandlers;    //Other option is to use EVENTS keyword..handlers and registration methods are provided 

                                                   //*** See 57_GenericDelegatesWithEvents.cs

        //3. Add registraction function for the caller.. Function to assign method to the delegates invocation list
        //Best to make CarEngineHandler member private to help encapsulation and instead provide a method to register methods
        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandlers += methodToCall;   // += is delgate multicasting i.e. allowing the assignment of more than one method.. in the background this calls delegate.combine
        }

        public void UnRegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandlers -= methodToCall;   // -= is delgate.remove() shortcut
        }


        public void Accelerate()
        {
            if (listOfHandlers != null)
            {
                listOfHandlers("The car is moving yepeeeeee!!");
            }
        }
    }

}
