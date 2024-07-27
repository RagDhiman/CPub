using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._2_CSharpAdvanced
{
    /*
        Dynamically loading an external assembly
        ========================================
        - To see whats in it
        - Use the assembly object
        - Assembly.Load() will load dlls by name that are local to the app dir
        - Assembly.LoadFrom() will take full path and load any dll from any location. You have to provide full path
        - pass in
        - C:\Users\ragub\Google Drive\AppInjectionNetSite - Copy\AIMvc\bin\AIMvc.dll

    */
    class DynamicLoading
    {
        public static void Example()
        {
            string asseblyName = "";
            Assembly asm = null;

            do
            {
                Console.WriteLine("\nEntry assembly name:");
                Console.WriteLine("or enter Q to quit");

                asseblyName = Console.ReadLine();

                if (asseblyName.ToUpper() == "Q")
                {
                    break;
                }

                try
                {
                    asm = Assembly.LoadFrom(asseblyName);
                    DisplayTypesInAsm(asm);
                }
                catch (Exception e)
                {
                    Console.WriteLine("**** Error ****");
                    Console.WriteLine("Method or Property Name: {0}", e.TargetSite);
                    Console.WriteLine("Method or Property: {0}", e.TargetSite.MemberType);
                    Console.WriteLine("Class: {0}", e.TargetSite.DeclaringType);
                    Console.WriteLine("Message: {0}", e.Message);
                    Console.WriteLine("Source: {0}", e.Source);
                    Console.WriteLine("Stack: {0}", e.StackTrace);

                    Console.WriteLine("Help Linke: {0}", e.HelpLink); Console.WriteLine("Sorry Type not found!");
                }
            } while (true);
        }


        public static void DisplayTypesInAsm(Assembly asm)
        {
            Console.WriteLine("Assembly name {0}", asm.FullName);
            Type[] asTypes = asm.GetTypes();
            foreach(Type t in asTypes)
            {
                MetaDataUsingReflection.printTypeDetails(t);
            }
        }
    }
}
