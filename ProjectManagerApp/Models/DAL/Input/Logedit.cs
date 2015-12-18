using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeFirstStoredProcs;

namespace ProjectManagerApp.Models.DAL.Input
{
    public class Logedit
    {


        [StoredProcAttributes.Name("EditLogXML ")]
        [StoredProcAttributes.Direction(System.Data.ParameterDirection.Input)]
        [StoredProcAttributes.ParameterType(System.Data.SqlDbType.VarChar)]
        public string EditLogXML { get; set; }
    }
}