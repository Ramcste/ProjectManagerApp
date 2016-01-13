using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagerApp.Models.DAL.Output
{
    public class ProjectsFilter
    {
        public int ProjectId { get; set; }

        public string Status { get; set; }

        public String IsDeleted { get; set; }

    }
}