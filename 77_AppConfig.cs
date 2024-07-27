using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CSharp6Net46._2_CSharpAdvanced
{
    /*

        Reading from App.config
        ========================
        - Can contain config thats useful to the app
        - Once deployed app.config changes to appname.exe.config
        - System.configuration provides the logic to access app.config data
        - In app.config define your CUSTOM settings in <appSettings> using key value pairs
        - For example:

          <appSettings>
               <add key="DBName" value="TestDB"/>
               <add key="PWD" value="TestDB"/>
          </appSettings>

        - 
    */

    class appConfig
    {
        public void Example()
        {
            AppSettingsReader ar = new AppSettingsReader();

            string DBName = (string)ar.GetValue("DBName", typeof(string));
            string PWD = (string)ar.GetValue("PWD", typeof(string));

        }
    }
}
