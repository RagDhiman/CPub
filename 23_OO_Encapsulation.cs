using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46
{
    /*

        Encapsulation Rules
        ===================
        - Members that represent the objects state should not be Public
        - Should not be directly accessible or changeable
        - Instead use properties with getters and setters methods or properties
        - Class should protect and control its own state: Thats whats encapsulation is about
        - Always use the public property externaly EVENT internally in the class: So if you have any business rules in them it always fired
        - To make property readonly: omit the set
        - To make property writable only: omit the get
        - Also use automatic properties: that are shorthand for the basics: Type prop then double tab
                - Automatic properties are only good if u dont need logic in the setters and getters

    */

    class OO_Encapsulation
    {
        private string _state;

        public string State
        {
            get{ return _state;}
            set{_state = value;}
        }

        public int MyProperty1 { get; set; } //Automatic property: Shorthand for properies
        public int MyProperty2 { get; set; } //Note: Private name is hidden: You cant access it: 
                                             //And note: Compiler will assign type DEFAULTS (BOOL=FALSE, Object=NULL)
                                             //Could assign these values in the constructor

        public int MyProperty3 { get; set; } = 300;     //New syntax to default automatic property values
    }
}
