using CodeFirstStoredProcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagerApp.Models.DAL.Output
{
    public class LogResultSheetByOption
    {
        [StoredProcAttributes.Name("From")]
        [StoredProcAttributes.Direction(System.Data.ParameterDirection.Input)]
        [StoredProcAttributes.ParameterType(System.Data.SqlDbType.DateTime)]
        public DateTime From { get; set; }

        [StoredProcAttributes.Name("To")]
        [StoredProcAttributes.Direction(System.Data.ParameterDirection.Input)]
        [StoredProcAttributes.ParameterType(System.Data.SqlDbType.DateTime)]
        public DateTime To { get; set; }
    }
}