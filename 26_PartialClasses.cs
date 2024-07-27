using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46
{
    /*
    Use partial classes to split large classes into seperate files
    See example below
    */

    // House.Core.cs
    partial class House
    {
        //Contains private and public members
    }

    // House.Logic.cs
    partial class House
    {
        //Contains methods and functions
    }
}
