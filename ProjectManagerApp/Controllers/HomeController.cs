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
    public class HomeController : Controller
    {
        private ProjectManagerAppContext db=new ProjectManagerAppContext();
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.Projects = new ProjectDal().GetProjectsResultSheet();
           
            var  model=  new Projects();

            return View(model);
        }

        [Authorize]
        public ActionResult Logshistory()
        {
            ViewBag.Projects = new ProjectDal().GetProjectsResultSheet();

            var model = new Projects();

            return View(model);
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
    }
}