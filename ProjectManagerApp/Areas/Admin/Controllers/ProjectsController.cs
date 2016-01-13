using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectManagerApp.Areas.Admin.Models;
using ProjectManagerApp.Models.DAL;
using ProjectManagerApp.Areas.Admin.DAL;

namespace ProjectManagerApp.Areas.Admin.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private ProjectManagerAppEntities db = new ProjectManagerAppEntities();
        private ProjectDal dal = new ProjectDal();
    
        // GET: Admin/Projects
        public ActionResult Index()
        {
            ViewBag.Projects = dal.GetProjectsResultSheet();
            return View(db.Projects.ToList());
        }

        // GET: Admin/Projects/Details/5
        public ActionResult Details(int? id)
        {
          

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Admin/Projects/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: Admin/Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ClientName,Status,Description,IsDeleted")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(project);
        }

        // GET: Admin/Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Admin/Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ClientName,Status,Description,IsDeleted")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        // GET: Admin/Projects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Admin/Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            project.IsDeleted = true;
            // db.Projects.Remove(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // for filtering

         public ActionResult GetProjectsResultSheetByFilter(int? projectid,string status,string isDeleted)
        {
            var projects = dal.GetProjectsResultSheetByFilter(projectid, status, isDeleted);
            return PartialView("_ProjectsList",projects);
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
