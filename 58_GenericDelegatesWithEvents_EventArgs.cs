using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp6Net46._1_CSharpBasics;

namespace CSharp6Net46._2_CSharpAdvanced
{
    /*
    Generic delegates using Event and EventArgs
    ===========================================
    Microsofts event pattern recommends when firing events then event methods following the signature for events: Two parameters
    - System.Object: Which is normally the object that raised the event
    - System.EventArgs: Which contains data related to the event. 
                        If you want to send extra data to event you should DERIVE from this CLASS

    - 1. Create custom event args class.. see below
    - 2. Change the delegate definition to use EVENT signature
    - 3. Change the event invocation call to satisfy new signature
    - 4. Change the methods that are raised in response to the event to have mathing sig
            - In the method you could not only get extra data from custom EventArgs but you can access the event sender by casting it

    - 5. Note: Because Events with a sig of System.Object and System.EventArgs is so common the framework provides a:
        Generic EVENTHANDLER<T>... see below look for event marked with 5
    */

    class GenericDelegatesWithEvents_with_EventArgs
    {
        public static void Example()
        {
            F1Car myDragCar = new F1Car("Nascar", "3434");
            myDragCar.Exploded += PrintMessageFromCar;
            myDragCar.Imploded += PrintMessageFromCar; 
            myDragCar.Imploded += PrintMessageFromCar2; 

            myDragCar.Accelerate();
        }

        public static void PrintMessageFromCar(Object sender, F1CarEventArgs e)
        {
            if (sender is F1Car)
            {
                Console.WriteLine("Sender is F1 Car {0}", ((F1Car)sender).CarName);

            }
            Console.WriteLine("Print Message One: {0}", e.msg);
        }

        public static void PrintMessageFromCar2(Object sender, F1CarEventArgs e)
        {
            if (sender is F1Car)
            {
                Console.WriteLine("Sender is F1 Car {0}", ((F1Car)sender).CarName);

            }
            Console.WriteLine("Print Message One: {0}", e.msg);
        }
    }

    class F1Car : Car
    {
        public F1Car(string manufacturer, string carName) : base(manufacturer, carName) { }

        // - 2. Change the delegate definition to use EVENT signature
        public delegate void CarEngineHandler(Object sender, F1CarEventArgs e);

        public event CarEngineHandler Exploded;    
        public event EventHandler<F1CarEventArgs> Imploded;     //5. Could use GENENERIC Event Handler. then we wouldnt need above two lines :-)

        public void Accelerate()
        {
            if (1 == 2 && Exploded != null)
            {
                Exploded(this, new F1CarEventArgs("The car is exploded!!")); // -3.Change the event invocation call to satisfy new signature
            }
            else if (Imploded != null)
            {
                Imploded(this, new F1CarEventArgs("The car is imploded!!"));
            }
        }

        public void AccelerateCSharpSixVerions()    //C# 6 you can use ? auto null check but you have to call invoke..
        {
            if (1 == 2)
            {
                Exploded?.Invoke(this, new F1CarEventArgs("The car is exploded!!")); //-3.Change the event invocation call to satisfy new signature
    }
            else
            {
                Imploded?.Invoke(this, new F1CarEventArgs("The car is imploded!!"));
            }
        }
    }

    //    - 1. Create custom event args class.. see below
    public class F1CarEventArgs: EventArgs
    {
        public readonly string msg;
        public F1CarEventArgs(string message)
        {
            msg = message;
        }
    }

}
