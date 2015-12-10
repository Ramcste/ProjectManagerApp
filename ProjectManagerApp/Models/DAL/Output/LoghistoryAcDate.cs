using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeFirstStoredProcs;

namespace ProjectManagerApp.Models.DAL.Output
{
    public class LoghistoryAcDate
    {
        [StoredProcAttributes.Name("Date")]
        [StoredProcAttributes.Direction(System.Data.ParameterDirection.Input)]
        [StoredProcAttributes.ParameterType(System.Data.SqlDbType.VarChar)]
        public string Date { get; set; }
    }
}