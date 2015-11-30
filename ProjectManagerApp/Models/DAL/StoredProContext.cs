using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeFirstStoredProcs;
using ProjectManagerApp.Models.DAL.Output;

namespace ProjectManagerApp.Models.DAL
{
    public class StoredProContext : ProjectManagerAppDBContext
    {
        [StoredProcAttributes.Name("[Project.ResultSheet]")]

        [StoredProcAttributes.ReturnTypes(typeof (Project))]

        public StoredProc GetResultSheetProc { get; set; }

        public StoredProContext()
        {
            this.InitializeStoredProcs();
        }

    }
}