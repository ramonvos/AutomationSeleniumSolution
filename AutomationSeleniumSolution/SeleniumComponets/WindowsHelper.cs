using AutomationSeleniumSolution.SeleniumBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSeleniumSolution.SeleniumComponets
{
    public class WindowsHelper
    {
        public static string GetTitle()
        {
            return DriverFactory.Instance.Title;
        }
    }

}
