//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectManagerApp.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Log
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public string WorkStartTime { get; set; }
        public string WorkEndTime { get; set; }
        public string Duration { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<int> DeveloperId { get; set; }
    }
}