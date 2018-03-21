using AutomationSeleniumSolution.SeleniumBase;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSeleniumSolution.SeleniumComponets
{
    public static class JavaScriptExecutorHelper
    {
        public static void ExecuteJavaScript(string script)
        {
            IJavaScriptExecutor executor = ((IJavaScriptExecutor)DriverFactory.Instance);

            executor.ExecuteScript(script);
        }

        public static void ExecuteAsyncJavaScript(string script)
        {
            IJavaScriptExecutor executor = ((IJavaScriptExecutor)DriverFactory.Instance);

            executor.ExecuteAsyncScript(script);
        }
    }
}
