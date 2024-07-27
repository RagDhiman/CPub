using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._2_CSharpAdvanced
{
    public class MultiThreading_AsyncDelegates
    {
        /*
        
        .Net delegate
        -------------
        - type-safe, object oriented, function pointer
        - System.MulticaseDelegate which derives from System.Delegate
        - Using these delegates can maintain a list of method addresses that can be invoked later
        */

        /// Examples of delegate
        public delegate int BinaryOP(int x, int y);

        /*
        This delegate can point at a method that takes two ints and returns an int

        For these delegate a class will be generated in the background with Invoke method
        - Invoke method call explitly or implicitly by just call name of object
        - Invoke works in a sync way (aka blocking)
        - Calling thread is made to wait
         */

        public void SyncDelegateCallExample()
        {
            var b = new BinaryOP(Add);

            //b is invoked in a sync manner i.e uses and blocks current thread
            var answer = b(1, 1);
        }
        
        public static int Add(int x, int y)
        {
            return x + y;
        }

        // How do you invoke a delegate time Asynchronously?
        // - This functionality is already built into the type
        // - .BeginInvoke() and .EndInvoke()
        // - .BeginInvoke(int x, int y, AsyncCallBack, object)
        //      - First two parameters are our method parameters for function
        //      - AsyncCallBack =
        //      - Object =
        //      - returns IAsyncResult which is later passed tp EndInvoke and contains result
        // - .EndInvoke(IAsyncResult)
        //      - Has the return type the same as the function the delgate points at
        //      - has one parameter of IAsyncResult = received from begin invoke and contains result

        public void AsyncDelegateCallExample()
        {
            var b = new BinaryOP(Add);

            //call delegate in async way
            IAsyncResult r = b.BeginInvoke(10, 10, null, null);
            //The add will be invoked by BeginInvoke on a separate thread!

            Console.WriteLine("Do some more work and continue on main thread!");

            //obtain result when ready! We have to wait for it to complete here now
            int answer = b.EndInvoke(r);
        }

        //Synchronizing the Calling Thread
        //--------------------------------
        // - Above async exmple we end up waiting in sync way anyway for the result at the end!
        // - Instead, to allow the calling thread to workout if the async method is complete
        //   IAsyncResult features IsCompleted property and using this calling thread can workout
        //   if method is complete before calling EndInvoke() or else just carry on with something else

        public void AsyncDelegateCallExampleTwo()
        {
            var b = new BinaryOP(Add);

            //call delegate in async way
            IAsyncResult r = b.BeginInvoke(10, 10, null, null);
            //The add will be invoked by BeginInvoke on a separate thread!

            while(!r.IsCompleted) {
                Console.WriteLine("Do some more work and continue on main thread!");
            }

            //obtain result when ready! We have to wait for it to complete here now
            int answer = b.EndInvoke(r);
        }
    }
}
