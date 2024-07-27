using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace CSharp6Net46._2_CSharpAdvanced
{
    /*
        Late Binding
        ------------
        - Using an external assembly and its type and invoking members at runtime. Without knowing the type at compile time
        - Useful for making applications extendable
        - System.Activator class is key for late binding

        - Creating an instance of a type
        ---------------------------------
        - Use Activator.CreateInstance()
        - There are many overloads to give flexibility
        - Note we are using the assembly object
        - Assembly.Load() will require the external assembly "F1Racing" to be in same directory
        - Because F1Racing is a reference type it will automatically be put in same dir. In real life you wouldnt have reference

        - Invoking methods
        -------------------
        - Because you dont know the types in the assembly and you are handling everything as Object HOW can you call specific methods?
        - You cant do normaly cast because you dont know the type at compile time
        - Answer is reflection
        - And you use Type object to get methodinfo reference and NOT the object instance

    */

    class LateBinding
    {
        public static void Example()
        {
            DoSomeLateBinding();
            DoSomeLateBindingAndCallMethod();

            DoSomeLateBindingAndCallMethodWithParameters();
        }

        private static void DoSomeLateBindingAndCallMethodWithParameters()
        {
            //Load assembly
            Assembly asm = Assembly.Load("F1Racing");

            //First get meta data for racecar
            Type RaceCarType = asm.GetType("F1Racing.RaceCar");

            //Create instance of the type
            Object obj = Activator.CreateInstance(RaceCarType);

            //Using TYPE and not the object get reference to methodinfo for our method
            MethodInfo mi = RaceCarType.GetMethod("MethodWithParameters");
            //On methodinfo.invoke pass in the instance 
            mi.Invoke(obj, new object[] {true, "Method with parameters invoked woohooo" }); //Parameters are passed in as object array!
        }

        private static void DoSomeLateBindingAndCallMethod()
        {
            //Load assembly
            Assembly asm = Assembly.Load("F1Racing");

            //First get meta data for racecar
            Type RaceCarType = asm.GetType("F1Racing.RaceCar");

            //Create instance of the type
            Object obj = Activator.CreateInstance(RaceCarType);

            //Using TYPE and not the object get reference to methodinfo for our method
            MethodInfo mi = RaceCarType.GetMethod("ConfirmCarProfile");
            //On methodinfo.invoke pass in the instance 
            mi.Invoke(obj, null);   //null passed in for parameters
            
        }

        public static void DoSomeLateBinding()
        {
            //First Get Assembly
            //-------------------
            //We are using load because its a private assembly

            Assembly asm = null;
            try
            {
                asm = Assembly.Load("F1Racing");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Create Type using assembly reference
            //-------------------------------------
            try
            {
                //First get meta data for racecar
                Type RaceCarType = asm.GetType("F1Racing.RaceCar");

                //Create instance of the type
                Object obj = Activator.CreateInstance(RaceCarType);

                Console.WriteLine("Created {0} instance using late binding", obj);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
