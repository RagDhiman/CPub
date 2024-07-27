using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._2_CSharpAdvanced
{
    /*
        Only worry about implementing Finalizable objects if:
        - Need to tidy up internal unmanaged resources used by the class (very rarley required)
                Managed resources:      .net types i.e. managed by .net runtime therefore GC for you
                Unmanaged resources:    Raw OS file handles, raw unmanaged DB connections, chunks of unmanaged memory or anything else
                                        - Unmanaged reources used when using COM Interoperability objects OR OS API's like PInvoke
                                        - Anything that .net CLR does not manage
        - All System.Objects have virtual method Finalize. By default it does nothing
        - Override this method in your class if you want to implement tidy up code
        - Note: Its protected method: YOU DONT call it 
            - The Garbase Collector calls it for you
            - Or when the AppDomain is unloaded from memory: It calls finalize on all your objects

        - Structures cant have this method: Value types and therefore not on the HEAP

        Syntax for overriding virtual finalize method from System.Object is NOT TYPICAL override. See below
        Why: Compiler treats this override differntly: Not protected method by default

        Summary: Avoid using unmanaged resources and therefor avoid the need to finalize as its slow process

    */
    class FinalizableObjects
    {
        ~FinalizableObjects()
        {
            //Clear up unmanaged resource here!
        }
    }
}
