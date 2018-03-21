using AutomationSeleniumSolution.BDDHelpers;
using AutomationSeleniumSolution.SeleniumBase;
using AutomationSeleniumSolution.SeleniumComponets;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSeleniumSolution.ExtentReportLogger
{
    public static class Reporter
    {
        public static string frameworkType = ConfigurationManager.AppSettings["FrameworkType"];

        static string path = @"C:\Selenium\";
        static string reportTestName = "Report.html";
        static string reportBDDName = "BDDReport - "+DateTime.Now.ToLongDateString()+".html";

        public static ExtentReports _extent;
        //public static ExtentTest _test;
        public static ExtentTest _test;
        public static Scenario scenario;

        public static string ScenarioName = null;
        public static string ArchiveName = null;

        public static void CreateReport()
        {
            //if (_extent == null)
            //{
                string fileName = string.Empty;
                if (frameworkType == "BDD")
                {
                    fileName = reportBDDName;
                }
                else { fileName = reportTestName; }
                var htmlReporter = new ExtentHtmlReporter(path + fileName);



                _extent = new ExtentReports();
                _extent.AttachReporter(htmlReporter);
                htmlReporter.Configuration().ChartVisibilityOnOpen = false;
            
            //}





            //string css = "$('#test-view > div.subview-left.left > div > h5').attrib('<h5>4dsa54ds64as</h5>')";
            //htmlReporter.Configuration().JS = css;
            //htmlReporter.Configuration().CSS = css;
        }

        public static  void AddFeature()
        {
            string name = ScenarioHelpers.GetScenarioName();

            if (frameworkType == "BDD")
            {

                
                if (name != ScenarioName)
                {
                    string category = ScenarioHelpers.GetFeatureName();
                    _test = _extent.CreateTest<Feature>(name)
                        .AssignCategory(category)
                        .CreateNode<Scenario>(name);

                    ScenarioName = name;
                }
                
            }
            else {}
            
        }
        public static void AddTestCaseName()
        {
            //string name = ScenarioHelpers.GetScenarioName();
            //string category = ScenarioHelpers.GetFeatureName();
            //_test = _extent.CreateTest<Feature>(name)
            //    .AssignCategory(category)
            //    .CreateNode<Scenario>(name);


        }

        public static void AddScreenShot()
        {
            if (frameworkType == "SpecflowTests")
            {

                //var StepType = ScenarioHelpers.GetStepType();
                string description = ScenarioHelpers.GetScenarioName();
                //string status = ScenarioHelpers.GetScenarioStatus().ToString();

                if (description != ArchiveName)
                {
                    string path = @"C:\Selenium\";
                    string fileName = "BDDPrint - " + DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss") + ".png";

                    string screenshotPath = path + fileName;

                    Screenshot ss = ((ITakesScreenshot)DriverFactory.Instance).GetScreenshot();

                    //Use it as you want now
                    string screenshot = ss.AsBase64EncodedString;
                    byte[] screenshotAsByteArray = ss.AsByteArray;
                    ss.SaveAsFile(path + fileName, ScreenshotImageFormat.Png); //use any of the built in image formating
                    ss.ToString();//same as string screenshot = ss.AsBase64EncodedString;

                    //var mediaModel = MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build();

                    //_test.CreateNode<Then>("Teste Passou").Pass("Evidência: ", mediaModel);
                    //_test.CreateNode<Then>("Teste Passou", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());

                    //_test.Pass("Evidência: ").AddScreenCaptureFromPath(screenshotPath);

                    //_test.Pass("Evidência: ", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());

                    _test.CreateNode<Then>("Evidência:").Pass(DriverFactory.BaseUrl).AddScreenCaptureFromPath(screenshotPath);
                    //_test.CreateNode<Then>("Teste Passou").Pass("Screenshot").AddScreenCaptureFromPath(path + fileName);


                    ArchiveName = description;
                }
                else if ((frameworkType == "NunitTests"))
                {
                    //TODO - Screenshot NUNIT tests
                }
            }
            
            
            //





        }
        

        public static void AddScenario()
        {
            

        }

        public static void AddLogStep(string text)
        {
            if (frameworkType == "SpecflowTests")
            {
                var StepType = ScenarioHelpers.GetStepType();
                string description = ScenarioHelpers.GetStepsDescription();
                string status = ScenarioHelpers.GetScenarioStatus().ToString();


                switch (StepType)
                {
                    case TechTalk.SpecFlow.Bindings.StepDefinitionType.Given:
                        _test.CreateNode<Given>(description).Pass(status + "<pre> Valor informado: [" + text + "]</pre>");
                        break;
                    case TechTalk.SpecFlow.Bindings.StepDefinitionType.When:
                        _test.CreateNode<When>(description).Pass(status + "<pre> Valor informado: [" + text + "]</pre>");
                        break;
                    case TechTalk.SpecFlow.Bindings.StepDefinitionType.Then:
                        _test.CreateNode<Then>(description).Pass(status + "<pre> Valor informado: [" + text + "]</pre>");
                        break;
                    default:
                        _test.CreateNode<And>(description).Pass(status + "<pre> Valor informado: [" + text + "]</pre>");
                        break;
                }
            }
            else if ((frameworkType == "NunitTests"))
            {
                var StepType = SeleniumTestHelper.GetClassNameTest(30);
                string description = SeleniumTestHelper.GetTestDescription();
                string nase = SeleniumTestHelper.GetTestCaseName();

                TestStatus status = SeleniumTestHelper.GetTestStatus();

                Status logstatus;
                switch (status)
                {
                    case TestStatus.Failed:
                        logstatus = Status.Fail;
                        break;
                    case TestStatus.Inconclusive:
                        logstatus = Status.Warning;
                        break;
                    case TestStatus.Skipped:
                        logstatus = Status.Skip;
                        break;
                    default:
                        logstatus = Status.Pass;
                        break;
                }

                _test.Log(logstatus, "<pre> Valor informado: [" + text + "]</pre>");


            }
            
        }

        //public static void GivenStep()
        //{
        //    if (frameworkType == "BDD")
        //    {
        //        string description = ScenarioHelpers.GetStepsDescription();
        //        string status = ScenarioHelpers.GetScenarioStatus().ToString();
        //        // steps
        //        _test.CreateNode<Given>(description).Pass(status);
        //    }
        //    else { }
            
          
        //}
        //public static void AndStep()
        //{
        //    if (frameworkType == "BDD")
        //    {

        //        string description = ScenarioHelpers.GetStepsDescription();
        //        // steps
        //        string status = ScenarioHelpers.GetScenarioStatus().ToString();
        //        _test.CreateNode<And>(description).Pass(status);
        //    }
        //    else { }

        //}
        //public static void WhenStep()
        //{
        //    if (frameworkType == "BDD")
        //    {
        //        string description = ScenarioHelpers.GetStepsDescription();
        //        string status = ScenarioHelpers.GetScenarioStatus().ToString();
        //        // steps

        //        _test.CreateNode<When>(description).Pass(status);
        //    }
        //    else { }
           
            
        //}
        public static void ThenStep()
        {
            if (frameworkType == "BDD")
            {

            string description = ScenarioHelpers.GetStepsDescription();
            string status = ScenarioHelpers.GetScenarioStatus().ToString();
            _test.CreateNode<Then>(description).Pass(status);
            }
            else { }
        }

        public static void GenerateReport()
        {
            _extent.Flush();
        }


        public static void FailTest(string text ,Exception e)
        {
            _test.Log(Status.Fail, text + e.Message);
        }



        public static void InfoTest(String text)
        {

            try
            {
                _test.Log(Status.Info, text);
            }
            catch { }

        }

        public static void PassTest(String text)
        {

            try
            {
                _test.Log(Status.Pass, text);
            }
            catch { }

        }


    }
}
