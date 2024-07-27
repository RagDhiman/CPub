using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using CSharp6Net46._1_CSharpBasics;

namespace CSharp6Net46._2_CSharpAdvanced
{
    /*
        Extension methods
        =================
        - Sometimes you have classes that you need to extend but you cant change
        - You cant change because clients rely on the class and you must ensure backwards compatibility
        - For some reason they cant have a new version of the recompiled class
        - What can you do:
            - Create a derived class based on the original and extend that way
                - Con: Two classes to maintain and work with in the future. 
                       Original class also might be a strcuture or a sealed class so u cant inherit
            - Extension methods on the orignal class it extend
                - Extension methods must be declared in a seperate static class
                - And therefore the extension method must be static
                - The static class does not have to have one to one relationship with the class thats being extended
                    - The static class can contain many static extension methods for extending different classes

        Note: - Extension methods live NOT only in a class but also the NAMESPACE the class is defined in
              - Whereever you want to use the extension method you have to import the namesapce using USING statement
              - In fact is good to keep extensions in a seperate NAMESPACE AND LIBRARY.. then clients can choose to have the extension
                    - By importing the library and using the namespace

        - Extension methods for Interfaces
        ==================================
        - You can also define an extension method for an interface: All classes that implement that interface then receive that method
        - See IEnumerable example below:
    */

    class ExtensionMethods
    {
        public static void Example()
        {
            // int value
            int myInt = 3543;
            myInt = myInt.ReverseDigits();

            // Dataset assembly info
            System.Data.DataSet d = new System.Data.DataSet();
            d.DisplayAssemblyInformation();

            //Interface Extension Methods
            List<int> myList = new List<int> { 1,2,3,4,5,6};
            myList.PrintList();

            Stack<Car> myCarStack = new Stack<Car>();

            myCarStack.Push(new Car("Ferrari", "F40"));
            myCarStack.Push(new Car("Williams", "W12"));
            myCarStack.PrintList();

        }
    }

    static class myExtensions { 

        //Extension Method for System.Object i.e. everything
        public static void DisplayAssemblyInformation(this Object obj)
        {
            Console.WriteLine("{0} lives in the following assembly: {1}\n",obj.GetType().Name, Assembly.GetAssembly(obj.GetType()).GetName().Name);
        }

        //Extension Method for System.Object i.e. everything
        public static int ReverseDigits(this int i)
        {
            char[] digits = i.ToString().ToCharArray();

            Array.Reverse(digits);

            string newDigits = new string(digits);

            return int.Parse(newDigits);
        }

        //Extension Method for anything that implements IEnumerable interface
        public static void PrintList(this System.Collections.IEnumerable iterator)
        {
            foreach (var item in iterator)
            {
                Console.WriteLine(item);
            }
        }

    }

}
