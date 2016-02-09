using ProjectManagerApp.Models.DAL.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagerApp.Models.DAL.Output
{
    public class LogListByDate
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public List<LogFiltered> LogFilteredList { get; set; }
    }
}