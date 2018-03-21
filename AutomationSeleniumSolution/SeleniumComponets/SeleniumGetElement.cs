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
    public class SeleniumGetElement
    {
        public static bool GetElement(IWebElement element)
        {
            try
            {
                if (element.Displayed || element.Enabled)
                {
                    try
                    {
                        Reporter.InfoTest(Utilitarios.GetCurrentMethod() + " => " + "Elemento encontrado: " + element.GetAttribute("id"));
                    }
                    catch { Reporter.InfoTest(Utilitarios.GetCurrentMethod() + " => " + "Elemento encontrado: " + element.ToString()); }

                }
                return true;
            }
            catch (NoSuchElementException ex)
            {
                Reporter.FailTest(Utilitarios.GetCurrentMethod() + " => " + "ERRO! Elemento esperado não apareceu." + "<pre>" + ex.Message + "</pre>", ex);
                Assert.IsTrue(false);
                return false;
            }

        }
    }
}
