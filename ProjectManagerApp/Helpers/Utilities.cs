using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagerApp.Helpers
{
    public class Utilities
    {

        public static object JsonOkObject(object obj)
        {
            var result = new
            {
                status = "ok",
                data = obj
            };
            return result;
        }

        public static object JsonErrorObject(string Errormsg)
        {
            var result = new
            {
                status = "error",
                data = Errormsg
            };
            return result;
        }


        public static void getDateRange(string DatedOn, out DateTime? From, out DateTime? Till, DateTime? Fromval, DateTime? Tillval)
        {
            #region DateRanges

            From = Fromval;
            Till = Tillval;

            if (DatedOn == "Tomorrow")
            {
                From = DateTime.Now.AddDays(1);
                Till = DateTime.Now.AddDays(1);
            }
            else if (DatedOn == "Today")
            {
                From = DateTime.Now;
                Till = DateTime.Now;
            }
            else if (DatedOn == "Yesterday")
            {
                From = DateTime.Now.AddDays(-1);
                Till = DateTime.Now.AddDays(-1);
            }
            //else if (DatedOn == "On or After")
            //{
            //    Till = null;
            //}
            //else if (DatedOn == "On")
            //{
            //    Till = From;
            //}
            //else if (DatedOn == "On or Before")
            //{
            //    Till = From;
            //    From = null;
            //}
            else if (DatedOn == "Between")
            {
               // From = From;
               // Till = Till;
            }
            else if (DatedOn == "Next Week")
            {
                //Next week       
                From = DateTime.Now.AddDays(7).AddDays(-Convert.ToInt16(DateTime.Now.DayOfWeek));
                Till = From.Value.AddDays(6);
            }
            else if (DatedOn == "This Week")
            {
                //This week       
                From = DateTime.Now.AddDays(-Convert.ToInt16(DateTime.Now.DayOfWeek));
                Till = From.Value.AddDays(6);
            }
            else if (DatedOn == "Previous Week")
            {
                //Previous week       
                From = DateTime.Now.AddDays(-7).AddDays(-Convert.ToInt16(DateTime.Now.DayOfWeek));
                Till = From.Value.AddDays(6);
            }
            else if (DatedOn == "Next Month")
            {
                From = DateTime.Now.AddMonths(1).AddDays(-DateTime.Now.Day + 1);
                Till = From.Value.AddMonths(1).AddDays(-1);
            }
            else if (DatedOn == "This Month")
            {
                From = DateTime.Now.AddDays(-DateTime.Now.Day + 1);
                Till = From.Value.AddMonths(1).AddDays(-1);
            }
            else if (DatedOn == "Previous Month")
            {
                //Previous Month
                From = DateTime.Now.AddMonths(-1).AddDays(-DateTime.Now.Day + 1);
                Till = From.Value.AddMonths(1).AddDays(-1);
            }
            else if (DatedOn == "Next Year")
            {
                //Next Year
                From = DateTime.Now.AddYears(1).AddDays(-DateTime.Now.DayOfYear + 1);
                Till = From.Value.AddYears(1).AddDays(-1);
            }
            else if (DatedOn == "This Year")
            {
                //This Year
                From = DateTime.Now.AddDays(-DateTime.Now.DayOfYear + 1);
                Till = From.Value.AddYears(1).AddDays(-1);

            }
            else if (DatedOn == "Last Year")
            {
                //Previous Year
                From = DateTime.Now.AddYears(-1).AddDays(-DateTime.Now.DayOfYear + 1);
                Till = From.Value.AddYears(1).AddDays(-1);
            }
            //else if (DatedOn == "anytime")
            //{
            //    From = null;
            //    Till = null;

            //}
            #endregion
        }


    }
}