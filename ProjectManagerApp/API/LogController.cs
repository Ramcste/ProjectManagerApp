using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using Newtonsoft.Json.Linq;
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

            [HttpPost]
        public object ReportSave(JObject jObject)
        {
            JToken cObjToken = jObject;
            string logxml = cObjToken.SelectToken("logXML").ToString();

            new ProjectDal().SaveReport(logxml);

            return null;

        }


        [HttpGet]

        public JsonResult<List<Report>> GetLogsHistory(int id)
        {
            //int DeveloperId = 1;//(developerid.HasValue) ? developerid.Value : User.Identity.GetUserId<int>();

            var reports = dal.GetLogsHistory(id);
            return Json(reports);

        }


        [HttpGet]
        public JsonResult<List<Report>> GetLogsHistoryAcDate(string date)
        {
           // date = "8/10";
            var records = dal.GetLogHistoryAcDate(date);
            return Json(records);
        }


    }
}
