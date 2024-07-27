using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharp6Net46._1_CSharpBasics
{
    class Statics
    {
        public static void Exmaple()
        {
            /*
            Static members and classes are called at CLASS level
            ====================================================
            i.e.you dont have to create an object from the class using NEW
            Static members and methods are normally found on classes that are UTILITY CLASSES
            Utility classes are classes that normally do not need to maintain STATE
            They provide isolated functions as static mentods
            E.g.Console.WriteLine()
            Static keyword can be applied to:
            - Data of a class
            - Property of a class
            - Method of a class
            - The entire class
            - In conjunction with USING keyword

            Static Data on a class
            ======================
            Is one shared memeory space across all object level instances of that class
            therefore changing it will mean it changes for all
            */
            var s1 = new SavingsAccount(23.3);
            var s2 = new SavingsAccount(34.5);
            var s3 = new SavingsAccount(34.22);

            Console.WriteLine(s1.AccountInformation());
            Console.WriteLine(s2.AccountInformation());
            Console.WriteLine(s3.AccountInformation());
    
            SavingsAccount.InterestRate = 10.2;

            var s4 = new SavingsAccount(88.8); //Creating new instance does not change the value

            Console.WriteLine(s1.AccountInformation());
            Console.WriteLine(s2.AccountInformation());
            Console.WriteLine(s3.AccountInformation());

            /*
            Conclusion: 
            ===========
            Static field is shared by all instances of that object: So if this is your requirement use it
            if in your app you had hundreds of account instances you would only have to change the interest rate for all once :-D

            Static Methods
            ==============
             Can only access members that are also static

            Static Constructors
            ====================
            Setting static properties in a non static constructor will mean everytime you create a new instance of that class
            the static data is reset to that value: Making the use of static property pointless
            What if you didnt know the static value at design time and had to load it in at runtime from a file or something
            This is where you use a static constrictor
            Static constructors only ever fire once and are NOT fired when you create new instances of a class

            Static Classes
            ==============
            Both static and non static class can have static data members and methods
            However utility classes that only feature static methods should be declared as static classes
            You are then not allowed to create instances of that class: Because theres no class level state

            Static Using (import)
            =====================
            There are using statements specifically for static methods and classes
            'using static system.console;'
            Means import all static members and methods:
    */
            WriteLine("No longer need System.console because we are using STATIC USING impoerts");
            ReadLine();
        }
    }

    public class SavingsAccount {

        private double _currentBalance;
        public static double InterestRate = 0.5;    //STATIC This will be shared by all object level instances

        static SavingsAccount() //Static constructor only ever fired once: Ideal for setting static data
        {
            Console.WriteLine("Static constructor is only ever fired once: Regardless of how many instances of class you create");
            InterestRate = 0.5;
        }

        public SavingsAccount(double balance)
        {
            _currentBalance = balance;
        }

        public string AccountInformation()
        {
            return String.Format("Balance is {0} with interest rate of {1}", _currentBalance, InterestRate);
        }

        #region StaticMethods
        public static void SetInterestRate(double rate)
        {
            InterestRate = rate;
        }

        public static double GetInterestRate()
        {
            return InterestRate;
        }
        #endregion
    }
}
