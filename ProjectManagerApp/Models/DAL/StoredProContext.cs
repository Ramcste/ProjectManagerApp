using CodeFirstStoredProcs;
using ProjectManagerApp.Models.DAL.Input;
using ProjectManagerApp.Models.DAL.Output;

namespace ProjectManagerApp.Models.DAL
{
    public class StoredProContext : ProjectManagerAppDBContext
    {
        [StoredProcAttributes.Name("[ReportSave.Complete]")]

        public StoredProc<XmlInput> SaveReportCompleteProc { get; set; }


        [StoredProcAttributes.Name("[Project.ResultSheet]")]

        [StoredProcAttributes.ReturnTypes(typeof (Project))]

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

        public StoredProContext()
        {
            this.InitializeStoredProcs();
        }

    }
}