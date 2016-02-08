using CodeFirstStoredProcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagerApp.Models.DAL.Input
{
    public class LogTimeCheck
    {

        [StoredProcAttributes.Name("DeveloperId")]
        [StoredProcAttributes.Direction(System.Data.ParameterDirection.Input)]
        [StoredProcAttributes.ParameterType(System.Data.SqlDbType.Int)]
        public int DeveloperId { get; set; }

        [StoredProcAttributes.Name("StartTime")]
        [StoredProcAttributes.Direction(System.Data.ParameterDirection.Input)]
        [StoredProcAttributes.ParameterType(System.Data.SqlDbType.VarChar)]
        public string StartTime { get; set; }

        [StoredProcAttributes.Name("EndTime")]
        [StoredProcAttributes.Direction(System.Data.ParameterDirection.Input)]
        [StoredProcAttributes.ParameterType(System.Data.SqlDbType.VarChar)]
        public string EndTime { get; set; }


        [StoredProcAttributes.Name("Date")]
        [StoredProcAttributes.Direction(System.Data.ParameterDirection.Input)]
        [StoredProcAttributes.ParameterType(System.Data.SqlDbType.Date)]
        public string Date { get; set; }
      
    }
}