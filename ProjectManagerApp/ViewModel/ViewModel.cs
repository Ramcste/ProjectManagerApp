using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectManagerApp.Models.DAL.Input;
using ProjectManagerApp.Models.DAL.Output;

namespace ProjectManagerApp.ViewModel
{
    public class ViewModel
    {
        public Project Projects { get; set; }
        
        public Report Reports { get; set; }  
    }
}