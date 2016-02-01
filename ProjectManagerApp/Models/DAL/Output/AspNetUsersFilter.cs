using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagerApp.Models.DAL.Output
{
    public class AspNetUsersFilter
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string IsDeleted { get; set; }

        public string Status { get; set; }

        public int RoleId { get; set; }
    }
}