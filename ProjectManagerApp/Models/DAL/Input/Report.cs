using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagerApp.Models.DAL.Input
{
    public class Report
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int ProjectId  { get; set; }

        public string Duration { get; set; }

        public string WorkStartTime { get; set; }

        public string WorkEndTime { get; set; }
    }
}