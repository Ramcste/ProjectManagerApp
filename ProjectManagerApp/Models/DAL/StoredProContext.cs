using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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


        // Getting log history
        [StoredProcAttributes.Name("[Logs.ResultSheet]")]
 
        [StoredProcAttributes.ReturnTypes(typeof(Report))]

        public StoredProc<Loghistory> LogsResultSheetProc { get; set; }

        public StoredProContext()
        {
            this.InitializeStoredProcs();
        }

    }
}