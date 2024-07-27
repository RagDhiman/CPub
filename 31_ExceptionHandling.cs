using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CSharp6Net46._1_CSharpBasics
{
    /*
    
    Structured Exception Handling
    =============================
    - Standard .Net technique to send and trap runtime errors
    - The exception includes error numbers, description and call stack as standard
    - Dont use your own method of raising errors i.e. numbering them and providing descriptions
    - .Net provides a structured way which is compatible and consistent across all .Net projects
    - So if you decide to move a project layer to another application: .Net exception handling will just work
    - WCF excpetion is understood by a ASP.Net front end
    - Always make liberal use of error handling
        - ???

    - .net provides the following keyword
        - Try, Catch, Throw, Finally and When to handle expections
        - And exception objects have a base class of System.Exception
            - Loads of virtual members for derived exceptions to override
            - Key properties
                - Data: Dictionary of key value pairs from more information that programmers can configure. Empty by default
                - HelpLink: Configurable linke to support or help webside
                - InnerException: Used to obtain information about previous exceptions that lead to this exception
                - Message: Description of the current error
                - Source: Name of the object class or assembly that threw the error
                - StackTrack: CallStack in string format
                - TargetSide: Details of the method that threw the exception
                        - .DeclaringType = Class name where property or method is decalared
                        - .MemberType = Method or Property

                - Throwing an excpetion 
                ========================
                - for a known circumstance see PLANE below
                - Only throw expcetions when a TERMINAL circumstance has been reached that cannot be recovered from
                    - For example Database not found
                    - Data file not found
                - If you leave exception unhandled user will see all exception details (not necessairly a bad thing or something you should avoid)

                - Catching Exception
                ====================
                - Handling the exception using (Try\Catch block)
                - See autopilot example below
                - Remember you dont have to handle all expceptions
                - If you choose to handle the exception you might use the excption data to
                        - Log to report
                        - Write to windows event log
                        - Email an admin
                        - Or display the error to the user
                        - Log to central database
               - What to do next
                        - If error is terminal enough you may choose to terminat the app
                        - You may opt to let the user continue with limited functionality

                - Creating Custom Exceptions
                ============================
                ex.data provides a means of storing custom data
                However sometimes there is a need to create a strongly type specific type of exception
                This is where you can create a custom exception based on System.Exception

                - System-Level Exceptions vs Application-Level Exceptions
                ==========================================================

                - System-Level Exceptions
                    - Exceptions thrown from the .net platform
                    - Normally non recoverable
                    - Based on System.SystemException which derives frm System.Exception
                    - Why does it exist? So that you can tell its the .net runtime that has thrown the error and NOT your app
                                        Console.WriteLine("Is .Net runtime error: {0}", e is SystemException);

                - Application-Level Exceptions
                    - Thrown by your in the code somewhere
                    - Use for your own custom exceptions i.e. use System.ApplicationException as base type
                    - Based on System.ApplicationException which derives frm System.Exception
                    - Why does it exist? So that you can tell its an exception thrown by your app and NOT by the .Net runtime
                                        Console.WriteLine("Is application error: {0}", e is ApplicationException);

                - Both are actually the same bar a few constructors: Sole purpose is so taht we can distinguish between app level or .net thrown i.e. system
  
                - Creating Custom Application-level Exceptions
                ==============================================
                - Strongly type exception required with strongly typed members (See outOfFuelException below)
                - Instead of using data for custom data we can now have strongly typed members for extra info
                - We can also have custome constructor to pass in data for our strongly typed members
                - Main advantage of creating your own excepent is STRONGLY TYPED CUSTOM MEMBERS
                - and ability OVERRIDE virtual members of exception\application-level exception
                - You would also create with the errors are specific to a class and the calling code needs to handle different exceptions differently
                - For e.g. DataConnection class, customer Exception for TCPIPConnectionException: Calling code then logs and switches to named pipes

                - The perfect custom exception would:
                    - Derive from exception\applicationException
                    - Is marked with [System.Serializable] attribute
                    - Defines a default constructor
                    - Defines a constructor that sets the inherited message property
                    - Defines a construtor that handles "inner excpetions"
                    - Defines a constructor to handle the serialization of your type

                    - See PerfetCustomException below

                - Multiple CatchBlocks
                ======================
                Always have specific ones first and then general ones latter
                Should always aim to catch specific errors
                Catching just system.exception "Catch (Exception e)" will capture everthing and surpress an error you might need to worry about
                Handling a very serious error in a generic way may result in strange behaviour latter on

                - Rethrow Exception
                ====================
                If your catch block only partially handles an error you can rethorw it so that code further up the chain can handle it
                See "throw;" example below - It rethrows original exception
                Note: You would only rethrow a partially handled expception if the caller can handle it: Else user will get a systems error dialogue (not pretty!)
        
                - Inner Exception
                ==================
                What if the code that is handling an exception i.e. catch block throws and exception:
                For example in the catch block you write to error log file. File isnt available and this raises another exception
                This is where you pass the new exception as an INNER EXCEPTION to a new exception taht you that you rase
                So original issue can still be traced
                How:
                See OutOfMemoryException example below
                1. Record new exception object as the inner exception object
                2. Ensure the new exception you throw is the same type as the orginal
                3. Pass in the orginal exceptions message as the message for the new exception you are throwing

                Inner exceptions are only useful when the calling code can handle the exception and extract the info out of the inner exception object
                
                - Finally block
                ===============
                Error or no finally section will always fire. Good place to clear down:
                - Closing files
                - Closing connections to DB's or services

                - When exception filter on catch blocks
                ========================================
                You can add a when clause to a catch block so that catch block only handle error if when condition is true
                See example below

        */

    class Plane
    {
        public int CurrentFuelLevel { get; set; } = 50;
        public int StallFuelLevel { get; set; } = 50;

        public void AutoPilot()
        {
            try
            {
                Accelerate();
            }
            catch (OutOfFuelException oe)
            {
                Console.WriteLine("Message: {0}", oe.Message);
                Console.WriteLine("Stall Fuel Level: {0}", oe.stallFuelLevel); //Strongly typed members on our custom app exception
                //We could also obviously write all the other details from OutOfFuelExeption like example below
            }
            catch (OutOfMemoryException me)
            {
                try
                {
                    WriteExceptionToFile(me);
                }
                catch (Exception e2)
                {

                    throw new OutOfMemoryException(me.Message, e2);
                }
            }
            catch (ApplicationException) when (DateTime.Now.Year == 1900)
            {
                Console.WriteLine("I will never handle an error");
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
                Console.WriteLine("Help Linke: {0}", e.HelpLink);
                foreach (DictionaryEntry de in e.Data)
                {
                    Console.WriteLine("{0}: {1}", de.Key, de.Value);
                }
                Console.WriteLine("Is .Net runtime error: {0}", e is SystemException);
                Console.WriteLine("Is application error: {0}", e is ApplicationException);

                throw; //Rethrow the error up because we have only partially handled it
            }
            finally
            {
                Console.WriteLine("Error or no finally section will always fire. Good place to clear down");
            }
        }

        private void WriteExceptionToFile(OutOfMemoryException me)
        {
            throw new NotImplementedException();
        }

        public void Accelerate()
        {
            CurrentFuelLevel--;

            if (CurrentFuelLevel <= 0)
            {
                throw new OutOfFuelException(DateTime.Now, StallFuelLevel, "Accelerate");
            }

            if (CurrentFuelLevel < StallFuelLevel)
            {
                //Note use of ApplicationException instead of Exception: Just so that we can tell later on we threw the exception
                var ex = new ApplicationException(String.Format("Danger of stall: Current fuel level:{0} and stall level is {1}.", CurrentFuelLevel, StallFuelLevel));

                ex.HelpLink = "http:\\www.support.com";

                //Data: Dictionary of key value pairs from more information that programmers can configure. Empty by default
                ex.Data.Add("Database", "WarwickDB");
                ex.Data.Add("Username", "Bob");
                ex.Data.Add("Server", "101");
                ex.Data.Add("IIS Version", "7.0");

                throw ex;
            }
        }


    }

    class OutOfFuelException: ApplicationException
    {
        public DateTime outOfFuelDateTime { get; set; }
        public int stallFuelLevel { get; set; }
        public string cause { get; set; }

        public OutOfFuelException(DateTime outOfFuelDateTime, int stallFuelLevel, string cause) //: base(String.Format("Error ran out of fuel at {0} configured stall level is {1} and the cause is {2}", outOfFuelDateTime.ToString(), stallFuelLevel.ToString(), cause)
        {
            this.outOfFuelDateTime = outOfFuelDateTime;
            this.stallFuelLevel = stallFuelLevel;
            this.cause = cause;
        }

        //Override virtual memember message with message based on strongly typed data
        //We could have passed in the message to the base i.e exception instead of doing this.. see commented out code above.More common way
        public override string Message
        {
            get
            {
                return String.Format("Error ran out of fuel at {0} configured stall level is {1} and the cause is {2}",outOfFuelDateTime.ToString(),stallFuelLevel.ToString(),cause);
            }
        }
    }

    [Serializable]
    class PerfectException : ApplicationException
    {
        public DateTime outOfFuelDateTime { get; set; }
        public int stallFuelLevel { get; set; }
        public string cause { get; set; }

        public PerfectException() { }
        public PerfectException(string message) :base(message){ }
        public PerfectException(string message, SystemException inner) : base(message, inner) { }
        public PerfectException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public PerfectException(DateTime outOfFuelDateTime, int stallFuelLevel, string cause): base(String.Format("Error ran out of fuel at {0} configured stall level is {1} and the cause is {2}", outOfFuelDateTime.ToString(), stallFuelLevel.ToString(), cause))
        {
            this.outOfFuelDateTime = outOfFuelDateTime;
            this.stallFuelLevel = stallFuelLevel;
            this.cause = cause;
        }
    }
}
