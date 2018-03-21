using AutomationSeleniumSolution.ExtentReportLogger;
using AutomationSeleniumSolution.ProjectUtilitarios;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSeleniumSolution.SeleniumComponets
{
    public class ButtonHelper
    {
        private static IWebElement element;
        public static void ClickButton(IWebElement element)
        {
            SeleniumGetElement.GetElement(element);
            element.Click();




            try
            {
                if (SeleniumGetElement.GetElement(element))
                {
                    element.Click();
                }
                else { Reporter.InfoTest("Valor preenchido: Nulo/Vazio"); }

            }
            catch (NoSuchElementException ex)
            {
                Reporter.FailTest(Utilitarios.GetCurrentMethod() + " => " + "ERRO! Elemento esperado não apareceu." + "<pre>" + ex.Message + "</pre>",ex);
                Assert.IsTrue(false);
            }


        }

        public static bool IsButtonEnabled(IWebElement element)
        {
            SeleniumGetElement.GetElement(element);
            return element.Enabled;
        }

        public static string GetButtonText(IWebElement element)
        {
            SeleniumGetElement.GetElement(element);

            if (element.GetAttribute("value") == null)
                return string.Empty;
            return element.GetAttribute("value");
        }
    }
}
