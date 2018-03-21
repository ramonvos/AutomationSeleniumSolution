using AutomationSeleniumSolution.SeleniumBase;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSeleniumSolution.SeleniumComponets
{
    public class MouseOverHelper
    {
        public static void MouseOverClickContext(IWebElement element)
        {
            Actions act = new Actions(DriverFactory.Instance);
            //IWebElement ele = ObjectRepository.Driver.FindElement(locator);
            act.ContextClick(element)
                .Build()
                .Perform();

            //Thread.Sleep(5000);


        }

        public static void MouseOverDranNDrop(IWebElement elemSrc, IWebElement elemTar)
        {
            Actions act = new Actions(DriverFactory.Instance);
            //IWebElement src = elemSrc;
            //IWebElement tar = elemSrc;
            act.DragAndDrop(elemSrc, elemTar)
                .Build()
                .Perform();

            //Thread.Sleep(5000);


        }

        public static void MouseOverClickNHold(IWebElement elemSrc, IWebElement elemTar)
        {
            Actions act = new Actions(DriverFactory.Instance);
            //IWebElement src = ObjectRepository.Driver.FindElement(locatorSrc);
            //IWebElement tar = ObjectRepository.Driver.FindElement(locatorTar);
            act.ClickAndHold(elemSrc)
                .MoveToElement(elemTar, 0, 30)
                .Release()
                .Build()
                .Perform();
        }
    }
}
