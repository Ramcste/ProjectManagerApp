﻿using System;
using System.Collections.Generic;
using ProjectManagerApp.Models.DAL.Output;
using ProjectManagerApp.Models.DAL.Input;
using ProjectManagerApp.Areas.Admin.Models;
using ProjectManagerApp.Helpers;

namespace ProjectManagerApp.Models.DAL
{
    public class ProjectDal
    {
        private  StoredProContext db=new StoredProContext();


        // for developer
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
        public List<Projects> GetProjectsResultSheet()
        {
           
            var projects = db.ProjectResultSheetProc.CallStoredProc().ToList<Projects>();

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

        public List<Report> GetLogsHistoryByProjectId(int developerid,int projectid)
        {
            LogHistoryByDeveloperId inputparams = new LogHistoryByDeveloperId()
            {
                DeveloperId = developerid,
                ProjectId=projectid
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

        

        public List<Report> GetProjectResultSheetByDate(int developerid)
        {
            LogHistoryByDeveloperId inputparams = new LogHistoryByDeveloperId()
            {
                DeveloperId = developerid
            };

            var report = db.LogsResultAscDateSheetProc.CallStoredProc(inputparams).ToList<Report>();

            return report;
        }


        // for specific users load specific projects assigned to hin

        public List<Projects> GetProjectsDeveloperResultSheet(int developerid)
        {
            Output.ProjectsDeveloper inputparams = new Output.ProjectsDeveloper()
            {
                DeveloperId = developerid
            };

            var projects = db.ProjectsDeveloperResultSheetProc.CallStoredProc(inputparams).ToList<Projects>();

            return projects;
        }



        // for admin 


        public List<AspNetUsers> GetAspNetUsersResultSheet()
        {
            var users = db.AspNetUsersResultSheetProc.CallStoredProc().ToList<AspNetUsers>();
            return users;
        }

      


        public List<Log> GetLogResultSheetByOption(DateTime from,DateTime till)
        {
            LogResultSheetByOption inputparams = new LogResultSheetByOption()
            {
                From=from,
                To=till
            };


            var log = db.LogsResultSheetByOptionProc.CallStoredProc(inputparams).ToList<Log>();

            return log;
        }
         
        
        // log result sheet by filter

        public List<LogFiltered> GetLogResultSheetByFilter(int? developerid,int? projectid,string keywords,DateTime? from,DateTime? to)
        {
            int developerId = developerid.HasValue ? developerid.Value : 0;
           

            int projectId = projectid.HasValue ? projectid.Value : 0;

           // string keyWords = keywords.Length > 0 ? keywords : "";
           
            Filter inputparams = new Filter
            {
                DeveloperId = developerId,
                ProjectId = projectId,
                Keywords = keywords,
                From=from,
                To=to
            };


            var logs = db.LogsResultSheetByFilter.CallStoredProc(inputparams).ToList<LogFiltered>();

            return logs;
        }
       

    }
}