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


        // for specific developer specific projects

        [StoredProcAttributes.Name("[ProjectsDeveloper.ResultSheet]")]

        [StoredProcAttributes.ReturnTypes(typeof(Projects))]

        public StoredProc<Output.ProjectsDeveloper> ProjectsDeveloperResultSheetProc { get; set; }


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

        public StoredProContext()
        {
            this.InitializeStoredProcs();
        }

    }
}