using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;

namespace AutomationSeleniumSolution.BDDHelpers
{
    public class ScenarioHelpers
    {
        public static string GetScenarioName() {

            return ScenarioContext.Current.ScenarioInfo.Title.Trim();
        }

        public static string GetFeatureName()
        {

            return TestContext.CurrentContext.Test.ClassName.Substring(31);
        }

        public static string GetStepsDescription()
        {
            return ScenarioContext.Current.StepContext.StepInfo.Text;
            
        }

        public static ScenarioExecutionStatus GetScenarioStatus()
        {

            return ScenarioContext.Current.ScenarioExecutionStatus;
        }

        public static StepDefinitionType GetStepType()
        {
            return ScenarioContext.Current.StepContext.StepInfo.StepDefinitionType;
        }
       
    }
}
