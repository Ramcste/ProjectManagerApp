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


namespace ProjectManagerApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ProjectManagerAppContext db=new ProjectManagerAppContext();

        private ProjectDal dal = new ProjectDal();
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

            var logs = new ProjectDal().GetDeveloperLogResulSheet(developerid, 0, null, null);

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


        public ActionResult GetDeveloperLogResultSheetByFilter(int ?projectId, DateTime? fromdate, DateTime? todate)
        {
           // List<LogFiltered> logs = new List<LogFiltered>();
            int developerId = User.Identity.GetUserId<int>();
          

           var logs = dal.GetDeveloperLogResulSheet(developerId,projectId,fromdate,todate);

            return PartialView("_DeveloperLogList",logs);
        }


        public ActionResult GetTodaysLog()
        {
            int developerid= User.Identity.GetUserId<int>();
            var logs = dal.GetTodyasLogResultShet(developerid);
            return PartialView("_TodaysDeveloperLog",logs);
        }
    }
}