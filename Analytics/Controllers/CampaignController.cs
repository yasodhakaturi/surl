using Analytics.Helpers.BO;
using Analytics.Helpers.Utility;
using Analytics.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Analytics.Controllers
{
    public class CampaignController : Controller
    {
        shortenURLEntities dc = new shortenURLEntities();
        // GET: Campaign
        public JsonResult Index(string id)
        {
            //    return View();
            //}
            //public JsonResult GetclientDetails()
            //{
            List<CampaignView> objc = new List<CampaignView>();
            CampaignView obj = new CampaignView();
            int id1 = Convert.ToInt32(id);
            try
            {
                if (id == null)
                {
                    //get all client detials
                    objc = (from r in dc.RIDDATAs
                                                    select new CampaignView
                                                    {
                                                        id = r.PK_Rid,
                                                        ReferenceNumber = r.ReferenceNumber,
                                                        // pwd = r.Pwd,
                                                        isactive = r.IsActive
                                                    }).ToList();
                    return Json(objc, JsonRequestBehavior.AllowGet);

                }
                else if (id != null)
                {
                    obj = (from r in dc.RIDDATAs
                            where r.PK_Rid == id1
                            select new CampaignView
                            {
                                id = r.PK_Rid,
                                ReferenceNumber = r.ReferenceNumber,
                                //pwd = r.Pwd,
                                isactive = r.IsActive
                            }).SingleOrDefault();
                    return Json(obj, JsonRequestBehavior.AllowGet);

                }


                return Json(objc, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                return Json(objc, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Search(string referencenumber, bool? isactive)
        {
            List<CampaignView> obj_search = new List<CampaignView>();
            string isactivestr = Convert.ToString(isactive);

            try
            {
                if (referencenumber != null && isactivestr == null)
            {
                obj_search = (from c in dc.RIDDATAs
                              where c.ReferenceNumber.Contains(referencenumber.ToString())
                              select new CampaignView()
                              {
                                  id = c.PK_Rid,
                                  ReferenceNumber = c.ReferenceNumber,
                                  //pwd = r.Pwd,
                                  isactive = c.IsActive
                              }).ToList();
            }

                else if (isactivestr != null && referencenumber == "")
            {
                obj_search = (from c in dc.RIDDATAs
                              where c.IsActive == isactive
                              select new CampaignView()
                              {
                                  id = c.PK_Rid,
                                  ReferenceNumber = c.ReferenceNumber,
                                  //pwd = r.Pwd,
                                  isactive = c.IsActive
                              }).ToList();
            }
            return Json(obj_search,JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                return Json(obj_search, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult AddCampaign([FromBody]JToken jObject)
        {
            RIDDATA obj = new RIDDATA();
            try
            { 
            //string fields = "id,ReferenceNumber,isactive";
            //string parameters = new StreamReader(parameter).ReadToEnd(); //email1;
            //JObject jObject = JObject.Parse(parameter);
            string ReferenceNumber = (string)jObject["ReferenceNumber"];
            string Pwd = (string)jObject["Pwd"];
            bool IsActive = (bool)jObject["IsActive"];
            int FK_ClientId = (int)jObject["ClientId"];
            bool isClientExists = new OperationsBO().CheckClientId(FK_ClientId);
            if (isClientExists == false)
            {
                //add campaign details
                obj.ReferenceNumber = ReferenceNumber;
                obj.Pwd = Pwd;
                obj.IsActive = IsActive;
                obj.CreatedDate = DateTime.UtcNow;
                obj.FK_ClientId = FK_ClientId;
                dc.RIDDATAs.Add(obj);
                dc.SaveChanges();
                new OperationsBO().InsertUIDRIDData(ReferenceNumber);
            }
            return Json(obj, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult UpdateCampaign([FromBody]JToken jObject)
        {
            RIDDATA obj = new RIDDATA();
            RIDDATA obj1 = new RIDDATA();
            try
            { 
            //string fields = "id,ReferenceNumber,isactive";
            //string parameters = new StreamReader(parameter).ReadToEnd(); //email1;
            //JObject jObject = JObject.Parse(parameter);
            int id = (int)jObject["id"];
            string ReferenceNumber = (string)jObject["ReferenceNumber"];
            //string Pwd = (string)jObject["Pwd"];
            bool IsActive = (bool)jObject["IsActive"];
            obj = dc.RIDDATAs.Where(r => r.PK_Rid == id).SingleOrDefault();
            bool isReferenceNumberExists = new OperationsBO().CheckReferenceNumber(ReferenceNumber);
            if (isReferenceNumberExists == true)
                new OperationsBO().UpdateCampaign(ReferenceNumber, "", IsActive);
            else
                obj = obj1;
            return Json(obj, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
        }

      public JsonResult DeleteCampaign([FromBody]JToken jObject)
        {
            RIDDATA obj = new RIDDATA();
            RIDDATA obj1 = new RIDDATA();
          try
          { 
            //string fields = "id,ReferenceNumber,isactive";
            //string parameters = new StreamReader(parameter).ReadToEnd(); //email1;
            //JObject jObject = JObject.Parse(parameter);
            int id = (int)jObject["id"];
            string ReferenceNumber = (string)jObject["ReferenceNumber"];
            //string Pwd = (string)jObject["Pwd"];
            bool IsActive = (bool)jObject["IsActive"];
            obj = dc.RIDDATAs.Where(r => r.PK_Rid == id).SingleOrDefault();
            bool isReferenceNumberExists = new OperationsBO().CheckReferenceNumber(ReferenceNumber);
            if (isReferenceNumberExists == true && obj.IsActive == true)
            {
                obj.IsActive = false;
                obj.UpdatedDate = DateTime.UtcNow;
                dc.SaveChanges();

            }
            else
            {
                obj = obj1;
            }
            return Json(obj, JsonRequestBehavior.AllowGet);
          }
          catch (Exception ex)
          {
              ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
              return Json(obj, JsonRequestBehavior.AllowGet);
          }
        }

    }
}