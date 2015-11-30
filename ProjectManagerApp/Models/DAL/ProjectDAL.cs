using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectManagerApp.Models.DAL.Output;
using CodeFirstStoredProcs;
namespace ProjectManagerApp.Models.DAL
{
    public class ProjectDAL
    {
        private  StoredProContext db=new StoredProContext();

        public List<Project> GetProjectsResultSheet()
        {
            var projects = db.GetResultSheetProc.CallStoredProc().ToList<Project>();

            return projects;
        }

    }
}