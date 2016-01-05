using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectManagerApp.Areas.Admin.Models;
using ProjectManagerApp.Models;
using ProjectManagerApp.Models.DAL;
using System.Web.Http.Results;
using ProjectManagerApp.Models.DAL.Input;
using ProjectManagerApp.Helpers;
using ProjectManagerApp.Models.DAL.Output;

namespace ProjectManagerApp.Areas.Admin.Controllers
{
  //  [Authorize(Roles = "Admin")]
    public class LogsController : Controller
    {
        private ProjectManagerAppEntities db = new ProjectManagerAppEntities();

        private ProjectDal dal = new ProjectDal();
        // GET: Admin/Logs
        //  sort by date
        public ActionResult Index()
        {
            ViewBag.Projects = dal.GetProjectsResultSheet();
            ViewBag.Users = dal.GetAspNetUsersResultSheet();

            var logs = dal.GetLogResultSheetByFilter(0,0,"",null,null).ToList<LogFiltered>();
          //  var logs = (db.Logs).OrderBy(log=>log.Date).ToList();
            return View(logs);
        }

        // filter by projectname  sort by date and projectid
        //[HttpGet]
        //public ActionResult GetLogResultSheetByProject(string filterBy)
        //{
        //    var logs = from log in (db.Logs).OrderBy(log=>log.Date) select log;

        //    if (!String.IsNullOrEmpty(filterBy))
        //    {
        //        int id = int.Parse(filterBy);
        //        logs = logs.Where(p => p.ProjectId.Equals(id));
        //    }

        //    return PartialView("_LogList", logs);

        //}

        // search by  keywords

        //public ActionResult GetLogResultSheetByKeywords(string keywords)
        //{
        //    var logs = from log in (db.Logs).OrderBy(log => log.Date) select log;

        //    if (!String.IsNullOrEmpty(keywords))
        //    {
        //        //int id = int.Parse(filterBy);
        //        logs = logs.Where(p => p.Description.Contains(keywords));
        //    }

        //    return PartialView("_LogList", logs);

        //}

        // filter by developername

        //GetLogResultSheetByDeveloper
        //public ActionResult GetLogResultSheetByDeveloper(string developerid)
        //{
        //    var logs = from log in (db.Logs).OrderBy(log => log.Date) select log;

        //    if (!String.IsNullOrEmpty(developerid))
        //    {
        //        int id = int.Parse(developerid);
        //        logs = logs.Where(p => p.DeveloperId.Equals(id));
        //    }

        //    return PartialView("_LogList", logs);

        //}

        // get loghistory by this/previous week or month
        //public ActionResult GetLogResultSheetByDate(string option)
        //{
        //    string dateOn = option;
        //    DateTime? from, till;
        //    Utilities.getDateRange(dateOn,out from,out till,null,null);


        //    // var logs = db.Report_ResultSheetByOption(from,till);

        //   // var logs = dal.GetLogResultSheetByOption(from,till);


        // //  return PartialView("_LogList", logs);

        //}
    
        public ActionResult GetLogResultSheetByFilter(int? developerid, int? projectid,string keywords,string option,DateTime? fromdate,DateTime? todate)

        {
            string datedOn = option;
            DateTime? from, till;
            Utilities.getDateRange(datedOn, out from, out till, null, null);

            List<LogFiltered> logs;

            if (option == "Between")
            {
                 logs = dal.GetLogResultSheetByFilter(developerid, projectid, keywords, fromdate, todate);
            }
            else
            {
                fromdate = from;
                todate = till;
                 logs = dal.GetLogResultSheetByFilter(developerid, projectid, keywords, fromdate, todate);
            }
           

            return PartialView("_LogList", logs);

        }


        // GET: Admin/Logs/Details/5



        public ActionResult Details(int? id)
        {
            ViewBag.Projects = dal.GetProjectsResultSheet();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Log log = db.Logs.Find(id);
            if (log == null)
            {
                return HttpNotFound();
            }
            return View(log);
        }

        // GET: Admin/Logs/Create
        public ActionResult Create()
        {
            ViewBag.Projects = dal.GetProjectsResultSheet();
            ViewBag.Users = dal.GetAspNetUsersResultSheet();

            return View();
        }

        // POST: Admin/Logs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,ProjectId,WorkStartTime,WorkEndTime,Duration,Date,DeveloperId")] Log log)
        {
            ViewBag.Projects = dal.GetProjectsResultSheet();
            ViewBag.Users = dal.GetAspNetUsersResultSheet();

            if (ModelState.IsValid)
            {
                db.Logs.Add(log);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

          

            return View(log);
        }

        // GET: Admin/Logs/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.Projects = dal.GetProjectsResultSheet();
            ViewBag.Users = dal.GetAspNetUsersResultSheet();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Log log = db.Logs.Find(id);
            if (log == null)
            {
                return HttpNotFound();
            }
            return View(log);
        }

        // POST: Admin/Logs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,ProjectId,WorkStartTime,WorkEndTime,Duration,Date,DeveloperId")] Log log)
        {
            ViewBag.Projects = dal.GetProjectsResultSheet();
            ViewBag.Users = dal.GetAspNetUsersResultSheet();

            if (ModelState.IsValid)
            {
                db.Entry(log).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return View(log);
        }

        // GET: Admin/Logs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Log log = db.Logs.Find(id);
            if (log == null)
            {
                return HttpNotFound();
            }
            return View(log);
        }

        // POST: Admin/Logs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Log log = db.Logs.Find(id);
            db.Logs.Remove(log);
            db.SaveChanges();
            return RedirectToAction("Index");
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
