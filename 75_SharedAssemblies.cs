using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._2_CSharpAdvanced
{
    /*

    Shared Assemblies
    ----------------
    - Like private libraries they are used to share and store types
    - Unlike private assemblies: Shared assemblies can be shared by more than one application on the same machine
    - When to use: Basically when many apps on one machine need to share an assembly. Only one library to update

    GAC
    ---
    - Global Assembly Cache
    - Place where shared assemblies are stored. Where the GAC lives depends on the .Net version
    - Pre .Net 4.0 GAC lives in C:\Windows\Assembly
    - .Net 4.0 or above GAV lives in C:\Windows\Microsoft.net\assembly\GAC_MSIL
    - GAC only stores .dll's not exe's
    
    - How
    - Assemblies for the GAC must have a StrongName ... individual name or company name
    - StrongName can be made up of:
        - Friendly name of assembly
        - Version
        - Public key value          have to use sn.exe to generate or VisualStudio.exe
        - Culture ID
        - Digital signature
    - Install to GAC using either something commercial like InstallShield or cmd line util gacUtil.exe

    - Reference like normal external reference
    - But note a copy is not copied to BIN directory.. its used from GAC

    Shared Assemblies can also have .confg files
        - Bug in assembly.. use config to redirect client to different version of the shared assembly

    Publisher policy assembly
        - You can also include the config file in the GAC folder along with the shared assembly. This way you have one config file to change if multiple apps use the shared assembly
        - You can also configure specific apps to ignore the GAC config file if they have to do something different
    */
}
