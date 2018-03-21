using AutomationSeleniumSolution.ExtentReportLogger;
using AutomationSeleniumSolution.ProjectUtilitarios;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSeleniumSolution.SeleniumComponets
{
    public static class AssertHelper
    {
        public static void assertThat(this IWebElement element)
        {
            try
            {
                if (SeleniumGetElement.GetElement(element))
                {   //Destacar Elemento
                    Utilitarios.HighlightElement(element);

                    //Assert
                    Assert.That(element.Displayed);

                    // Gravar Log de sucesso do Assert
                    Reporter.PassTest(Utilitarios.GetCurrentMethod() + " => " + "ASSERT OK: " + element.GetAttribute("id"));
                }

            }
            catch (Exception ex)
            {   //Gravar log de Falha do Assert
                Reporter.FailTest(Utilitarios.GetCurrentMethod() + " => " + "ERRO! Elemento esperado não apareceu." + "<pre>" + ex.Message + "</pre>",ex);
                // Forçar parada do teste
                Assert.IsTrue(false);
            }


        }

        public static void assertThat(IWebElement element, String valor, String elementType)
        {
            try
            {
                if (SeleniumGetElement.GetElement(element))
                {   //Destacar Elemento
                    Utilitarios.HighlightElement(element);

                    //Testar se o Assert é por Text ou Value
                    if (elementType == "Text")
                    {   //Assert 
                        Assert.That(element.Text.Contains(valor));
                        Reporter.PassTest(Utilitarios.GetCurrentMethod() + " => " + "ASSERT OK. Mensagem exibida: " + valor);

                    }
                    else if (elementType == "Value")
                    { //Assert 
                        var elementValue = element.GetAttribute("value");
                        Assert.That(elementValue == valor);
                        Reporter.PassTest(Utilitarios.GetCurrentMethod() + " => " + "ASSERT OK. Texto do Elemento: " + valor);
                    }
                }

            }
            catch (Exception ex)
            {
                Reporter.FailTest(Utilitarios.GetCurrentMethod() + " => " + "ERRO! Mensagem esperada não apareceu: " + "<pre>" + ex.Message + "</pre>\nMensagem esperada: " + valor, ex);
                Assert.IsTrue(false);
            }
        }
    }
}
