using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using ProjectManagerApp.Models.DAL;

namespace ProjectManagerApp.API
{
    public class LogController : ApiController
    {
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

            new ProjectDAL().SaveReport(logxml);

            return null;

        }

    }
}
