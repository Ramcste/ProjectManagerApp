using CodeFirstStoredProcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagerApp.Models.DAL.Output
{
    public class Filter
    {

        [StoredProcAttributes.Name("DeveloperId")]
        [StoredProcAttributes.Direction(System.Data.ParameterDirection.Input)]
        [StoredProcAttributes.ParameterType(System.Data.SqlDbType.Int)]
        public int DeveloperId { get; set; }


        [StoredProcAttributes.Name("ProjectId")]
        [StoredProcAttributes.Direction(System.Data.ParameterDirection.Input)]
        [StoredProcAttributes.ParameterType(System.Data.SqlDbType.Int)]
        public int ProjectId { get; set; }


        [StoredProcAttributes.Name("Keywords")]
        [StoredProcAttributes.Direction(System.Data.ParameterDirection.Input)]
        [StoredProcAttributes.ParameterType(System.Data.SqlDbType.VarChar)]
        public string Keywords { get; set; }


        [StoredProcAttributes.Name("From")]
        [StoredProcAttributes.Direction(System.Data.ParameterDirection.Input)]
        [StoredProcAttributes.ParameterType(System.Data.SqlDbType.DateTime)]
        public DateTime? From { get; set; }


        [StoredProcAttributes.Name("To")]
        [StoredProcAttributes.Direction(System.Data.ParameterDirection.Input)]
        [StoredProcAttributes.ParameterType(System.Data.SqlDbType.DateTime)]
        public DateTime? To { get; set; }
    }  }