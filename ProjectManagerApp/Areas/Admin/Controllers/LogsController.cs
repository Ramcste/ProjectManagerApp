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
using Microsoft.AspNet.Identity;

namespace ProjectManagerApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class LogsController : Controller
    {
        private ProjectManagerAppEntities db = new ProjectManagerAppEntities();

        private ProjectDal dal = new ProjectDal();
        // GET: Admin/Logs
        //  sort by date
        public ActionResult Index()
        {
            ViewBag.Users = dal.GetAspNetUsersResultSheet();
            ViewBag.Projects = dal.GetProjectsResultSheet();

            List<LogFiltered> logs = new List<LogFiltered>();

          // var logs = dal.GetLogResultSheetByFilter(0,0,"",null,null).ToList<LogFiltered>();
           
            ViewBag.Messsage = "Please select developer name or project name to view the log result sheet";

          

            return View(logs);
        }

   
    // for filtering logs
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
                    
            ViewBag.Users = dal.GetAspNetUsersResultSheet();
            int developerid = log.DeveloperId;
            string starttime = (DateTime.Parse(log.WorkStartTime).AddMinutes(1)).ToString("t");
            string endtime = (DateTime.Parse(log.WorkEndTime).AddMinutes(-1)).ToString("t");
            string date = log.Date.ToString("yyyy/M/d");
            List<LogFiltered> logs = dal.GetLogTimeCheckToday(developerid,starttime,endtime,date);

            if (logs.Count > 0)
            {
               
                ViewBag.Message = "There is log already for this timeline so enter correct timeline";
                
            }
            else
            {
                db.Logs.Add(log);
                db.SaveChanges();
                return RedirectToAction("Index");
                
            }
          

            return View();
        }

        // GET: Admin/Logs/Edit/5
        public ActionResult Edit(int? id)
        {
            Log log = new Log();
             
            ViewBag.Users = dal.GetAspNetUsersResultSheet();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
             log = db.Logs.Find(id);
            if (log == null)
            {
                return HttpNotFound();
            }

            ViewBag.Projects = dal.GetProjectsDeveloperResultSheet(log.DeveloperId);

            return View(log);
        }

        // POST: Admin/Logs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,ProjectId,WorkStartTime,WorkEndTime,Duration,Date,DeveloperId")] Log log)
        {
            ViewBag.Projects = dal.GetProjectsDeveloperResultSheet(log.DeveloperId);
            ViewBag.Users = dal.GetAspNetUsersResultSheet();


            int developerid = log.DeveloperId;
            string starttime = (DateTime.Parse(log.WorkStartTime).AddMinutes(1)).ToString("t");
            string endtime = (DateTime.Parse(log.WorkEndTime).AddMinutes(-1)).ToString("t");
            string date = log.Date.ToString("yyyy/M/d");
            var logs = dal.GetLogTimeCheckToday(developerid,starttime,endtime,date);

            if (logs.Count > 1)
            {
                ViewBag.Message = "There is log already for this timeline so enter correct timeline";
            }
            else
            {
                log.DeveloperId = log.DeveloperId;

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
