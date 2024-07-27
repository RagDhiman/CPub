using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._1_CSharpBasics
{
    class EnumTest
    {
        enum EmpType
        {
            Manager, //Default value is 0
            Grunt,
            Contractor,
            VisePresident
        }

        enum EmpTypeTwo
        {
            Manager = 102, //Force first value
            Grunt,
            Contractor,
            VisePresident
        }

        enum EmpTypeThree
        {
            Manager = 102, 
            Grunt = 2,
            Contractor = 4,
            VisePresident = 101
        }

        public static void Example()
        {
            EmpType managerType = EmpType.Manager;

            Console.WriteLine("Emp is {0} that has a value of {1}", managerType.ToString(), (Byte)managerType);

            //Get values of enum as array
            Array EnumData = Enum.GetValues(managerType.GetType());

            EvaluateEnum(managerType);

            Console.ReadLine();

        }

        static void EvaluateEnum(System.Enum e)
        {
            Console.WriteLine("=> Information about enum {0}", e.GetType().Name);

            Console.WriteLine("=> Underlying storage type {0}", Enum.GetUnderlyingType(e.GetType()));

            Array enumData = Enum.GetValues(e.GetType());
            Console.WriteLine("=> This enum as the following number of enums {0}", enumData.Length);

            for(int i = 0; i < enumData.Length; i++)
            {
                Console.WriteLine("=> Name:{0} Value:{1}", enumData.GetValue(i),(int)enumData.GetValue(i));
            }
        }

    }
}
