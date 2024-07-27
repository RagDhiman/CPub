using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp6Net46._1_CSharpBasics;

namespace CSharp6Net46._2_CSharpAdvanced
{
    /*
    Generic collections provide type safety and performance by
        - Removing the need to box and unbox
        - Specific classes for collections to make type safe collections are NO longer required
            - Instead you just create a generic collection List<PlannedVisit> where type is specified

        - Generics are used everywhere in .net
            - classes, structures, interfaces and delgates (not with enums!)
            - You prounce "of T" i.e. List<T> is pronounced as "List Of T"
            - And you always specify the TYPE for the placeholder T

        - Generic intefaces ****
            - Note you can have nonGeneric interfaces
                   - IComparable, IEnumerator, IEnumerable and IComparer
                   - You have to do TYPE checks within each implementation. Extra work and risk of error
            - You have the generic equivlents:
                   - IComparable<T>, IEnumerator<T>, IEnumerable<T> and IComparer<T>
                   - Becaue you specify of T as a specific type you NO longer need to do type checks withint he implementation
                   - Always use the GENERIC EQUIVALENT
                   
    */
    class GenericCollection
    {
        public void Example()
        {
            //Using Class
            //===========
            List<Car> myCars = new List<Car>();
            myCars.Add(new Car("Ferrari","F2004"));

            Car myFirstCar = myCars[0]; //Type safey i know its a car and assignment wont error!

            //Type safety: This will error as onlu cars are allowed:
            //myCars.Add(123);

            //Using Value type
            //================
            List<int> myNumbers = new List<int>();

            myNumbers.Add(23); //No boxing or unboxing to System.object instead value type is just refernced
            myNumbers.Add(89);
            myNumbers.Add(11);

            //Generic Type Parameters for Generic Methods
            //You can have a nongeneric class that has one method that requires type parameter
            int[] myInts = new int[] { 1, 2, 3, 4, 5 };

            Array.Sort<int>(myInts);    //Non generic Array has generic method to sort an array

        }
    }
}
