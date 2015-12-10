using System;
using System.Collections.Generic;
using ProjectManagerApp.Models.DAL.Output;
using ProjectManagerApp.Models.DAL.Input;

namespace ProjectManagerApp.Models.DAL
{
    public class ProjectDal
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
            catch (Exception)
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


            var report = db.LogsResultSheetProc.CallStoredProc(inputparams).ToList<Report>();

           return report;
        }

        public List<Report> GetLogHistoryAcDate(string date)
        {
            LoghistoryAcDate inputparams = new LoghistoryAcDate()
            {
                Date = date
            };

            var reports = db.LogsResultSheetProcAcDate.CallStoredProc(inputparams).ToList<Report>();


            return reports;
        } 
       
    }
}