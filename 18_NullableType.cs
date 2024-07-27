using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._1_CSharpBasics
{
    class NullableType
    {
        public static void Example()
        {
            //Value Types: Like bool or ints must alawys have a value
            //Ref Types: Can have a null value i.e. when they are not initlised
            //For value type sometimes its usefull to have a nullable value especially when working with DB's
            //For e.g. BOOL could then have true, false or null
            //Use ? to state nullable.. on ref types this will error
            //Value type examples
            int? age = null;
            bool? valid;
            char? suffix;
            int?[] numlist = { 1, 2, 3, 4, 5 };

            valid = null;
            suffix = null;
            numlist = null;
            Console.WriteLine("Null test:{0}{1}{2}{3}",age,valid,suffix,numlist);

            //? is actually a short hand for System.Nullable<T>... i.e generic
            Nullable<int> age2 = null;
            Nullable<bool> valid2;
            Nullable<char> suffix2;
            Nullable<int>[] numlist2 = { 1, 2, 3, 4, 5 };

            valid2 = null;
            suffix2 = null;
            numlist2 = null;

            Console.WriteLine("Null test:{0}{1}{2}{3}", age2, valid2, suffix2, numlist2);

            //System.Nullable<T>
            //==================
            //also provides other usefull methods like hasValue to check if something is not null
            if (age2.HasValue)
            {

            }

            //Null Coalescing
            //===============
            //i.e. using ?? to assign a value if null is returned
            int? year = GetFromDB() ?? 2015;
            Console.WriteLine("The year is:{0}", year);
            //instead of
            if (!year.HasValue)
                year = 2015;


            //Null Conditional check
            //======================
            //Short hand to check if something is null and to stop it throwing an error
            int? nextYear = GetFromDB();
            Console.WriteLine("Next year is:{0}", nextYear?.ToString());     //without the ? this would error as nextyear is null

            Console.WriteLine("Next year is:{0}", nextYear?.ToString() ?? "2016");     //using ?? we can also default the value


            Console.ReadLine();
        }

        public static int? GetFromDB()
        {
            return null;
        }
    }
}
