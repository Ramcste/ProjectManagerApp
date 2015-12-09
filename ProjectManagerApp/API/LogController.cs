using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json.Linq;
using ProjectManagerApp.Models.DAL;
using ProjectManagerApp.Models.DAL.Input;

namespace ProjectManagerApp.API
{
    public class LogController : ApiController
    {
        //[HttpGet]
        //public string Get()
        //{
        //    return "asasa";
        //}

            [System.Web.Http.HttpPost]
        public object ReportSave(JObject jObject)
        {
            JToken cObjToken = jObject;
            string logxml = cObjToken.SelectToken("logXML").ToString();

            new ProjectDAL().SaveReport(logxml);

            return null;

        }


        [System.Web.Http.HttpGet]
       
        public JsonResult GetLogsHistory()
                {
            //  int DeveloperId = 1;//(developerid.HasValue) ? developerid.Value : User.Identity.GetUserId<int>();
            int id = User.Identity.GetUserId<int>();
            List<Report> reports = new List<Report>();

            reports = new ProjectDAL().GetLogsHistory(id);

            return new JsonResult { Data = reports, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }
    }
}
