using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSeleniumSolution.ProjectUtilitarios
{
    public static class DateHelper
    {
        public static string GetDateNow()
        {
            DateTime dta = DateTime.Now;
            string dtaStr = dta.ToString("dd/MM/yyyy");

            return dtaStr;

        }

        public static string GetDateTimeNow()
        {
            DateTime dta = DateTime.Now;
            string dtaStr = dta.ToString("dd/MM/yyyy HH:mm:ss");

            return dtaStr;

        }
    }
}
