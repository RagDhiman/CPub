using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._1_CSharpBasics
{
    /*

        Access Modifier
        Importand for encapsulation i.e. hiding class details from various clients
        Types:
            - Public: No access restrictions
            - Private: Only accessible by class or structure that defines them
            - Protected: Only accessible by class or structure that defines them or by classes that inherit them from a parent
            - Internal: Only accessible within the assembly\project they are defined in
            - Protected Internal: As name suggests above two combined

    */

    class AccesssModifiers  //By default a class is Internal
    {
        AccesssModifiers() //And by default a constructor without an access modifier is Private
        {

        }
    }
}
