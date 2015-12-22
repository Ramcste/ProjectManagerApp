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

        public List<Report> GetLogsHistory(int? id,int? projectid,DateTime fromdate,DateTime todate)
        {

            id = (id == null) ? 1 : id;
            projectid = (projectid == null) ? 1 : projectid;

            Loghistory inputparams = new Loghistory()
            {
                DeveloperId = (int) id,
                ProjectId=(int) projectid,
                FromDate =  fromdate.Date,
                ToDate = todate.Date

            };
            

            var report = db.LogsResultSheetProc.CallStoredProc(inputparams).ToList<Report>();

           return report;
        }

        public List<Report> GetLogsHistoryByProjectId(int id)
        {
            LogHistoryByDeveloperId inputparams = new LogHistoryByDeveloperId()
            {
                DeveloperId = id
            };

            var report = db.LogsResultAscProjectIdSheetProc.CallStoredProc(inputparams).ToList<Report>();

            return report;
        }
        public void GetSelectedLogDeleted(int id)
        {
            RemoveLogInput inputparams = new RemoveLogInput()
            {
                LogId = id,
               
            };

            db.RemoveLogProc.CallStoredProc(inputparams);
        }

        public List<Report> GetEditLogsUpdate(string editlog)
        {
            Logedit inputParams = new Logedit()
            {
           
                EditLogXML = editlog
            };

            var report = db.LogsUpdate.CallStoredProc(inputParams).ToList<Report>();
            return report;
        }


        public List<Report> GetBulkLogsDelete(string logids,int developerid)
        {
            LogBulkDelete inputparamas = new LogBulkDelete()
            {
                LogIds = logids,
                DeveloperId = developerid
            };

            var report = db.LogsBulkDelete.CallStoredProc(inputparamas).ToList<Report>();

            return report;
        } 

    }
}