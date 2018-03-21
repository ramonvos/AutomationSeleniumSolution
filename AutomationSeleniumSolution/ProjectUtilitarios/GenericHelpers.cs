using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSeleniumSolution.ProjectUtilitarios
{
    public class GenericHelpers
    {   
        public static String GetCurrentMethodName()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(0);

            MethodBase currentMethodName = sf.GetMethod();
            return currentMethodName.ToString();
        }
    }
}
