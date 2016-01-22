using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagerApp.Models.DAL.Output
{
    public class LogFiltered
    {
        public int Id { get; set; }

        public string Description { get; set; }
       
        public string Name { get; set; }
        public int ProjectId { get; set; }
        public string Duration { get; set; }

        [Display(Name="Start Time")]
        public string WorkStartTime { get; set; }

        [Display(Name = "End Time")]
        public string WorkEndTime { get; set; }

        public System.DateTime Date { get; set; }

        public string UserName { get; set; }

        public int DeveloperId { get; set; }



    }
}