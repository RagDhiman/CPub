using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._1_CSharpBasics
{
    /*
        All objects inherit from System.object
        =======================================
        You could treat every object as System.Object
        There are virtual methods on System.Object that all objects inherit that might be usefull
        - Equals():  Returns true if two objects point at same memory space. Override if you want to compare objects using internal states
        -            If you override Equals().. Also override GetHashCode() as it uses Equals(): GetHashCode returns an int that identifies an object
        - Finalize():   When overriden this is called when an object is to be destroying and resources can be cleared up in this method
        - ToString(): Can be overriden to provide description of an object using internal state members
        - GetType():  Returns type object that describes the object type
        - MemberWiseClone(): Use to return a copy of an object including copies of members (Used to clone!)

        System.Object Static methods
        ============================
        - Object.Equals(car1, car2) = returns true if internal state is the same
        - Object.ReferenceEquals(car1, car2) = returns true if both objects point at the same memeory space
    */

    class Computer
    {
        public string CPU { get; set; }
        public string GPU { get; set; }
        public int Memory { get; set; }
        public string Serial { get; set; }

        public override string ToString()
        {
            string desc;
            desc = string.Format("CPU:{0}; GPU:{1}; Memory:{2};", CPU, GPU, Memory.ToString());
            return desc;
        }

        public override bool Equals(object obj)
        {
            if (obj is Computer && obj != null)
            {
                Computer temp = (Computer)obj;
                if (temp.CPU == this.CPU && temp.GPU == this.GPU && temp.Memory == this.Memory)
                {
                    return true;
                }
            }

            return false;
        }

        //Returns a number used for ordering an instance in a hashtable
        //Because we have overrident Equals.. we need something to state order
        //You can use a string type that already has hashcode algorithym. String must unitquely represent object
        //if you dont have one just use this.tostring.gethascode();
        public override int GetHashCode()
        {
            return Serial.GetHashCode();
        }
    }
}
