using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._2_CSharpAdvanced
{
    /*
    Delegates
    =========
    1. Within .net the preffered method of defining and responding to CallBacks
    2. Callback is a way of responding back to the calling code at possibly a later time. Ideal for updaing UI's etc
    3. In .net a delegate is a type-safe object that points to a method or a number of methods that can be called at a later time
        - Type safe: If you try pointing the delegate at a method that doesnt match the delegate signature you get an error
    4. Unlike c++ function pointers, delegates are classes

    Delegate classes maintain three important pieces of information:
    - Address of method(s) it calls
    - Parameters for this method(s)
    - Return type of this method(s)

    In the background delegate has generated a class with three methods
    .Invoke()  Used to invoice the method and has the signature u specified as part of delegate definition
    .BeginInvoke()  Used to asyn call to the method: Has parameters from sig you defined for delegate and additional parameters for callback address (doesnt have returnt type)
    .EndInvoke() Same deinition as beginInvoice but has return type you defined on delegate definition


    Delegates can be made to do synchronous callbacks or asynchronous callbacks (uses second thread)
    
    Each method assigned to a delegate class if of type delegate... Print delegate methods below

    Here is our delegate
    It can have any name and in the background it creates a class
    And it can have any method assigned to it that has the same signature */
    public delegate int myAnyName(int p1, int p2);

    //This class contains methods our delegate will point at
    class SimpleClass
    {
        public static int Add(int p1, int p2)
        {
            return p1 + p2;
        }

        public static int Subtract(int p1, int p2)
        {
            return p1 - p2;
        }
    }

    public class DelegateSynchronous
    {
        public void Example()
        {
            //Create a myAnyName delegate object that points to simpleclass method
            myAnyName D = new myAnyName(SimpleClass.Add);       //Could be static or instance method

            //Invoice the delegate method
            D(12, 23);
            //Which is actually same as
            D.Invoke(23, 23);

            PrintDelegateMethods(D);
        }

        public void PrintDelegateMethods(Delegate DelegateObject)
        {
            foreach (Delegate d in DelegateObject.GetInvocationList())
            {
                Console.WriteLine("Method name: {0}", d.Method);
                Console.WriteLine("Type name: {0}", d.Target);  //Static methods will not display class name

            }
        }
    }


}
