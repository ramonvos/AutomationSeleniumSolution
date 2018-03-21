using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSeleniumSolution.SeleniumComponets
{
    public static class SeleniumTestHelper
    {
        public static String GetTestDirectoryName()
        {
            return TestContext.CurrentContext.TestDirectory;
        }


        public static String GetTestCaseName()
        {
            return TestContext.CurrentContext.Test.Name;
        }


        public static String GetTestDescription()
        {
            return TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
        }
        public static String GetClassNameTest(int pos)
        {
            String SuiteName = TestContext.CurrentContext.Test.ClassName;

            return SuiteName.Substring(pos);
        }

        public static TestStatus GetTestStatus()
        {
            return TestContext.CurrentContext.Result.Outcome.Status;
            
        }



    }
}
