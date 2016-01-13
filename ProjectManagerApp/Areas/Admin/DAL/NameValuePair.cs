using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagerApp.Areas.Admin.DAL
{
    public class NameValuePair
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
}