using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp6Net46._1_CSharpBasics;

namespace CSharp6Net46._2_CSharpAdvanced
{
    /*

        Always using Generic Collections instead of nongenerics:
            - System.Collection.Generic

        Also for .Net interfaces always check to see if there is a generic equivalent and aim to use that instead:
            - ICollection<T>
            - IComparer<T>
            - IDictionary<TKey, TValue>
            - IEnumerable<T>
            - IEnumerator<T>
            - IList<T>
            - ISet<T>

        Generic Collections that use these interfaces. Again aim to use these when you need a collection:
            - Dictionary<TKey, TValue>
            - LinkedList<T>
            - List<T>
            - Queue<T>
            - SortedDictionary<TKey, TValue>
            - SortedSet<T>
            - Stack<T>



    */
    class GenericInterfaces_Collections
    {
        public void Example()
        {
            //List
            //====

            //Init of a generic list with values
            List<int> myNumbers = new List<int> { 1,2,3,4,5,6,7};

            //With objects
            List<Car> myCars = new List<Car>
            {
                new Car("Ferrari","F40"),
                new Car("Ferrari","F40"),
                new Car("Ferrari","F40")
            };

            myCars.Insert(2, new Car("Williams","W13"));    //List has a cool method which allows you to insert object at specific point

            foreach(Car theCar in myCars) {
                Console.WriteLine(theCar.CarName);
            }

            //Stack (last in first out)
            //=====
            Stack<Car> myCarStack = new Stack<Car>();

            myCarStack.Push(new Car("Ferrari", "F40"));
            myCarStack.Push(new Car("Williams", "W12"));
            var NameOFLastCarIn = myCarStack.Peek().CarName;  //if stack is empty it will raise an exception..wrap in try\catch

            myCarStack.Pop(); //removes the last item in... if stack is empty it will raise an exception..wrap in try\catch

            //Queue (first in first out)
            //==========================
            Queue<Car> myCarQueue = new Queue<Car>();
            myCarQueue.Enqueue(new Car("Ferrari", "F40"));
            myCarQueue.Enqueue(new Car("Williams", "W12")); //Add object to end of queue

            Car FirstCar = myCarQueue.Dequeue(); //removes object at begining of queue

            var NameOFFirstCarIn = myCarQueue.Peek().CarName;  //if stack is empty it will raise an exception..wrap in try\catch
        }
    }
}
