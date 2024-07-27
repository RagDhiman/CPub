using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp6Net46._1_CSharpBasics;

namespace CSharp6Net46._2_CSharpAdvanced
{
    /*
    Event Keyword
    =============
    So you dont have to create methods to assign or unassign methods from your delegates invocation list (method list)
    The event keyword automatically creates:
        - Delegate registration and unregistration methods
        - Private Member variable for the delegate invocation list (method list)

    See example below
    */

    class GenericDelegatesWithEvents
    {
        public static void Example()
        {
            DragCar myDragCar = new DragCar("Nascar", "3434");
            myDragCar.Exploded += new DragCar.CarEngineHandler<string>(PrintMessageFromCar); //Add method delegate..note cand add more than one listner
            myDragCar.Imploded += PrintMessageFromCar; //You could just set methods like this
            myDragCar.Imploded += PrintMessageFromCar2; //You could just set methods like this

            myDragCar.Accelerate();
        }

        public static void PrintMessageFromCar(string message)
        {
            Console.WriteLine("Print Message One: {0}", message);
        }

        public static void PrintMessageFromCar2(string message)
        {
            Console.WriteLine("Print Message One: {0}", message);
        }
    }

    class DragCar : Car
    {
        public DragCar(string manufacturer, string carName) : base(manufacturer, carName) { }

        //1. Define a delegate type with signature for the methods it will invoke. Note: Delegate does not have to be delcared as part of class
        public delegate void CarEngineHandler<T>(T messageForCalled);

        public event CarEngineHandler<string> Exploded;     //In the background this will create add_explode to register methods and remove_explode to remove methods.. as well as a member variable for the delegate to store the method "invocation list"
        public event CarEngineHandler<string> Imploded;

        public void Accelerate()
        {
            if (1==2 && Exploded != null)
            {
                Exploded("The car is exploded!!");
            }
            else if (Imploded != null)
            {
                Imploded("The car is imploded!!");
            }
        }

        public void AccelerateCSharpSixVerions()    //C# 6 you can use ? auto null check but you have to call invoke..
        {
            if (1 == 2)
            {
                Exploded?.Invoke("The car is exploded!!");
            }
            else
            {
                Imploded?.Invoke("The car is imploded!!");
            }
        }
    }

}
