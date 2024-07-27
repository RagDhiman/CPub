using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp6Net46._1_CSharpBasics;

namespace CSharp6Net46._2_CSharpAdvanced
{
    /*
        We need structures to hold objects.
        We have array but array is limited by the size defined on initlization.
        You can resize an array using Resize()<T> but this is highly ineffienct and all it does is create an new array in background

        To overcome limitation of arracts .net contains a number of collection classes and there are two types:
            NonGeneric Collections:
                Found in System.Collections
                Loosley typed i.e. mainly operate on System.Objects
                Not type save
            Generic Collections:
                Found in System.Collections.Generic
                Tightly typed i.e. you set type of collection items first. Type Safe. For example List<T>

        Here we focus on NonGeneric Collections (System.Collections)
            - ArrayList
            - BitArray
            - Hashtable
            - Queue
            - SortedList
            - Stack
        Some more NonGeneric Collections (System.Collections.Specalized)
            - HybridDictionary
            - ListDictionary
            - StringCollection
            - BitVector32

        Most implement one for more of the following
            IColletion
            ICloneable
            IDictionary
            IEnumerable
            IEnumerator
            IList

        See arrayList example below. Notice how you can add remove as many items as you want!

        Note: You should AIM to use GENERIC COLLECTIONS instead of the above nongenerics!!!!
        Many disadvantages of using nongeneric collections
        - Not type safe
              - 
        - Perforamnce issues
              - Designed to work with System.Object and therefore value types are boxed to reference type (system.object) 
              - Boxing and unboxing is performance drain as well as error prone... Unbox a long from object into an int will ERROR
                    - You have to unbox to the type your originally boxed from orelse it will error
                    - In the olden days i.e. generic free days, you would create a collection class for each type (Could ccl!)
                    - Collection class in the background would have a nongeneric collection but all the methods on 
                        the collection class would only allow in one type. This was used to get round type safety issue!
                    - We do this is CCL.. plannedVisit plannedVisits (collection class)
              - Using add on array list with an int will required the int to be boxed to an object
                    - And BOXING and UNBOXING i.e. changing value type to reference type is very expensive
                    - Generic Collections solve this issue

    */


    class NonGenericCollections
    {
        public void Example()
        {
            ArrayList myArrayList = new ArrayList();

            myArrayList.Add("Test");
            myArrayList.Add(new Car("Ferrar","F23"));
            myArrayList.Add(34); //*** This will be boxed to an ref type i.e. System.Object from value type

        }
    }
}
