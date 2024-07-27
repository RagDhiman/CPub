using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._2_CSharpAdvanced
{
    /*
        Attributes
        ----------
        - You can use reflection to get metadata for types i.e. clases and their members etc
        - Attributes allow you to embed extra infromation against your types and their members
        - All attributes have a base class of System.Attribute
        - You can also create your own by deriving from teh above

        - Some .net attribute examples
            - [CLSCompliant]    states your type is CLS compliant and will work in all .net languages
            - [Obsolete]        Used to mark class or memebers as obsolete to prevent further use
            - [Serilizable]     States that a type can be converted to a stream so that it can be persisted
                                See example below
            - [Nonserilizable]  Not able to do above
            - etc.. many more and you can create your own!

        - Note: Attributes are only useful when other code reads the values and uses them
        - Note: All attributes are actually suffixed with attribute but .net compiler allows you to omit the attribute keyworkd

        - It also best to create custom attributes as sealed attributes.. see custom example below (security reasons!)

        - Attributes with parameters
        ----------------------------
        - For example obsolete parameter
        - Has a constructor with parameters
        - Parameters are actually set when the type is refelected on
        
        - Restricting attributes
        ------------------------
        - You can restrict your custom attribute useage
        - by applying [AttributeUsage] attribute to your custom attribute
        - then you can restrict
            - Type of object or member attribute can be applied to (using AttributeTargets enum)
            - If multiple versions of the same attribute can be applied to the same object
            - If derived classes will inherit attributes applied to the parent object

        Assembly Level Parameters
        -------------------------
        - You can apply attributes to all types in your project by defining assebly type attributes
        - You declare them in any source file outside of a namesapce

        [Assembly: CLSCompliant(True)] i.e. make all public members CLS compliant

        - AssemblyInfo.cs is an ideal place to define these

        - Reading the attributes
        -------------------------
        - Some other software or code needs to read the attribute info inorder to act on them and make then useful
        - You can either to early binding reading or late binding
        - early binding
            - requires you to know the attribute type at compile time


    */

    class Attributes
    {
        public void Example()
        {
            //Reading attributes using early binding
            //----------------------------------------
            Type t = typeof(Laptop);    // Get Type first

            object[] customAttributes = t.GetCustomAttributes(false);    //Use type method to get attribues

            foreach(LaptopDescriptionAttribute a in customAttributes)
            {
                Console.WriteLine(a.Description);
            }

            //Using attributes using late binding
            //-----------------------------------

            //Load assembly
            Assembly asm = Assembly.Load("F1Racing");

            //First get meta data for RaceCarDescriptionAttribute
            Type RaceCarDesc = asm.GetType("F1Racing.RaceCarDescriptionAttribute");

            //Get property of attribute
            PropertyInfo pi = RaceCarDesc.GetProperty("Description");

            //Get all types in assembly
            var types = asm.GetTypes();

            //Going through all types and get any attributes of type raceCarDesc
            foreach(Type asmType in types)
            {
                object[] objs = asmType.GetCustomAttributes(RaceCarDesc,false);

                //Not iterate over each attribute
                foreach(object o in objs)
                {
                    Console.WriteLine(pi.GetValue(o, null));
                }
            }
        }
    }

    [Serializable, Obsolete("This class is obsolete now!")] //You can also stack them up
    [LaptopDescription("Super fast machine")]
    class Laptop
    {
        public int RAM { get; set; }
        public string CPU { get; set; }
        public int DiskSpace { get; set; }

        [LaptopDescription(Description = "Slower than this model")]
        public Laptop PreviousModel { get; set; }

        [NonSerialized]
        float Hertz;

    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, Inherited = false)]
    public sealed class LaptopDescriptionAttribute: Attribute
    {
        public string Description { get; set; }
        public LaptopDescriptionAttribute(string desc)
        {
            Description = desc;
        }

        public LaptopDescriptionAttribute() { }

    }

}
