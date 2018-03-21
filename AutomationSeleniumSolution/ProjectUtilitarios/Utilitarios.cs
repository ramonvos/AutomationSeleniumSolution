using AutomationSeleniumSolution.SeleniumBase;
using AutomationSeleniumSolution.SeleniumComponets;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSeleniumSolution.ProjectUtilitarios
{
    public static class Utilitarios
    {
        public static string fileName = string.Empty;
        public static void TakeScreenShot()
        {
            fileName = GetPathTakeScreenShot();

            Screenshot ss = ((ITakesScreenshot)DriverFactory.Instance).GetScreenshot();

            //Use it as you want now
            string screenshot = ss.AsBase64EncodedString;
            byte[] screenshotAsByteArray = ss.AsByteArray;
            ss.SaveAsFile(fileName, ScreenshotImageFormat.Png); //use any of the built in image formating
            ss.ToString();//same as string screenshot = ss.AsBase64EncodedString;



        }

        public static string GetPathTakeScreenShot()
        {
            String currentDateTime = DateHelper.GetDateTimeNow().Replace("/", "-").Replace(":", "-");
            fileName = SeleniumTestHelper.GetTestDirectoryName() + @"\Screenshot " + currentDateTime + ".Png";

            return fileName;

        }

        public static void HighlightElement(this IWebElement element)
        {
            try
            {
                var jsDriver = (IJavaScriptExecutor)DriverFactory.Instance;
                var ele = element;
                string highlightJavascript = @"$(arguments[0]).css({ ""border-width"" : ""2px"", ""border-style"" : ""solid"", ""border-color"" : ""yellow"" });";
                jsDriver.ExecuteScript(highlightJavascript, new object[] { ele });

            }
            catch
            {
                var jsDriver = (IJavaScriptExecutor)DriverFactory.Instance;
                var ele = element;
                string highlightJavascript = @"arguments[0].style.cssText = ""border-width: 2px; border-style: solid; border-color: yellow"";";
                jsDriver.ExecuteScript(highlightJavascript, new object[] { ele });
            }

        }


        public static void AddMask(this string value, string parameter)
        {

            if (parameter == "CPF")
            {
                if (value.Length == 14)
                {
                    value = value.Substring(0, 3) + "." +
                   value.Substring(3, 3) + "." +
                   value.Substring(6, 3) + "-" +
                   value.Substring(9, 2);
                }

            }

        }


        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCurrentMethod()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

            return sf.GetMethod().Name;
        }

    }
}
