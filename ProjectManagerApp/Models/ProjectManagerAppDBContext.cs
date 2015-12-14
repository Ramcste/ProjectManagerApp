using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ProjectManagerApp.Models.DAL.Input;

namespace ProjectManagerApp.Models
{
    public partial class ProjectManagerAppDBContext:DbContext
    {
        static ProjectManagerAppDBContext()
        {
            Database.SetInitializer<ProjectManagerAppDBContext>(null);
        }

        public ProjectManagerAppDBContext() : base("Name=ProjectManagerAppEntities")
        {

        }

        public DbSet<Report> Reports { get; set; } 
    }
}