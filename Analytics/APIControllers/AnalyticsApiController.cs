using Analytics.Helpers.BO;
using Analytics.Helpers.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Infrastructure;
//using System.Data.Objects;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using System.Web.Mvc;
using Analytics.Models;

namespace Analytics.Controllers
{
    [EnableCors(origins: "http://localhost:3300", headers: "*", methods: "*")]
    public class AnalyticsApiController : ApiController
    {
        shortenURLEntities dc = new shortenURLEntities();

        //// GET: Analytics
        //public ActionResult Index()
        //{
        //    return View();
        //}
        //public ActionResult Analytics()
        //{
        //    return View();
        //}
        [System.Web.Http.HttpGet]
        public JsonResult<CountsData> GETALLCOUNTS(string Uniqueid, string DateFrom, string DateTo)
        {
            int Uniqueid_SHORTURLDATA = 0;
            SqlConnection lSQLConn = null;
            SqlCommand lSQLCmd = new SqlCommand();
            CountsData countobj = new CountsData();

            try
            {
                if (Uniqueid != "" && Uniqueid != null)
                {
                    long decodedvalue = new ConvertionBO().BaseToLong(Uniqueid);
                    Uniqueid_SHORTURLDATA = Convert.ToInt32(decodedvalue);
                    int? rid = (from u in dc.UIDandRIDDatas
                                where u.PK_UniqueId == Uniqueid_SHORTURLDATA && u.TypeDiff=="2"
                                select u.UIDorRID).SingleOrDefault();
                    string connStr = ConfigurationManager.ConnectionStrings["shortenURLConnectionString"].ConnectionString;

                    // create and open a connection object
                    lSQLConn = new SqlConnection(connStr);
                    SqlDataReader myReader;
                    lSQLConn.Open();
                    lSQLCmd.CommandType = CommandType.StoredProcedure;
                    lSQLCmd.CommandText = "spGetALLCOUNTS1";
                    //lSQLCmd.Parameters.Add(new SqlParameter("@Fk_Uniqueid", Uniqueid_SHORTURLDATA));
                    lSQLCmd.Parameters.Add(new SqlParameter("@rid", rid));
                    lSQLCmd.Parameters.Add(new SqlParameter("@DateFrom", DateFrom));
                    lSQLCmd.Parameters.Add(new SqlParameter("@DateTo", DateTo));
                    lSQLCmd.Connection = lSQLConn;
                    myReader = lSQLCmd.ExecuteReader();


                    List<DayWiseData> activity = ((IObjectContextAdapter)dc)
                      .ObjectContext
                      .Translate<DayWiseData>(myReader, "SHORTURLDATAs", MergeOption.AppendOnly).ToList();


                    // Move to locations result 
                    myReader.NextResult();
                    List<CountryWiseData> locations = ((IObjectContextAdapter)dc)
                   .ObjectContext
                   .Translate<CountryWiseData>(myReader, "SHORTURLDATAs", MergeOption.AppendOnly).ToList();

                    // Move to devices result 
                    myReader.NextResult();
                    List<DeviceWiseData> devices = ((IObjectContextAdapter)dc)
                  .ObjectContext
                  .Translate<DeviceWiseData>(myReader, "SHORTURLDATAs", MergeOption.AppendOnly).ToList();

                    // Move to platforms result 
                    myReader.NextResult();
                    List<BrowserWiseData> platforms = ((IObjectContextAdapter)dc)
                  .ObjectContext
                  .Translate<BrowserWiseData>(myReader, "SHORTURLDATAs", MergeOption.AppendOnly).ToList();


                    countobj.activity = activity;
                    countobj.locations = locations;
                    countobj.devices = devices;
                    countobj.platforms = platforms;

                    return Json(countobj);

                    //var s = new JavaScriptSerializer();
                    //string jsonClient = s.Serialize(countobj);

                    //WebOperationContext.Current.OutgoingResponse.ContentType =
                    //    "application/json; charset=utf-8";
                    //return new MemoryStream(Encoding.UTF8.GetBytes(jsonClient));
                }
                else
                {
                    string jsonClient = "please pass reference number";

                    return Json(countobj);
                    //WebOperationContext.Current.OutgoingResponse.ContentType =
                    //    "application/json; charset=utf-8";
                    //return new MemoryStream(Encoding.UTF8.GetBytes(jsonClient));
                }
            }
            catch (Exception ex)
            {
                ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                //string jsonClient = "Exception occurs";
                return Json(countobj);

                //WebOperationContext.Current.OutgoingResponse.ContentType =
                //    "application/json; charset=utf-8";
                //return new MemoryStream(Encoding.UTF8.GetBytes(jsonClient));
            }
        }

        public JsonResult<Summary> GETSUMMARY(string Uniqueid)
        {
            Summary s_obj = new Summary();

            try
            {
                if (Uniqueid != "" && Uniqueid != null)
                {
                    int Uniqueid_SHORTURLDATA = 0;
                    long decodedvalue = new ConvertionBO().BaseToLong(Uniqueid);
                    Uniqueid_SHORTURLDATA = Convert.ToInt32(decodedvalue);
                    //Uniqueid_SHORTURLDATA = Convert.ToInt32(Fk_Uniqueid);
                    int? rid = (from u in dc.UIDandRIDDatas
                                where u.PK_UniqueId == Uniqueid_SHORTURLDATA && u.TypeDiff == "2"
                                select u.UIDorRID).SingleOrDefault();
                    var surl = (from ss in dc.SHORTURLDATAs
                                where ss.FK_RID == rid
                                select new { ss.Req_url }).ToList().Take(1);
                    int totalVisits = dc.SHORTURLDATAs.Where(sh => sh.FK_RID == rid).Count();
                    //int totalUsers = dc.SHORTURLDATAs.Where(sh => sh.FK_RID == rid).Count();
                    int totalUsers = dc.UIDDATAs.Where(sh => sh.FK_RID == rid).Count();
                    int? totalUniqueUsers = (from sh in dc.SHORTURLDATAs
                                             where sh.FK_RID == rid
                                             select sh.FK_Uid).Distinct().Count();
                    s_obj.url = surl.Select(x => x.Req_url).SingleOrDefault();
                    s_obj.visits = totalVisits;
                    s_obj.total_users = totalUsers;
                    s_obj.unique_users = totalUniqueUsers;
                    return Json(s_obj);
                    //var s = new JavaScriptSerializer();
                    //string jsonClient = s.Serialize(s_obj);

                    //WebOperationContext.Current.OutgoingResponse.ContentType =
                    //    "application/json; charset=utf-8";
                    //return new MemoryStream(Encoding.UTF8.GetBytes(jsonClient));
                }
                else
                    return Json(s_obj);

            }
            catch (Exception ex)
            {
                ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                return Json(s_obj);

                //string jsonClient = "Exception occurs";

                //WebOperationContext.Current.OutgoingResponse.ContentType =
                //    "application/json; charset=utf-8";
                //return new MemoryStream(Encoding.UTF8.GetBytes(jsonClient));
            }
        }
    }
}