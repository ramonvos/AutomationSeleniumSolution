using AutomationSeleniumSolution.ExtentReportLogger;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSeleniumSolution.SeleniumComponets
{
    public class TextBoxHelper
    {
        private static IWebElement element;

        public static void TypeInTextBox(IWebElement element, string text)
        {
            SeleniumGetElement.GetElement(element);
            element.SendKeys(text);
            Reporter.InfoTest("Valor preenchido: " + text);
        }

        public static void ClearTextBox(IWebElement element)
        {
            SeleniumGetElement.GetElement(element);
            element.Clear();
        }
    }
}
