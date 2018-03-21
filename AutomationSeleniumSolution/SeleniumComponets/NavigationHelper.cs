using AutomationSeleniumSolution.ExtentReportLogger;
using AutomationSeleniumSolution.SeleniumBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSeleniumSolution.SeleniumComponets
{
    public static class NavigationHelper
    {   
        public static void NavigateToPage(string url)
        {
            try
            {
                DriverFactory.Instance.Navigate().GoToUrl(url);
                Reporter.AddLogStep("Acessando a página: "+ url);
            }
            catch 
            {

                
            }
        }
    }
}
