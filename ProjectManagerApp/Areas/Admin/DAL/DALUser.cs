using ProjectManagerApp.Areas.Admin.Models;
using ProjectManagerApp.Models.DAL;
using System.Collections.Generic;
using System.Linq;


namespace ProjectManagerApp.Areas.Admin.DAL
{
    public class DALUser { 

    private ProjectManagerAppEntities db = new ProjectManagerAppEntities();
    private ProjectDal dal = new ProjectDal();


        public List<NameValuePair> GetRoles(int? userId)
        {
            return (from r in db.AspNetRoles
                    join ur in db.AspNetUserRoles.Where(ur => ur.UserId == userId) on r.Id equals ur.RoleId into tmpUR
                    from tur in tmpUR.DefaultIfEmpty()
                    select new NameValuePair
                    {
                        Id = r.Id,
                        Name = r.Name,
                        IsSelected = tur == null ? false : true
                    }
                   ).ToList();
        }


        public List<NameValuePair> GetProjects(int? userId)
        {
            var projectsdeveloperlist = (from p in db.Projects
                                         join pd in db.ProjectsDevelopers.Where(pd => pd.DeveloperId == userId) on p.Id equals pd.ProjectsId into tmpUR
                                         from tur in tmpUR.DefaultIfEmpty()
                                         select new NameValuePair
                                         {
                                             Id = p.Id,
                                             Name = p.Name,
                                             IsSelected = tur == null ? false : true
                                         }
                    ).ToList();

            return projectsdeveloperlist;
        }

    }
}