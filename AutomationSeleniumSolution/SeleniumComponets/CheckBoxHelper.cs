using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSeleniumSolution.SeleniumComponets
{
    public static class CheckBoxHelper
    {

        public static void CheckedCheckBox(this IWebElement element, bool check)
        {


            WaitHelper.WaitElementToBeClickable(element);
            if (!IsCheckBoxChecked(element) && check)
            {
                element.Click();
            }else if (IsCheckBoxChecked(element) && !check)
            {
                element.Click();
            }
            
            
        }

        public static bool IsCheckBoxChecked(IWebElement element)
        {
            
            string flag = element.GetAttribute("checked");
            
            if (flag == null)
                return false;
            else
                //return flag.Equals("true") || flag.Equals("checked");
            return true;
        }

    }
}
