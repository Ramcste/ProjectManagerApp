using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectManagerApp.Areas.Admin.Models;
using ProjectManagerApp.Areas.Admin.DAL;
using Microsoft.AspNet.Identity;
using ProjectManagerApp.Models.DAL;
using ProjectManagerApp.Models.DAL.Output;

namespace ProjectManagerApp.Areas.Admin.Controllers
{
    public class ProjectsDevelopersController : Controller
    {
        private ProjectManagerAppEntities db = new ProjectManagerAppEntities();
        private DALUser daluser = new DALUser();
        private ProjectDal dal = new ProjectDal();
        // GET: Admin/ProjectsDevelopers
        public ActionResult Index()
        {
            ViewBag.Users = dal.GetAspNetUsersResultSheet();

            ViewBag.Projects = dal.GetProjectsResultSheet();

           //var projectsDevelopers = db.ProjectsDevelopers.Include(p => p.AspNetUser).Include(p => p.Project);

            var projectsDevelopers = dal.GetProjectsDevelopersResultSheetFilter(0, 0);

            return View(projectsDevelopers);
           // return View();
        }

        // GET: Admin/ProjectsDevelopers/Details/5
        public ActionResult Details(int? id)
        {
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

       
            ProjectsDeveloper projectsDeveloper = db.ProjectsDevelopers.Find(id);
            ViewBag.ProjectsDeveloper = daluser.GetProjects(projectsDeveloper.DeveloperId);
            if (projectsDeveloper == null)
            {
                return HttpNotFound();
            }
            return View(projectsDeveloper);
        }

        // GET: Admin/ProjectsDevelopers/Create
        public ActionResult Create()
        {
            ViewBag.ProjectsDeveloper = daluser.GetProjects(0);
            ViewBag.DeveloperId = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.ProjectsId = new SelectList(db.Projects, "Id", "Name");
          
            return View();
        }

        // POST: Admin/ProjectsDevelopers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DeveloperId,ProjectsId")] ProjectsDeveloper projectsDeveloper)
        {
          
            //ViewBag.ProjectsDeveloper = daluser.GetProjects(0);
            int developerid = projectsDeveloper.DeveloperId;
            
            string projectsDeveloperCSV = Request.Form["chkProjectsDeveloper"];

            if (ModelState.IsValid)
            {
                dal.GetProjectsDeveloperUpdate(developerid, projectsDeveloperCSV);
                //db.ProjectsDevelopers.Add(projectsDeveloper);
                //db.SaveChanges();
            
                
                return RedirectToAction("Index");
            }

            ViewBag.DeveloperId = new SelectList(db.AspNetUsers, "Id", "Email", projectsDeveloper.DeveloperId);
            ViewBag.ProjectsId = new SelectList(db.Projects, "Id", "Name", projectsDeveloper.ProjectsId);

            return View(projectsDeveloper);
        }

        // GET: Admin/ProjectsDevelopers/Edit/5
        public ActionResult Edit(int? id)
        {
          

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectsDeveloper projectsDeveloper = db.ProjectsDevelopers.Find(id);
            ViewBag.ProjectsDeveloper = daluser.GetProjects(projectsDeveloper.DeveloperId);
            if (projectsDeveloper == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeveloperId = new SelectList(db.AspNetUsers, "Id", "Email", projectsDeveloper.DeveloperId);
            ViewBag.ProjectsId = new SelectList(db.Projects, "Id", "Name", projectsDeveloper.ProjectsId);
           
            return View(projectsDeveloper);
        }

        // POST: Admin/ProjectsDevelopers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DeveloperId,ProjectsId")] ProjectsDeveloper projectsDeveloper)
        {
       
            int developerid = projectsDeveloper.DeveloperId;
            ViewBag.ProjectsDeveloper = daluser.GetProjects(developerid);
            string projectsDeveloperCSV = Request.Form["chkProjectsDeveloper"];

            if (ModelState.IsValid)
            {
                dal.GetProjectsDeveloperUpdate(developerid, projectsDeveloperCSV);
               // db.Entry(projectsDeveloper).State = EntityState.Modified;
               // db.SaveChanges();
               
                return RedirectToAction("Index");
            }
            ViewBag.DeveloperId = new SelectList(db.AspNetUsers, "Id", "Email", projectsDeveloper.DeveloperId);
           // ViewBag.ProjectsId = new SelectList(db.Projects, "Id", "Name", projectsDeveloper.ProjectsId);
            return View(projectsDeveloper);
        }

        // GET: Admin/ProjectsDevelopers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectsDeveloper projectsDeveloper = db.ProjectsDevelopers.Find(id);
            if (projectsDeveloper == null)
            {
                return HttpNotFound();
            }
            return View(projectsDeveloper);
        }

        // POST: Admin/ProjectsDevelopers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectsDeveloper projectsDeveloper = db.ProjectsDevelopers.Find(id);
            db.ProjectsDevelopers.Remove(projectsDeveloper);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // for filtering by projectname and developerid
        public ActionResult GetProjectsDeveloperResultSheetByFilter(int ? developerid,int? projectsid)
        {
            //var projectsdeveloperlist = from pd in db.ProjectsDevelopers select pd;

            //var projectsdevelopers = projectsdeveloperlist.Where(p => p.DeveloperId == developerid && p.ProjectsId == projectsid);

            var projectsdevelopers = dal.GetProjectsDevelopersResultSheetFilter(developerid, projectsid);

            return PartialView("_ProjectsDeveloperList", projectsdevelopers);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
