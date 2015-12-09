using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeFirstStoredProcs;

namespace ProjectManagerApp.Models.DAL.Input
{
    public class Report
    {
        [StoredProcAttributes.Name("Id")]
        [StoredProcAttributes.Direction(System.Data.ParameterDirection.Input)]
        [StoredProcAttributes.ParameterType(System.Data.SqlDbType.Int)]
        public int Id { get; set; }


        [StoredProcAttributes.Name("Description")]
        [StoredProcAttributes.Direction(System.Data.ParameterDirection.Input)]
        [StoredProcAttributes.ParameterType(System.Data.SqlDbType.VarChar)]
        public string Description { get; set; }


        [StoredProcAttributes.Name("ProjectId")]
        [StoredProcAttributes.Direction(System.Data.ParameterDirection.Input)]
        [StoredProcAttributes.ParameterType(System.Data.SqlDbType.Int)]
        public int ProjectId  { get; set; }


        [StoredProcAttributes.Name("Duration")]
        [StoredProcAttributes.Direction(System.Data.ParameterDirection.Input)]
        [StoredProcAttributes.ParameterType(System.Data.SqlDbType.VarChar)]
        public string Duration { get; set; }


        [StoredProcAttributes.Name("WorkStartTime")]
        [StoredProcAttributes.Direction(System.Data.ParameterDirection.Input)]
        [StoredProcAttributes.ParameterType(System.Data.SqlDbType.VarChar)]
        public string WorkStartTime { get; set; }


        [StoredProcAttributes.Name("WorkEndTime")]
        [StoredProcAttributes.Direction(System.Data.ParameterDirection.Input)]
        [StoredProcAttributes.ParameterType(System.Data.SqlDbType.VarChar)]
        public string WorkEndTime { get; set; }

        [StoredProcAttributes.Name("Date")]
        [StoredProcAttributes.Direction(System.Data.ParameterDirection.Input)]
        [StoredProcAttributes.ParameterType(System.Data.SqlDbType.VarChar)]
        public string Date { get; set; }

        [StoredProcAttributes.Name("DeveloperId")]
        [StoredProcAttributes.Direction(System.Data.ParameterDirection.Input)]
        [StoredProcAttributes.ParameterType(System.Data.SqlDbType.Int)]
        public int DeveloperId { get; set; }


    }
}