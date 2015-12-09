using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectManagerApp.Models.DAL.Output;
using CodeFirstStoredProcs;
using Newtonsoft.Json.Linq;
using ProjectManagerApp.Models.DAL.Input;

namespace ProjectManagerApp.Models.DAL
{
    public class ProjectDAL
    {
        private  StoredProContext db=new StoredProContext();

        public void SaveReport(string xml)
        {
           XmlInput inputParams = new XmlInput()
           {
               LogXML = xml

           };
            try
            {
                
                db.SaveReportCompleteProc.CallStoredProc(inputParams);
            }
            catch (Exception ex)
            {
                // ignored
            }
        }
        public List<Project> GetProjectsResultSheet()
        {
            var projects = db.ProjectResultSheetProc.CallStoredProc().ToList<Project>();

            return projects;
        }

        public List<Report> GetLogsHistory(int id)
        {
          
              Loghistory inputparams = new Loghistory()
            {
                DeveloperId = id
            };


            List<Report> report = db.LogsResultSheetProc.CallStoredProc(inputparams).ToList<Report>();

               
            
 

            return report;
        } 
       
    }
}