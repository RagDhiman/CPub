using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp6Net46._2_CSharpAdvanced
{
    class _91_MultiThreading
    {
        /* 
        Thread
        ======
        - A path of execution through an application
        - Application normally starts on a single thread (when main is fired by clr)
        - However application can create other threads to improve responsivness 
        - Doesnt necessairly itll run faster e.g. on single core machine just more responsive

        - System.Threading - can be used to buid multithreaded apps
        - Get the thread currently executing this method
            
            Thread currThread = Thread.CurrentThread;

        - Single AppDomain can have multiple threads
        - However a thread can cross different AppDomains
        - However a single thread can only execute within a single AppDomain at a given time
        
        - Get AppDomain executing current thread
        
            Thread.GetDomain();

        - Thread also exexutes within a context: Which can by changed by the CLR

            Thread.CurrentContext();

        - CLR moves threads in and out of AppDomains and Contexts.. you dont have to give a shit that this is happening

        Concurrency Problem
        ===================
        When you execute a thread: It doesnt always happen straight away.. CLR\ThreadSchedules decides
        - You execute Thread1 which works on a method of  a particular object
        - You execute Thread2 which does the same on the same object instance  
        CLR pauses Thread1 to give Thread2 a turn, Thread2 might be working with an object in the wrong state
        because Thread1 didnt complete
        - You should try and use ATOMIC operation to get round this issue
        - But atomic operations are very rare in .net
        - This is the issue with multithreaded apps, multiple threads work on the same resource at same time

        Role of Thread Synchronization
        ==============================
        - To protect resources especially shared resouces and control access from other threads in multithreading you should use threading primitives:
            - locks
            - monitors
            - [Syncronization] attribute
        This is to control access from other threads
        Although challenges of multi threading are tricky, .net provides following to make things easier:
        - Asynchronous Delegates (legacy before we got async and await)
        - Types in the System.Threading name space
        - Task parallel library (TPL)
        - and CSharp async and await keywords


        */
        public void Example()
        {
            //Get the thread currently executing this method
            Thread currThread = Thread.CurrentThread;

            //Get AppDomain executing current thread
            AppDomain a = Thread.GetDomain();

            //Get context the current thread is currently operating under
            Context ctx = Thread.CurrentContext;

        }
    }
}
