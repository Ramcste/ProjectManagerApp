using System;
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

        public List<Report> GetLogsHistory(int developerid,int? projectid,DateTime? fromdate,DateTime? todate)
        {

            int projectId = projectid.HasValue ? projectid.Value : 0;
       

            Loghistory inputparams = new Loghistory()
            {
                DeveloperId = developerid,
                ProjectId=projectId,
                FromDate =  fromdate,
                ToDate = todate

            };
            

            var report = db.LogsResultSheetProc.CallStoredProc(inputparams).ToList<Report>();

           return report;
        }

        public List<Report> GetLogsHistoryByProjectId(int developerid,int? projectid)
        {
            int projectId = projectid.HasValue ? projectid.Value : 0;
            LogHistoryByDeveloperId inputparams = new LogHistoryByDeveloperId()
            {
                DeveloperId = developerid,
                ProjectId=projectId
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
            Output.ProjectsDevelopers inputparams = new Output.ProjectsDevelopers()
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
       
        // projects sheet by filter
        public List<Project> GetProjectsResultSheetByFilter(int? projectid,string status,string isdeleted)
        {
            int projectId = projectid.HasValue ? projectid.Value : 0;

            ProjectsFilter inputparams = new ProjectsFilter {
                ProjectId=projectId,
                Status=status,
                IsDeleted=isdeleted
            };

            var projects=db.ProjetcsResultSheetByFilter.CallStoredProc(inputparams).ToList<Project>();

            return projects;
        }

        // aspnet users sheet by filter

        public List<AspNetUser> GetAspNetUsersResultSheetByFilter(int? id,string email,string isdeleted,string isactive)
        {
            int Id = id.HasValue ? id.Value : 0;

            AspNetUsersFilter inputparams = new AspNetUsersFilter
            {
                Id = Id,
                Email = email,
                IsDeleted=isdeleted,
                IsActive=isactive
            };

            var users = db.AspNetUsersResultSheetByFilter.CallStoredProc(inputparams).ToList<AspNetUser>();

            return users;
        }

        // get all roles from aspnet  roles

        public List<AspNetRole> GetAllAspNetRole()
        {
            var roles = db.AspNetRoleResultSheet.CallStoredProc().ToList<AspNetRole>();

            return roles;
        }

      
        
        // getting user roles update
        public List<AspNetUserRole> GetAllAspNetUserRolesUpdate(int userid,string rolescsv)
        {
            RolesUpdate inputparams = new RolesUpdate
            {
                UserId = userid,
                RolesCSV = rolescsv
            };


            var rolesupdate = db.AspNetUserRoleUpdateResultSheet.CallStoredProc(inputparams).ToList<AspNetUserRole>();

            return (rolesupdate);
        }

        // geeting projects developer update

        public List<ProjectsDeveloperList> GetProjectsDeveloperUpdate(int developerid, string projectscsv)
        {
            ProjectsDeveloperUpdate inputparams = new ProjectsDeveloperUpdate
            {
                DeveloperId = developerid,
                ProjectsCSV = projectscsv
            };


            var rolesupdate = db.ProjectsDeveloperUpdateResultSheet.CallStoredProc(inputparams).ToList<ProjectsDeveloperList>();

            return (rolesupdate);
        }



       // for filtering projectsdeveloper by developerid and projectsid

        public List<ProjectsDeveloperFilterResult> GetProjectsDevelopersResultSheetFilter(int? developerid, int? projectsid)
        {
            int developerId = developerid.HasValue ? developerid.Value : 0;
            int projectsId = projectsid.HasValue ? projectsid.Value : 0;

            ProjectsDeveloperList inputparams = new ProjectsDeveloperList
            {
                DeveloperId = developerId,
                ProjectsId = projectsId
            };

            var projectsdevelopers = db.ProjectsDeveloperFilterResultSheet.CallStoredProc(inputparams).ToList<ProjectsDeveloperFilterResult>();

            return projectsdevelopers;
        }
        
    }
}