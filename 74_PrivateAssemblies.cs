using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._2_CSharpAdvanced
{
    /*
    Private Assemblies
    ==================
    - Default type of class library
    - Must exist in the same dir or subdir of the client application
    - You can then move the app anywhere on your machine: Because app and its dependencies are in one folder
    - Name of private assembly and version are contained in the manifest
    - One machine can have different versions of an assembly i.e. in different application folders
    - Binaries i.e. apps either load assemblies implicitly or explicitly
        - Implicit: When the external reference is in the app manifest
        - Explicit: Dynamic loading when something like refelection is used to load an assembly at runtime
    - In both cases files are searched for in the app directory if not found in app directory: Sub dir with the same name as assembly is searched

    exe.config file (App.Config)
    ================
    - Can be used to change search process for private assemblies
    - i.e. they allow you to place your private dll's in different places
    - For example in your App you want to use a subdir called "mylibraries" to store all your dll's
    - For this app its called CSharp6Net46.exe.config .. within the project its called App.Config
    - When copied to release folder name is changed
    - Sytax to change dir:

                <runtime>
                    <assemblyBinding xmlns="urn:shemas-microsoft-com:asm.vl">
                            <probing privatepath="myLibrariesFolder;OtherFolder"/>
                    </assemblyBinding>
                </runtime>
    
    - You cannot specify location for specific dll's
    - You can only tell it additional directorys to prob when looking for assemblies or dlls
    - The directory must also be a subdriectory of the app
    - To use external directories use codebase ... see later 

    */
}
