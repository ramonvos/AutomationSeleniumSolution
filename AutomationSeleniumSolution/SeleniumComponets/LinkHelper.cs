using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSeleniumSolution.SeleniumComponets
{
    public class LinkHelper
    {
        private static IWebElement element;

        public static void ClickLink(IWebElement element)
        {
            SeleniumGetElement.GetElement(element);
            element.Click();
        }
    }
}
