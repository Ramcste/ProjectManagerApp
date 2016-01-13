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
using ProjectManagerApp.Models.DAL;

namespace ProjectManagerApp.Areas.Admin.Controllers
{
    public class AspNetUsersController : Controller
    {
        private ProjectManagerAppEntities db = new ProjectManagerAppEntities();

        private DALUser daluser = new DALUser();

        private ProjectDal dal = new ProjectDal();
        // GET: Admin/AspNetUsers
        public ActionResult Index()
        {
            ViewBag.Users = dal.GetAspNetUsersResultSheet();
            return View(db.AspNetUsers.ToList());
        }

        // GET: Admin/AspNetUsers/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.UserRoles = daluser.GetRoles(id);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser aspNetUser = db.AspNetUsers.Find(id);
            if (aspNetUser == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUser);
        }

        // GET: Admin/AspNetUsers/Create
        public ActionResult Create()
        {
            ViewBag.UserRoles = daluser.GetRoles(0);
            return View();
        }

        // POST: Admin/AspNetUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,PhoneNumber,UserName,Address,PhoneNumber2,IsActive,IsDeleted")] AspNetUser aspNetUser)
        {
            string userRoleCSV = Request.Form["chkUserRole"];
            if (ModelState.IsValid)
            {
                db.AspNetUsers.Add(aspNetUser);
                db.SaveChanges();
                dal.GetAllAspNetUserRolesUpdate(aspNetUser.Id, userRoleCSV);
                return RedirectToAction("Index");
            }

            return View(aspNetUser);
        }

        // GET: Admin/AspNetUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.UserRoles = daluser.GetRoles(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser aspNetUser = db.AspNetUsers.Find(id);
            if (aspNetUser == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUser);
        }

        // POST: Admin/AspNetUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,PhoneNumber,UserName,Address,PhoneNumber2,IsActive,IsDeleted")] AspNetUser aspNetUser)
        {
            string userRoleCSV = Request.Form["chkUserRole"];
            if (ModelState.IsValid)
            {
                db.Entry(aspNetUser).State = EntityState.Modified;
                db.SaveChanges();
                dal.GetAllAspNetUserRolesUpdate(aspNetUser.Id, userRoleCSV);
                return RedirectToAction("Index");
            }
            return View(aspNetUser);
        }

        // GET: Admin/AspNetUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.UserRoles = daluser.GetRoles(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser aspNetUser = db.AspNetUsers.Find(id);
            if (aspNetUser == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUser);
        }

        // POST: Admin/AspNetUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AspNetUser aspNetUser = db.AspNetUsers.Find(id);
            db.AspNetUsers.Remove(aspNetUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }




        // for filtering aspnet user
        public ActionResult GetAspNetUsersResultSheetByFilter(int? developerid, string email, string isActive,string isDeleted)

        {

            var users = dal.GetAspNetUsersResultSheetByFilter(developerid,email,isActive,isDeleted);
            return PartialView("_AspNetUsersList",users);

        }

        // for autosuggestion email

    
            [HttpPost]
            [Route("AspNetUsers/GetAllEmailForAutoSuggestion")]
        public JsonResult GetAllEmailForAutoSuggestion(string keywords)
        {          
            
            var suggestions = from e in db.AspNetUsers select e.Email;

            var email = suggestions.Where(e => e.ToLower().StartsWith(keywords.ToLower()));

            return Json(email,JsonRequestBehavior.AllowGet);
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
