using AutomationSeleniumSolution.SeleniumBase;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSeleniumSolution.SeleniumComponets
{
    public class JavaScriptPopUpHelper
    {
        public static bool IsPopUpPresent()
        {
            try
            {
                DriverFactory.Instance.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        public static string GetPopUpText()
        {
            if (!IsPopUpPresent())
                return "";
            return DriverFactory.Instance.SwitchTo().Alert().Text;
        }

        public static void ClickOkPopUp()
        {
            if (!IsPopUpPresent())
                return;
            DriverFactory.Instance.SwitchTo().Alert().Accept();
        }

        public static void ClickCancelPopUp()
        {
            if (!IsPopUpPresent())
                return;
            DriverFactory.Instance.SwitchTo().Alert().Dismiss();
        }

        public static void SendKeysPopUp(string text)
        {
            if (!IsPopUpPresent())
                return;
            DriverFactory.Instance.SwitchTo().Alert().SendKeys(text);
        }
    }
}
