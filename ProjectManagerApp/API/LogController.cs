using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using Newtonsoft.Json.Linq;
using ProjectManagerApp.Areas.Admin.Models;
using ProjectManagerApp.Models.DAL;
using ProjectManagerApp.Models.DAL.Input;
using ProjectManagerApp.Models.DAL.Output;
using ProjectManagerApp.Helpers;
using System.Linq;

namespace ProjectManagerApp.API
{
    public class LogController : ApiController
    {
        ProjectDal dal = new ProjectDal();

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
        public JsonResult<List<Report>> GetLogHistoryAscProjectId(int developerid, int? projectid)
        {
            var reports = dal.GetLogsHistoryByProjectId(developerid, projectid);
            return Json(reports);
        }


        [HttpGet]
        [Route("API/Log/GetLogsHistory")]
        public JsonResult<List<Report>> GetLogsHistory(int id, int? projectid, DateTime? fromdate, DateTime? todate)
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
        public JsonResult<List<Projects>> GetAllProjectName(int developerid)
        {
            var projects = dal.GetProjectsDeveloperResultSheet(developerid);

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


        [HttpGet]
        [Route("API/Log/GetProjectsListByDeveloperId")]

        public JsonResult<List<Projects>> GetProjectsListByDeveloperId(int developerid)
        {
            var projects = dal.GetProjectsDeveloperResultSheet(developerid);

            return Json(projects);
        }




        // checking logtimecheck before saving it

        [HttpGet]
        [Route("API/Log/GetTodayLogTimeCheck")]
        public JsonResult<List<LogFiltered>> GetTodayLogTimeCheck(int developerid, string starttime, string endtime,string date)
        {
            
            string starttime1 = (DateTime.Parse(starttime).AddMinutes(1)).ToString("t");
            string endtime1 = (DateTime.Parse(endtime).AddMinutes(-1)).ToString("t");
        

            var logs = dal.GetLogTimeCheckToday(developerid,starttime1,endtime1,date);

                return Json(logs);
            }




        // for displaying history in group according to date

        [HttpGet]
        public List<LogListByDate> SearchLog(int developerid,int ? projectid,DateTime? fromdate,DateTime? todate)
        {
             List<LogFiltered> Logs = dal.GetDeveloperLogResulSheet(developerid,projectid,fromdate,todate);
            List<LogFiltered> logs = new List<LogFiltered>();

            List<LogListByDate> log = (from item in Logs
                            group item by new { item.Date} into g
                            select new LogListByDate
                            {
                                Date = g.Key.Date,
                                LogFilteredList = (from p in Logs
                                         where p.Date == g.Key.Date
                                         select new LogFiltered
                                         {
                                             Description = p.Description,
                                             Id = p.Id,
                                             ProjectId = p.ProjectId,
                                             Name=p.Name,
                                             WorkStartTime = p.WorkStartTime,
                                             WorkEndTime = p.WorkEndTime,
                                             Duration = p.Duration,
                                             Date=p.Date,

                                         }).ToList<LogFiltered>()

                            }).ToList<LogListByDate>();

            return log;
        }

    }
    }