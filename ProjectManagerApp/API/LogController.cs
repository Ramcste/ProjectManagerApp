using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using Newtonsoft.Json.Linq;
using ProjectManagerApp.Areas.Admin.Models;
using ProjectManagerApp.Models;
using ProjectManagerApp.Models.DAL;
using ProjectManagerApp.Models.DAL.Input;
using Projects = ProjectManagerApp.Models.DAL.Output.Projects;


namespace ProjectManagerApp.API
{
    public class LogController : ApiController
    {
        ProjectDal dal = new ProjectDal();
        //[HttpGet]
        //public string Get()
        //{
        //    return "asasa";
        //}

        private ProjectManagerAppEntities db = new ProjectManagerAppEntities();


        [HttpPost]
        public object ReportSave(JObject jObject)
        {
            JToken cObjToken = jObject;
            string logxml = cObjToken.SelectToken("logXML").ToString();

            new ProjectDal().SaveReport(logxml);

            return null;

        }


        [HttpGet]
        [Route("API/Log/GetLogHistoryAscProjectId")]
        public JsonResult<List<Report>> GetLogHistoryAscProjectId(int developerid)
        {
            var reports = dal.GetLogsHistoryByProjectId(developerid);
            return Json(reports);
        }


        [HttpGet]
        [Route("API/Log/GetLogsHistory")]
        public JsonResult<List<Report>> GetLogsHistory(int id, int projectid, DateTime fromdate, DateTime todate)
        {
            //int DeveloperId = 1;//(developerid.HasValue) ? developerid.Value : User.Identity.GetUserId<int>();

            var reports = dal.GetLogsHistory(id, projectid, fromdate, todate);
            return Json(reports);

        }

        [HttpGet]
        [Route("API/Log/GetSeletedLogsDelete")]
        public void GetSeletedLogsDelete(int id)
        {
            //Log remove = db.Logs.Find(id);
            //db.Logs.Remove(remove);
            //db.SaveChanges();

            dal.GetSelectedLogDeleted(id);
        }


        [HttpGet]
        [Route("API/Log/GetAllProjectName")]
        public JsonResult<List<Projects>> GetAllProjectName()
        {
            var projects = dal.GetProjectsResultSheet();

            return Json(projects);
        }


        [HttpPost]
        [Route("API/Log/GetLogsUpdate")]
        public object GetLogUpdate(JObject jObject)
        {
            JToken cObjToken = jObject;
            //  string desc = jObject.GetValue("des").ToString();
            string logxml = cObjToken.SelectToken("editlogXML").ToString();

            new ProjectDal().GetEditLogsUpdate(logxml);

            return null;

        }


        [HttpGet]
        [Route("API/Log/GetBulkLogDelete")]
        public void GetBulkLogDelete(string logids, int developerid)
        {
            dal.GetBulkLogsDelete(logids, developerid);
        }

        [HttpGet]
        [Route("API/Log/GetLogsResultByDate")]

        public JsonResult<List<Report>> GetLogsResultByDate(int developerid)
        {
            var report = dal.GetProjectResultSheetByDate(developerid);

            return Json(report);
        }
    }


        // for admin area

        //  for filtering

       
}
