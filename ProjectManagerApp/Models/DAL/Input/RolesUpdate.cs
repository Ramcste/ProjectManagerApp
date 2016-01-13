using CodeFirstStoredProcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagerApp.Models.DAL.Input
{
    public class RolesUpdate
    {
        
        [StoredProcAttributes.Name("UserId ")]
        [StoredProcAttributes.Direction(System.Data.ParameterDirection.Input)]
        [StoredProcAttributes.ParameterType(System.Data.SqlDbType.Int)]
        public int UserId { get; set; }

        [StoredProcAttributes.Name("RolesCSV ")]
        [StoredProcAttributes.Direction(System.Data.ParameterDirection.Input)]
        [StoredProcAttributes.ParameterType(System.Data.SqlDbType.VarChar)]
        public string RolesCSV { get; set; }

    }
}