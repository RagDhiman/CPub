using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._2_CSharpAdvanced
{
    /*
        First see 69 and 70..

        Disposable objects
        ==================
        - What if you are using unmanaged resources and cant wait for GC or the finalization queue as both make you wait to clear up
        - Implement IDisposable and the disposable method on your class and then you can call Dispose() before object goes out of scope
        - And if you have objects within your object that also need Disposing you can call Dispose() within Dispose()
        - GC knows nothing and IDispose and never calls dispose it self and therefore all objects in Dispose() are available like normal
        - Always check to see if object supports IDisposable before calling Dispose() using IS or AS
        - You should try and always check to see if object supports IDisposable and then call its Dispose() when you are finished with it
                - The writer of object has implemented it for a reason: If you forget dont worry GC at later time will clear it
        - Summary: If object implments IDispose always call Dispose() as a safe action
            - See example below

        Using
        =====
        - Dispose() should normally be also called in the FINALLY section of try and catch when using a resource to tidy up etc
        - Doing try and catch everywhere for objects that need Dispose() calling can be cumbersome
        - "Using" is a SHORTHAND to doing this: In the CIL i.e. intermediary languge using is translated to try catch and then dispose in finally!
        - Note "Using" will comile time error on objects that dont support IDispose
        - You can also declare multiple objects in using ie in Using(x, y ) {} and dispose will be called on both

        - Finalize vs Dispose
        ======================
        - Both do same thing i.e. clear up so which one should you use to clear up UNMANAGED resource
        - Use BOTH: As IDispose relies on ojbect user to call Dispose() if they forget GC and Finalize will clear up unmanaged resource
            - If you dont and user forgets to call Dispose() the unmanaged resources will be allocated memory indefinetly
            - Then in Dispose() call GC.SurpressFinalize.. telling compiler you have already clear unmanaged code and no need to for it to call finalize
            - Choose to auto implement IDisposable and VS will implement the best pattern to support both..see resource class below
    */

    class DisposableObjects
    {
        public void Example()
        {
            DisposeExample();
            UsingExample();
        }

        private void UsingExample()
        {
            using (var fs = new FileStream("C:\test.txt", FileMode.Append)) {
                // Do stuff on FS.. even if there is an error OR there isnt fs.Dispose will be called
                //CIL will concert this to try catch and finally with a fs.dispose();
            }
        }

        private void DisposeExample()
        {
            var fs = new FileStream("C:\test.txt", FileMode.Append);

            //Do some stuff with file

            if (fs is IDisposable)
            {
                fs.Dispose();           //filestream is a funny one.. fs.Close() actually does same thing as fs.dispose()
            }
        }
    }

    class myResourceManager: IDisposable
    {
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        //Automatically called by GC or App domain shutdown
        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~myResourceManager()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
