using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SectionOne = CSharp6Net46._1_CSharpBasics;    // ** Using with an alias

namespace CSharp6Net46._2_CSharpAdvanced
{
    /*
        Names Spaces:
        =============
        - Are good way of grouping related types togethers
        - Option: One File with the Name Spaces and all classes within that file
            - Con: Classes are fixed in a group cant use them seperatley in other projects
        - Option: Namespace is spread across multiple C# files each containing a class
        - You access this group of class by using "Using NameSpaceName;"
            - External namespaces part of a diferent code library will require reference to that library
        - Using statement also is a shortcut to fully qaulifying type names
        - If there is a class name clash:
            - you could still fully qualify class name
            - You could use Using Alias (see above)
                - Can also be used for long namespace references
                - Please note they can confuse the code
        - To organsie code even more you can nest NAMESPACES
        - Note there is always a DEFAULT ROOT name space: Rightclick project

        Assemblies
        ===========
        - A versioned, self describing binary file hosted by the CLR (exe or dll)
        - Promote code reuse by dividing your code and types into assemblies that can be reused
        - CLR exe's and dll's are DIFFERENT to Windows exe's and dll's
        - An application can alls have a reference to an exe to access types within that aswell as dll's
        - Assemblies that make up a project can be written in different languages (VB, C# or F# etc etc)
        - Same named types defined in two different assemblies under the same name space are treated as two different types
        - Also have version numbers: So that different versions of same assembly can coexist on same machine
        - Can also have a PUBLIC KEY: to ensure clients use the correct version of the assembly
        - Self describing: Have a manifest which details info regarding an assembly AND all the other assemblies required for it to function
        - Types:
            - Private Assemblies: Can only be used by applications and libraries in the same directory
            - Shared Assemblies: Can be used by any app regardless of location and live in system GAC cache.. Global Assembly Cache
        - XML Configuration files: You can use this config file for an assembly to change the location and version of referenced assemblies

        Assembly contents:
            - Windows Header Files: File that contains info about dll for Windows OS to use
            - CLR file header: All the info thats required for the CLR for example the .Net version
            - CIL Code: This is where the code lives in Intermidatery langauge
            - Type metadata: Contains format of the contained types and the format of the external referenced types
            - An assembly manifest: Lists each module in the assembly and version of assembly and external assembelies referenced
            - Optional embeded resources: Resources like icon, images, sounds and strings

            - Note: .Net also supports satellite assembelies i.e. assemblies that contain nothing but localised resources
                - Useful to seperate your resources by CULTURE

            use ildasm.exe to read manifest files

        Adding references
            - You can add references to assemblies on proj properties but not the list is a list of defaults.. use browse to find specific stuff
    */

}
