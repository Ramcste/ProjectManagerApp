using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagerApp.Models.DAL.Output
{
    public class ProjectsDeveloperFilterResult
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public string  ProjectName { get; set; }

        public int DeveloperId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
    }
}