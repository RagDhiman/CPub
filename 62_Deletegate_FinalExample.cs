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
    1. Use of Event keyword: Which automatically creates 
        - Delegate registration and unregistration methods
        - Private Member variable for the delegate invocation list (method list)
    2. Use events signature. All event methos now have two parameters as recommended by microsoft:
        - System.Object: Sender of event
        - System.EventArgs: Either that or derived class to include custom data
    3. Use of generic delegate type provided by the .net framework "EventHandler"
        If your signature is System.Object and System.EventArgs and the delegate name doesnt matter to you: Use generic delegate type provided
    4. Use of ? .. automatic null check for delegate types. No nullexpcetion is thrown if method is not set agianst delegate
        Note: C# 6.0 only
    5. Lambda expressions to define delegate methoda

    */

    class Delegate_FinalExample
    {
        public static void Example()
        {
            UltimateCar myDragCar = new UltimateCar("Nascar", "3434");

            //Single line lambda .. no brackets
            myDragCar.Exploded += (System.Object o, UltimateCarEventArgs e) => Console.WriteLine("Print Message One: {0}", e.msg);

            //Multiline lamba
            myDragCar.Imploded += (System.Object o, UltimateCarEventArgs e) =>
            {
                Console.WriteLine("Print Message One: {0}", e.msg);
                Console.WriteLine("Print Message One: {0}", e.msg);
            } ;

            myDragCar.Accelerate();
        }

    }

    class UltimateCar : Car
    {
        public UltimateCar(string manufacturer, string carName) : base(manufacturer, carName) { }

        public event EventHandler<UltimateCarEventArgs> Exploded;
        public event EventHandler<UltimateCarEventArgs> Imploded;     

        public void Accelerate()   
        {
            if (1 == 2)
            {
                Exploded?.Invoke(this, new UltimateCarEventArgs("The car is exploded!!")); 
            }
            else
            {
                Imploded?.Invoke(this, new UltimateCarEventArgs("The car is imploded!!"));
            }
        }
    }

    //    - 1. Create custom event args class.. see below
    public class UltimateCarEventArgs : EventArgs
    {
        public readonly string msg;
        public UltimateCarEventArgs(string message)
        {
            msg = message;
        }
    }

}
