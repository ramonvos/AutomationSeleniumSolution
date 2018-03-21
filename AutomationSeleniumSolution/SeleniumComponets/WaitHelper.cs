using AutomationSeleniumSolution.ExtentReportLogger;
using AutomationSeleniumSolution.SeleniumBase;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSeleniumSolution.SeleniumComponets
{
    public class WaitHelper
    {   
        // public static IWebElement GetElement(IWebElement element)

        // {
        //    if (element.Displayed || element.Enabled)
        //    {
        //        Reporter.AddLogStep("Elemento : [" + element.GetAttribute("id") + "] encontrado.");
        //        return element;
        //    }


        //    else
        //    {
        //        Reporter.AddLogStep("Elemento não foi encontrado.");
        //        return null;
        //    }
        //}

        public static void WaitElementToBeClickable(IWebElement element)
        {
            try
            {
                new WebDriverWait(DriverFactory.Instance, TimeSpan.FromSeconds(Convert.ToInt32(ConfigurationManager.AppSettings["DefaultTimeout"]))).Until(ExpectedConditions.ElementToBeClickable(element));
                try
                {
                    Reporter.AddLogStep("Elemento encontrado: [" + element.GetAttribute("id") + "].");
                }
                catch 
                {

                    Reporter.AddLogStep("Elemento encontrado: [" + element.ToString() + "].");
                }
                
            }
            catch (NoSuchElementException ex)
            {
                Reporter.AddLogStep(ex.Message);
                throw new NoSuchElementException();

            }

        }
        public static void WaitTextToBePresentInElement(IWebElement element, string text)
        {
            try
            {
                
                new WebDriverWait(DriverFactory.Instance, TimeSpan.FromSeconds(Convert.ToInt32(ConfigurationManager.AppSettings["DefaultTimeout"]))).Until(ExpectedConditions.TextToBePresentInElement(element,text));
                try
                {
                    Reporter.AddLogStep("Elemento encontrado: [" + element.GetAttribute("id") + "].");
                }
                catch
                {

                    Reporter.AddLogStep("Elemento encontrado: [" + element.ToString() + "].");
                }
            }
            catch (NoSuchElementException ex)
            {
                Reporter.AddLogStep(ex.Message);
                throw new NoSuchElementException();
                
            }
            
        }
        public static void TextToBePresentInElementValue(IWebElement element, string text)
        {
            try
            {
                new WebDriverWait(DriverFactory.Instance, TimeSpan.FromSeconds(Convert.ToInt32(ConfigurationManager.AppSettings["DefaultTimeout"]))).Until(ExpectedConditions.TextToBePresentInElementValue(element, text));
                try
                {
                    Reporter.AddLogStep("Elemento encontrado: [" + element.GetAttribute("id") + "].");
                }
                catch
                {

                    Reporter.AddLogStep("Elemento encontrado: [" + element.ToString() + "].");
                }
            }
            catch (NoSuchElementException ex)
            {
                Reporter.AddLogStep(ex.Message);
                throw new NoSuchElementException();

            }
        }
    }
}
