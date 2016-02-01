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
using ProjectManagerApp.Models;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace ProjectManagerApp.Areas.Admin.Controllers
{
   
    public class AspNetUsersController : Controller
    {
        private ApplicationUserManager _userManager;

        private ProjectManagerAppEntities db = new ProjectManagerAppEntities();

        private DALUser daluser = new DALUser();

        private ProjectDal dal = new ProjectDal();
        // GET: Admin/AspNetUsers

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public ActionResult Index()
        {
            ViewBag.Roles = daluser.GetRoles(0);
            ViewBag.Users = dal.GetAspNetUsersResultSheet();

        
    
            List<AspNetUser> users = new List<AspNetUser>();

           // users = dal.GetAspNetUsersResultSheetByFilter(0,"","","",0);

            return View(users);
        }

        // GET: Admin/AspNetUsers/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.UserRoles = daluser.GetRoles(id);
            ViewBag.ProjectsDeveloper = daluser.GetProjects(id);

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
            RegisterViewModel user = new RegisterViewModel();
            user.Email = "";
            user.Password = "";
            ViewBag.UserRoles = daluser.GetRoles(0);
            ViewBag.ProjectsDeveloper = daluser.GetProjects(0);
            return View(user);
        }

        // POST: Admin/AspNetUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<ActionResult> Create(RegisterViewModel model)
        {

            ViewBag.UserRoles = daluser.GetRoles(0);
            ViewBag.ProjectsDeveloper = daluser.GetProjects(0);

            model.Id = 0;
            
            if (ModelState.IsValid) {

                string projectsDeveloperCSV = Request.Form["chkProjectsDeveloper"];
                string userRoleCSV = Request.Form["chkUserRole"];

                var user = new ApplicationUser();
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.Address = model.Address;
                user.PhoneNumber = model.PhoneNumber1;
                user.PhoneNumber2 = model.PhoneNumber2;
                user.IsActive = true;
                user.IsDeleted = false;
                user.EmailConfirmed = true;
                user.LockoutEnabled = true;

                if (model.Password != null)
                {
                    ProjectManagerPasswordHasher ph = new ProjectManagerPasswordHasher();
                    user.PasswordHash = ph.HashPassword(model.Password);
                }

                IdentityResult result = await UserManager.CreateAsync(user, model.Password);
               
               
              
                if (result.Succeeded)
                {
                    dal.GetAllAspNetUserRolesUpdate(user.Id, userRoleCSV);
                    dal.GetProjectsDeveloperUpdate(user.Id, projectsDeveloperCSV);

                }
               return RedirectToAction("Index", "AspNetUsers");
                

            }

            
            return View ("Create", model);
        }
      

        // GET: Admin/AspNetUsers/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.UserRoles = daluser.GetRoles(id);
            ViewBag.ProjectsDeveloper = daluser.GetProjects(id);

            ApplicationUser user = await UserManager.FindByIdAsync(id);

            RegisterViewModel editUser = await generateRegisterViewModelFromAspNetUser(user, id);

           
            if (id == default(int))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (user == null)
            {
                return HttpNotFound();
            }
            return View(editUser);
        }

        // POST: Admin/AspNetUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Edit(RegisterViewModel model)
        {

            ApplicationUser user = await UserManager.FindByIdAsync(model.Id);
      
                user.Address = model.Address;
                user.PhoneNumber = model.PhoneNumber1;
                user.PhoneNumber2 = model.PhoneNumber2;
                user.IsActive = model.IsActive;
                user.IsDeleted = model.IsDeleted;

                string projectsDeveloperCSV = Request.Form["chkProjectsDeveloper"];
                string userRoleCSV = Request.Form["chkUserRole"];



                if (model.Password != null)
                {
                    ProjectManagerPasswordHasher ph = new ProjectManagerPasswordHasher();
                    user.PasswordHash = ph.HashPassword(model.Password);
                }

                IdentityResult result = await UserManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                if (model.Password != null)
                {
                    IdentityResult securityToken = await UserManager.UpdateSecurityStampAsync(model.Id);
                }

                dal.GetAllAspNetUserRolesUpdate(user.Id, userRoleCSV);
                    dal.GetProjectsDeveloperUpdate(user.Id, projectsDeveloperCSV);
                }
                return RedirectToAction("Index", "AspNetUsers");

            }
            
        // GET: Admin/AspNetUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.UserRoles = daluser.GetRoles(id);
            ViewBag.ProjectsDeveloper = daluser.GetProjects(id);
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

                aspNetUser.IsDeleted = true;
				  aspNetUser.IsActive = false;
				
                db.SaveChanges();
            
           
            return RedirectToAction("Index");
        }




        // for filtering aspnet user
        public ActionResult GetAspNetUsersResultSheetByFilter(int? developerid, string email, string status, string isDeleted,int ?roleid)

        {

            var users = dal.GetAspNetUsersResultSheetByFilter(developerid,email, status, isDeleted,roleid);
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


        protected async Task<RegisterViewModel> generateRegisterViewModelFromAspNetUser(ApplicationUser user, int id)
        {
            if (user == null) user = await UserManager.FindByIdAsync(id);

            RegisterViewModel u = new RegisterViewModel();
            u.Id = user.Id;
            u.UserName = user.UserName;
            u.Email = user.Email;
            u.Address = user.Address;
            u.Password = user.PasswordHash;
            u.ConfirmPassword = user.PasswordHash;
            u.PhoneNumber1 = user.PhoneNumber;
            u.PhoneNumber2 = user.PhoneNumber2;        
            u.IsDeleted = user.IsDeleted;
            u.IsActive = user.IsActive;
            
            return u;
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
