using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._2_CSharpAdvanced
{
    /*

       - .Net objects are allocated to memory known as the managed heap
       - They are later destoryed by a process called GARBAGE COLLECTION
       - You can use System.GC to interact with the garbage collector (most time you wont need to!)
       - To release internal unmanaged resources in a timely and perdicatable way the following can be implemented:
            - System.Object.Finalize()
            - IDisposable

        Classes, objects and references: STACK vs HEAP
        
            - When you use NEW keyword to create an object it actually returns a reference to the object on the heap
            - Reference is stored on the STACK and actualy object is stored on the HEAP
                - Note: Values types are always stored on STACK
            - Class file just describes what memory allocation should look like on the heap
            - Rule: Use NEW to create object and then forget about it... as soon as object goes out of scope GC will clear it and free memory
                    - No need for memeory management i.e. allocation and deallocation of objects: Which when goes wrong causes memory leaks
                    - Object that is still in scope is regarded as ROOTED
            - Rule: On object creation if memory heap is out of space GC will occur
            - You can null an object reference: It wont cause GC to occure straight away: But it doesnt do any harm to clearly state object is not required anymore (FOR next GC)
            - GC uses generation status on objects to prioratize what objects to clear first:
                - Generation 0 for newly created object (parameters or vars in small methods)
                - Generation 1 for objects that previously survived GC
                - Generation 2 that survived more than on GC round
                - If all G0 objects are clear and there is still not enough memory only then G1 objects will be clears
                - Since .net 4.0 GC can run on background thread to clear G1 objects left behind

        System.GC
            - Allows you to interface with GC
            - You will hardly ever need to use this: Unless you are working with unmanged resources
            - AddMemoryPressure: For a given object specify urgency level for GC
            - .Collect() can for GC you have to specific generation of objects (0,1,2)
            - .CollectionCount() tells you how many times a given generation has been swept
            - .GetGeneration() tells you the generation of an object
            - .SurpressFinalize() You can state if a given object can have its Finalize method called or not
            - .WaitForPendingFinalizers() Typically called after GC.Collect() and suspends all threads until all object finalizers have been called
                                          Suspension is good thing: Ensure your code doesnt call methods on objects that are being cleared
        When to force GC:
            - You app is about to enter a block of code that you dont want interrupted by GC
            - Your app has finished allocating a number of large objects that take up memory: And you need to tidy up
            - See example below
        */

    class ObjectLifeTime
    {
        public void Example()
        {
            //This is how you force GC
            GC.Collect();                       //Note parameters to force: WHAT generation and WHEN to collect
            GC.WaitForPendingFinalizers();
        }
    }
}
