using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using Newtonsoft.Json.Linq;
using ProjectManagerApp.Models;
using ProjectManagerApp.Models.DAL;
using ProjectManagerApp.Models.DAL.Input;


namespace ProjectManagerApp.API
{
    public class LogController : ApiController
    {
        ProjectDal dal=new ProjectDal();
        //[HttpGet]
        //public string Get()
        //{
        //    return "asasa";
        //}

            private ProjectManagerAppEntities db =new ProjectManagerAppEntities();

            [HttpPost]
        public object ReportSave(JObject jObject)
        {
            JToken cObjToken = jObject;
            string logxml = cObjToken.SelectToken("logXML").ToString();

            new ProjectDal().SaveReport(logxml);

            return null;

        }


        [HttpGet]

        public JsonResult<List<Report>> GetLogsHistory(int id,int projectid,string fromdate,string todate)
        {
            //int DeveloperId = 1;//(developerid.HasValue) ? developerid.Value : User.Identity.GetUserId<int>();

            var reports = dal.GetLogsHistory(id,projectid,fromdate,todate);
            return Json(reports);

        }

        [HttpGet]
        public void GetSeletedLogsDelete(int id)
        {
            //Log remove = db.Logs.Find(id);
            //db.Logs.Remove(remove);
            //db.SaveChanges();

            dal.GetSelectedLogDeleted(id);
        }

        [HttpGet]
        [Route("API/Log/GetAllProjectName")]
        public JsonResult<List<Project>> GetAllProjectName()
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
    }
}
