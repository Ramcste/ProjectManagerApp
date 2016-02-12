using CodeFirstStoredProcs;
using ProjectManagerApp.Areas.Admin.Models;
using ProjectManagerApp.Models.DAL.Input;
using ProjectManagerApp.Models.DAL.Output;
namespace ProjectManagerApp.Models.DAL
{
    public class StoredProContext : ProjectManagerAppContext
    {

        //For Developer

        [StoredProcAttributes.Name("[ReportSave.Complete]")]

        public StoredProc<XmlInput> SaveReportCompleteProc { get; set; }


        [StoredProcAttributes.Name("[Project.ResultSheet]")]

        [StoredProcAttributes.ReturnTypes(typeof (Projects))]

        public StoredProc ProjectResultSheetProc { get; set; }


        // Getting log history according to developerid,projectid and date
        [StoredProcAttributes.Name("[Logs.ResultSheet]")]
 
        [StoredProcAttributes.ReturnTypes(typeof(Report))]

        public StoredProc<Loghistory> LogsResultSheetProc { get; set; }


        [StoredProcAttributes.Name("[Logs.ResultSheetAscProjectId]")]

        [StoredProcAttributes.ReturnTypes(typeof(Report))]

        public StoredProc<LogHistoryByDeveloperId> LogsResultAscProjectIdSheetProc { get; set; }


        [StoredProcAttributes.Name("[Logs.DeleteSelected]")]

        public StoredProc<RemoveLogInput> RemoveLogProc { get; set; }


        [StoredProcAttributes.Name("[Logs.ResultSheet.Update]")]

        public StoredProc<Logedit> LogsUpdate { get; set; }


        [StoredProcAttributes.Name("[Logs.BulkDelete]")]

        public StoredProc<LogBulkDelete> LogsBulkDelete { get; set; }


        [StoredProcAttributes.Name("[Logs.ResultSheetAscDate]")]

        [StoredProcAttributes.ReturnTypes(typeof(Report))]

        public StoredProc<LogHistoryByDeveloperId> LogsResultAscDateSheetProc { get; set; }


        // for developer log resultsheet in partialview

        [StoredProcAttributes.Name("[DeveloperLogs.ResultSheet]")]

        [StoredProcAttributes.ReturnTypes(typeof(LogFiltered))]

        public StoredProc<Loghistory> DeveloperLogsResultSheetProc { get; set; }



        // for specific developer specific projects

        [StoredProcAttributes.Name("[ProjectsDeveloper.ResultSheet]")]

        [StoredProcAttributes.ReturnTypes(typeof(Projects))]

        public StoredProc<Output.ProjectsDevelopers> ProjectsDeveloperResultSheetProc { get; set; }


        // display todays log of specific developer

        [StoredProcAttributes.Name("[Logs.TodaysResultSheet]")]

        [StoredProcAttributes.ReturnTypes(typeof(LogFiltered))]

        public StoredProc<ProjectsDevelopers> TodyasLogsResultSheetProc { get; set; }

        // check the log exist between this timeline or not

        [StoredProcAttributes.Name("[Logs.TimeCheck]")]

        [StoredProcAttributes.ReturnTypes(typeof(LogFiltered))]

        public StoredProc<LogTimeCheck> LogsTimeCheckSheetProc { get; set; }



        // for admin

        [StoredProcAttributes.Name("[AspNetUsers.ResultSheet]")]

        [StoredProcAttributes.ReturnTypes(typeof(AspNetUsers))]

        public StoredProc AspNetUsersResultSheetProc { get; set; }


        // for getting log according different option

        [StoredProcAttributes.Name("[Logs.ResultSheetByOption]")]

        [StoredProcAttributes.ReturnTypes(typeof(Log))]

        public StoredProc<LogResultSheetByOption> LogsResultSheetByOptionProc { get; set; }

        // for filtering by all options available

        [StoredProcAttributes.Name("[Logs.Filter]")]

        [StoredProcAttributes.ReturnTypes(typeof(LogFiltered))]

        public StoredProc<Filter> LogsResultSheetByFilter { get; set; }

        // for filtering projects by different values

        [StoredProcAttributes.Name("[Projects.Filter]")]

        [StoredProcAttributes.ReturnTypes(typeof(Project))]

        public StoredProc<ProjectsFilter> ProjetcsResultSheetByFilter { get; set; }


        // for filtering aspnet users by email,id,isdeleted,isactive

        [StoredProcAttributes.Name("[AspNetUsers.Filter]")]

        [StoredProcAttributes.ReturnTypes(typeof(AspNetUser))]

        public StoredProc<AspNetUsersFilter> AspNetUsersResultSheetByFilter { get; set; }

        // for getting all roles

        [StoredProcAttributes.Name("[AspNetRoles.ResultSheet]")]

        [StoredProcAttributes.ReturnTypes(typeof(AspNetRole))]

        public StoredProc AspNetRoleResultSheet { get; set; }


        // for updating user roles

        [StoredProcAttributes.Name("[AspNetUserRoles.Update]")]

        [StoredProcAttributes.ReturnTypes(typeof(AspNetUserRole))]

        public StoredProc<RolesUpdate> AspNetUserRoleUpdateResultSheet { get; set; }



        // for updating projects developer


        [StoredProcAttributes.Name("[ProjectsDeveloper.Update]")]

        [StoredProcAttributes.ReturnTypes(typeof(ProjectsDeveloperList))]

        public StoredProc<ProjectsDeveloperUpdate> ProjectsDeveloperUpdateResultSheet { get; set; }


        // for filtering projectsdeveloper by developerid and projectsid


        [StoredProcAttributes.Name("[ProjectsDevelopers.Filter]")]

        [StoredProcAttributes.ReturnTypes(typeof(ProjectsDeveloperFilterResult))]

        public StoredProc<ProjectsDeveloperList> ProjectsDeveloperFilterResultSheet { get; set; }


        public StoredProContext()
        {
            this.InitializeStoredProcs();
        }

    }
}