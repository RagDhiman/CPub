using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Net46._2_CSharpAdvanced
{
    class LambdaExpresssions_MultipleParameters
    {


        public void Example()
        {
            TestOne myClass = new TestOne();

            myClass.setHandler((int a, string msg) => {
                Console.WriteLine("Number is {0} and message is {1}");
            });

            myClass.RaiseMyDelegateMethod(23,"test");
        }

    }

    public class TestOne
    {

        public delegate void multiParameterDelegate(int Number, string message);

        private multiParameterDelegate mpd;

        public void setHandler(multiParameterDelegate target)
        {
            mpd = target;
        }

        public void RaiseMyDelegateMethod(int Number, string message)
        {
            mpd?.Invoke(Number, message);
        }
    }
}
