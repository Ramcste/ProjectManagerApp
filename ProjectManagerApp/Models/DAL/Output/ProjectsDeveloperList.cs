using CodeFirstStoredProcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagerApp.Models.DAL.Output
{
    public class ProjectsDeveloperList
    {
        [StoredProcAttributes.Name("DeveloperId")]
        [StoredProcAttributes.Direction(System.Data.ParameterDirection.Input)]
        [StoredProcAttributes.ParameterType(System.Data.SqlDbType.Int)]
        public int DeveloperId { get; set; }

        [StoredProcAttributes.Name("ProjectsId")]
        [StoredProcAttributes.Direction(System.Data.ParameterDirection.Input)]
        [StoredProcAttributes.ParameterType(System.Data.SqlDbType.Int)]
        public int ProjectsId { get; set; }

    }
}