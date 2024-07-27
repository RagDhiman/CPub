using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._2_CSharpAdvanced
{
    /*
        Lazy Loading
        ============
        - You have seen its important to worry about memory and object creation to certain degree even with GC
        - What if you have a class with a member variable that is large in terms of memory: 
            However the client of the class MAY or MAY NOT use it.
        - This is where you can use Lazy<> i.e. lazy loading
        - By using Lazy<> you are telling the runtime only init this object when .value is accessed
        - So if object is never accessed by client you never create an instance!

        - Use lazy loading to:
            - Avoid unecessary creation of objects
            - Avoid uncessary use of expensive resources (remote resource, databases etc)

        - Lazy<>
            - Note by detault the default of the constructor is used
            - What if you need to call another constructor and or call additional logic:
                - Good news is lazy supports delegate parameter
                - Delegate type is System.Func<> where return type is T from Lazy<T>.. you will not need to pass parameters in
                - To make it more streamlined pass in a lambda expression instead of a target method for the delegate
                - See example below

    */
    class LazyLoading
    {
        private Lazy<CarCollection_GenericDictionary> myCars = new Lazy<CarCollection_GenericDictionary>();


        private Lazy<CarCollection_GenericDictionary> myCarsTwo = new Lazy<CarCollection_GenericDictionary>(() =>
                {
                    // Some additional logic here!!
                    return new CarCollection_GenericDictionary(); //Choose your own constructor!!

                }
            );


        public CarCollection_GenericDictionary GetMyCarsWithDefaultConstructor()
        {
            return myCars.Value;    //init here
        }

        public CarCollection_GenericDictionary GetMyCarsTwo()
        {
            return myCarsTwo.Value; //Lambda above fired with additional logic and or your own choice of construcot
        }
    }
}
