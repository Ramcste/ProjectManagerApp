using CodeFirstStoredProcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagerApp.Models.DAL.Input
{
    public class ProjectsDeveloperUpdate
    {
        [StoredProcAttributes.Name("DeveloperId ")]
        [StoredProcAttributes.Direction(System.Data.ParameterDirection.Input)]
        [StoredProcAttributes.ParameterType(System.Data.SqlDbType.Int)]
        public int DeveloperId { get; set; }

        [StoredProcAttributes.Name("ProjectsCSV ")]
        [StoredProcAttributes.Direction(System.Data.ParameterDirection.Input)]
        [StoredProcAttributes.ParameterType(System.Data.SqlDbType.VarChar)]
        public string ProjectsCSV { get; set; }
    }
}