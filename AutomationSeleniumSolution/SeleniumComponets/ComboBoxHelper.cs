using AutomationSeleniumSolution.ExtentReportLogger;
using AutomationSeleniumSolution.ProjectUtilitarios;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSeleniumSolution.SeleniumComponets
{
    public static class ComboBoxHelper
    {
        private static SelectElement select;

        public static void SelectElement(this IWebElement element, int index)
        {
            select = new SelectElement(element);
            select.SelectByIndex(index);

        }

        public static IList<string> GetAllItem(IWebElement element)
        {
            select = new SelectElement(element);
            return select.Options.Select((x) => x.Text).ToList();

        }

        public static void SelectElement(this IWebElement element, string visibleText)
        {
            select = new SelectElement(element);
            select.SelectByText(visibleText);
            Reporter.InfoTest(Utilitarios.GetCurrentMethod() + " => " + "Valor selecionado: " + visibleText);

        }
    }
}
