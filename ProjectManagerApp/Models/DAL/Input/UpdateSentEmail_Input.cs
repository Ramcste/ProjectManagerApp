using CodeFirstStoredProcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagerApp.Models.DAL.Input
{
    public class UpdateSentEmail_Input
    {
        [StoredProcAttributes.Name("Id")]
        [StoredProcAttributes.Direction(System.Data.ParameterDirection.Input)]
        public Int64 Id { get; set; }

        [StoredProcAttributes.Name("MsgType")]
        [StoredProcAttributes.Direction(System.Data.ParameterDirection.Output)]
        [StoredProcAttributes.ParameterType(System.Data.SqlDbType.VarChar)]
        [StoredProcAttributes.Size(10)]
        public string MsgType { get; set; }

        [StoredProcAttributes.Name("MsgText")]
        [StoredProcAttributes.Direction(System.Data.ParameterDirection.Output)]
        [StoredProcAttributes.ParameterType(System.Data.SqlDbType.VarChar)]
        [StoredProcAttributes.Size(100)]
        public string MsgText { get; set; }
    }
}