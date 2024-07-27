using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp6Net46._1_CSharpBasics;

namespace CSharp6Net46._2_CSharpAdvanced
{
    /*
    Using Anonymous methods with delegates
    ===========================================
    Somestimes methods for delegates are a bit out of place i.e. they might not be called by the class they sit in
    Only called by the object using the delegate call
    Its worth considering anonymous methods:
        - Note anonymous methods can access variables in the method they are defined in known as outer variables
        - They cant access the ref or out parameters of the defining method
        - Cant have local vars with names that overlap outer method

    */

    class Delegates_AnonymousMethods
    {
        public static void Example()
        {
            F1Car myDragCar = new F1Car("Nascar", "3434");

            //Anonymous method: No parameters for event if not required
            myDragCar.Exploded += delegate {
                Console.WriteLine("Car has exploded");
            };

            //Anonymous method: Has parameters for event if required
            myDragCar.Imploded += delegate (Object sender, F1CarEventArgs e) {
                if (sender is F1Car)
                {
                    Console.WriteLine("Sender is F1 Car {0}", ((F1Car)sender).CarName);

                }
                Console.WriteLine("Print Message One: {0}", e.msg);
            };

            myDragCar.Accelerate();
        }

    }

}