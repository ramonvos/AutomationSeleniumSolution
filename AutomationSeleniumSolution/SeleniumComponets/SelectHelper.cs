using AutomationSeleniumSolution.ExtentReportLogger;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSeleniumSolution.SeleniumComponets
{
    public static class SelectHelper
    {       
        public static void SelectElementByText(this IWebElement element, string text)
        {
            try
            {
                WaitHelper.WaitTextToBePresentInElement(element, text);
                new SelectElement(element).SelectByText(text);
                Reporter.AddLogStep(text);
            }
            catch (NoSuchElementException ex)
            {
                Reporter.AddLogStep(ex.Message);
                throw new NoSuchElementException();

            }
        }

    }
}
