using AutomationSeleniumSolution.SeleniumComponets;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Events;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSeleniumSolution.SeleniumBase
{
    public class DriverFactory
    {
        private static FirefoxProfile FirefoxProfile = CreateFirefoxProfile();

        public static IWebDriver Instance { get; set; }
        /// <summary>
        /// Base URL of the site being tested.
        /// </summary>
        public static string BaseUrl { get; set; }

        static DriverFactory()
        {
            Instance = null;
        }

        public static void Initialize(String browser)
        {
            
            if (browser.Equals("Firefox"))
            {
                Instance = GetFirefoxDriver();

            }
            else if (browser.Equals("Chrome"))
            {
                Instance = GetChromeDriver();

            }
            else if (browser.Equals("InternetExplorer"))
            {
                Instance = GetIEDriver();

            }
            else if (browser.Equals("PhantomJS"))
            {
                Instance = GetPhantomJSDriver();
            }

            

            // Initialize base URL and maximize browser
            BaseUrl = ConfigurationManager.AppSettings["BaseURL"];
            Instance.Manage().Window.Maximize();
            Instance.Manage().Cookies.DeleteAllCookies();

        }


        public static string pathFirefoxDriver = SeleniumTestHelper.GetTestDirectoryName();

        private static FirefoxProfile GetFirefoxProfile()
        {
            FirefoxProfile profile = new FirefoxProfile();
            FirefoxProfileManager manager = new FirefoxProfileManager();

            profile.SetPreference("webdriver.gecko.driver", @"C:\Users\ramon\Downloads\geckodriver.exe");

            profile = manager.GetProfile("default");

            return profile;
        }

        private static FirefoxOptions GetFirefoxOptions()
        {

            var url = new Uri("http://10.6.122.49:5555/wd/hub");

            var options = new FirefoxOptions();
            options.SetPreference("webdriver.gecko.driver", pathFirefoxDriver);

            var driver = new RemoteWebDriver(url, options.ToCapabilities());

            return options;

        }

        private static ChromeOptions GetChromeOptions()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("start-maximized");
            return option;

        }

        private static InternetExplorerOptions GetIEOptions()
        {
            InternetExplorerOptions options = new InternetExplorerOptions();
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            options.EnsureCleanSession = true;
            return options;
        }

        private static PhantomJSOptions GetPhantomJsOptions()
        {
            PhantomJSOptions options = new PhantomJSOptions();
            options.AddAdditionalCapability("takesScreenshot", false);
            return options;
        }

        private static PhantomJSDriverService GetPhantomJsService()
        {
            PhantomJSDriverService service = PhantomJSDriverService.CreateDefaultService();
            service.LogFile = "TestPhantomJS.log";
            service.HideCommandPromptWindow = true;
            return service;
        }

        private static IWebDriver GetFirefoxDriver()
        {
            IWebDriver driver = new FirefoxDriver(pathFirefoxDriver);
            return driver;
        }

        private static IWebDriver GetChromeDriver()
        {
            IWebDriver driver = new ChromeDriver(GetChromeOptions());
            return driver;
        }

        private static IWebDriver GetIEDriver()
        {
            IWebDriver driver = new InternetExplorerDriver(GetIEOptions());
            return driver;
        }

        private static IWebDriver GetPhantomJSDriver()
        {
            PhantomJSDriver driver = new PhantomJSDriver(GetPhantomJsService());
            return driver;
        }

        public static void Quit()
        {
            Instance.Quit();
        }

        private static FirefoxProfile CreateFirefoxProfile()
        {
            var firefoxProfile = new FirefoxProfile();
            return firefoxProfile;
        }
    }
}
