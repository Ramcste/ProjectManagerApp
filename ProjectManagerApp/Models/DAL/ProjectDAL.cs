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

        public List<Report> GetLogsHistory(int? id,int? projectid,string fromdate,string todate)
        {

            if (fromdate== null)
            {
                fromdate="";
            }

            else
            {
                fromdate = fromdate.ToString();
            }

            if (todate == null)
            {
                todate = "";
            }
            else
            {
                todate = todate.ToString();
            }

            id = (id == null) ? 1 : id;
            projectid = (projectid == null) ? 1 : projectid;

            Loghistory inputparams = new Loghistory()
            {
                DeveloperId = (int) id,
                ProjectId=(int) projectid,
                FromDate =  fromdate,
                ToDate = todate

            };


            var report = db.LogsResultSheetProc.CallStoredProc(inputparams).ToList<Report>();

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


   

    }
}