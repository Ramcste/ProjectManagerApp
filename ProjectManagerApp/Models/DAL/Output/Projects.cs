using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeFirstStoredProcs;

namespace ProjectManagerApp.Models.DAL.Output
{
    public  class Projects
    {

        [StoredProcAttributes.Name("Id")]
        [StoredProcAttributes.Direction(System.Data.ParameterDirection.Input)]
        [StoredProcAttributes.ParameterType(System.Data.SqlDbType.Int)]
        public int Id { get; set; }

        [StoredProcAttributes.Name("Name")]
        [StoredProcAttributes.Direction(System.Data.ParameterDirection.Input)]
        [StoredProcAttributes.ParameterType(System.Data.SqlDbType.VarChar)]
        public string Name { get; set; }

        [StoredProcAttributes.Name("ClientName")]
        [StoredProcAttributes.Direction(System.Data.ParameterDirection.Input)]
        [StoredProcAttributes.ParameterType(System.Data.SqlDbType.VarChar)]
        public string ClientName { get; set; }

        [StoredProcAttributes.Name("Description")]
        [StoredProcAttributes.Direction(System.Data.ParameterDirection.Input)]
        [StoredProcAttributes.ParameterType(System.Data.SqlDbType.VarChar)]
        public string Description { get; set; }

        [StoredProcAttributes.Name("Status")]
        [StoredProcAttributes.Direction(System.Data.ParameterDirection.Input)]
        [StoredProcAttributes.ParameterType(System.Data.SqlDbType.Bit)]
        public bool Status { get; set; }
    }
}