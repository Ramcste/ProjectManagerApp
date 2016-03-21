using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json.Linq;
using ProjectManagerApp.Models;
using ProjectManagerApp.Models.DAL;
using ProjectManagerApp.Models.DAL.Input;
using ProjectManagerApp.Models.DAL.Output;
using ProjectManagerApp.Areas.Admin.Models;
using System.Net;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using ProjectManagerApp.API;

namespace ProjectManagerApp.Controllers
{
    //Roles ="Developer,Admin,SuperAdmin"
    [Authorize()]
    public class HomeController : Controller
    {
        private ProjectManagerAppContext db = new ProjectManagerAppContext();
        private ApplicationUserManager _userManager;


        private ProjectManagerAppEntities dbEntities = new ProjectManagerAppEntities();

        private ProjectDal dal = new ProjectDal();

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
            int developerid = User.Identity.GetUserId<int>();

            ViewBag.Projects = dal.GetProjectsDeveloperResultSheet(developerid);

            var logs = dal.GetTodyasLogResultShet(developerid);
            return View(logs);
        }


        public ActionResult Logshistory()
        {
            int developerid = User.Identity.GetUserId<int>();

            ViewBag.Projects = dal.GetProjectsDeveloperResultSheet(developerid);

            // var logs = new ProjectDal().GetDeveloperLogResulSheet(developerid, 0, null, null);

            List<LogListByDate> logs = new LogController().SearchLog(developerid, 0, null, null);

            return View(logs);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult WelcomePage()
        {
            ViewBag.Message = "Welcome to the developer log page";

            return View();
        }


        public ActionResult GetDeveloperLogResultSheetByFilter(int? projectId, DateTime? fromdate, DateTime? todate)
        {
            // List<LogFiltered> logs = new List<LogFiltered>();
            int developerId = User.Identity.GetUserId<int>();


            //var logs = dal.GetDeveloperLogResulSheet(developerId, projectId, fromdate, todate);

            List<LogListByDate> logs = new LogController().SearchLog(developerId, projectId, fromdate, todate);

            return PartialView("_DeveloperLogList", logs);
        }


        [HttpGet]
        public ActionResult GetTodaysLog()
        {
            int developerid = User.Identity.GetUserId<int>();
            List<LogFiltered> logs = dal.GetTodyasLogResultShet(developerid);
            return PartialView("_TodaysDeveloperLog", logs);
        }

        public async Task<ActionResult> UsersEdit()
        {
            int id = User.Identity.GetUserId<int>();

            ApplicationUser user = await UserManager.FindByIdAsync(id);

            RegisterViewModel editUser = await generateRegisterViewModelFromAspNetUser(user, id);

            //var users = dbEntities.AspNetUsers.Find(id);

            return View(editUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> UsersEdit(RegisterViewModel model)
        {
            int id = User.Identity.GetUserId<int>();
            model.Id = id;
            ApplicationUser user = await UserManager.FindByIdAsync(model.Id);

            user.Address = model.Address;
            user.PhoneNumber = model.PhoneNumber1;
            user.PhoneNumber2 = model.PhoneNumber2;
            //user.IsActive = model.IsActive;
            //user.IsDeleted = model.IsDeleted;

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

               
            }
            return RedirectToAction("Index", "Home");
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

    }
}