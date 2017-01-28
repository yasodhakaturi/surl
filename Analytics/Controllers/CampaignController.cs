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
            List<CampaignView1> objc = new List<CampaignView1>();
            CampaignView1 obj = new CampaignView1();
            int id1 = Convert.ToInt32(id);
            try
            {
                if (id == null && Session["id"] != "")
                {
                    //get all client detials
                    objc = (from r in dc.RIDDATAs
                                                    select new CampaignView1
                                                    {
                                                        id = r.PK_Rid,
                                                        ReferenceNumber = r.ReferenceNumber,
                                                        // pwd = r.Pwd,
                                                        isactive = r.IsActive
                                                    }).ToList();
                    return Json(objc, JsonRequestBehavior.AllowGet);

                }
                else if (id != null && Session["id"] != "")
                {
                    obj = (from r in dc.RIDDATAs
                            where r.PK_Rid == id1
                            select new CampaignView1
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
            List<CampaignView1> obj_search = new List<CampaignView1>();
            string isactivestr = Convert.ToString(isactive);

            try
            {
                if (referencenumber != null && isactivestr == null && Session["id"]!="")
            {
                obj_search = (from c in dc.RIDDATAs
                              where c.ReferenceNumber.Contains(referencenumber.ToString())
                              select new CampaignView1()
                              {
                                  id = c.PK_Rid,
                                  ReferenceNumber = c.ReferenceNumber,
                                  //pwd = r.Pwd,
                                  isactive = c.IsActive
                              }).ToList();
            }

                else if (isactivestr != null && referencenumber == "" && Session["id"] != "")
            {
                obj_search = (from c in dc.RIDDATAs
                              where c.IsActive == isactive
                              select new CampaignView1()
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

        //public JsonResult AddCampaign([FromBody]JToken jObject)
        [System.Web.Mvc.HttpPost]
        public JsonResult AddCampaign(string CampaignName, string Pwd, bool IsActive)    
    {
            RIDDATA obj = new RIDDATA();
            try
            {
                Random randNum = new Random();
                int r = randNum.Next(00000, 99999);
                string ReferenceNumber = r.ToString("D5");
            //string fields = "id,ReferenceNumber,isactive";
            
            //string ReferenceNumber = (string)jObject["ReferenceNumber"];
            //string Pwd = (string)jObject["Pwd"];
            //bool IsActive = (bool)jObject["IsActive"];
             //int id = (int)Session["id"];
             //int id = 1;
            // RIDDATA objc = dc.RIDDATAs.Where(x => x.ReferenceNumber== ReferenceNumber).SingleOrDefault();
            //int FK_ClientId = (int)jObject["ClientId"];
            //bool isClientExists = new OperationsBO().CheckClientId(FK_ClientId);
             if (Session["id"]!=null)
            {
                //add campaign details
                obj.CampaignName = CampaignName;
                obj.ReferenceNumber = ReferenceNumber;
                obj.Pwd = Pwd;
                obj.IsActive = IsActive;
                obj.CreatedDate = DateTime.UtcNow;
                obj.FK_ClientId = (int)Session["id"];
                dc.RIDDATAs.Add(obj);
                dc.SaveChanges();
               // new OperationsBO().InsertUIDRIDData(ReferenceNumber);
            }
            return Json(obj, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
        }

        //public JsonResult UpdateCampaign([FromBody]JToken jObject)
        //[System.Web.Mvc.HttpPost]
        public JsonResult UpdateCampaign(string CampaignName,string ReferenceNumber, string Pwd, bool IsActive)      
    {
            RIDDATA obj = new RIDDATA();
            RIDDATA obj1 = new RIDDATA();
            try
            { 
            //string fields = "id,ReferenceNumber,isactive";
            //string parameters = new StreamReader(parameter).ReadToEnd(); //email1;
            //JObject jObject = JObject.Parse(parameter);
            //int id = (int)jObject["id"];
            //string ReferenceNumber = (string)jObject["ReferenceNumber"];
            //string Pwd = (string)jObject["Pwd"];
            //bool IsActive = (bool)jObject["IsActive"];
            obj = dc.RIDDATAs.Where(r => r.ReferenceNumber == ReferenceNumber).SingleOrDefault();
            //obj = (from rid in dc.RIDDATAs
            //       where rid.ReferenceNumber == ReferenceNumber
            //       select rid).SingleOrDefault();
           // bool isReferenceNumberExists = new OperationsBO().CheckReferenceNumber(ReferenceNumber);
            if (obj != null)
                new OperationsBO().UpdateCampaign(ReferenceNumber, CampaignName, Pwd, IsActive);
            else
                obj = obj1;
            //return Json(obj, JsonRequestBehavior.AllowGet);
            return Json(
       new
       {
       referencenumber=obj.ReferenceNumber,
       IsActive=obj.IsActive}
       , JsonRequestBehavior.AllowGet
       );
            }
            catch (Exception ex)
            {
                ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
        }

     // public JsonResult DeleteCampaign([FromBody]JToken jObject)
        [System.Web.Mvc.HttpPost]
        public JsonResult DeleteCampaign(string ReferenceNumber) 
        {
            RIDDATA obj = new RIDDATA();
            RIDDATA obj1 = new RIDDATA();
          try
          { 
            //string fields = "id,ReferenceNumber,isactive";
            //string parameters = new StreamReader(parameter).ReadToEnd(); //email1;
            //JObject jObject = JObject.Parse(parameter);
            //int id = (int)jObject["id"];
            //string ReferenceNumber = (string)jObject["ReferenceNumber"];
            //string Pwd = (string)jObject["Pwd"];
            //bool IsActive = (bool)jObject["IsActive"];
            //obj = dc.RIDDATAs.Where(r => r.ReferenceNumber == ReferenceNumber).Select(r=>r).SingleOrDefault();
            obj = dc.RIDDATAs.Where(r => r.ReferenceNumber == ReferenceNumber).SingleOrDefault();

            //bool isReferenceNumberExists = new OperationsBO().CheckReferenceNumber(ReferenceNumber);
            if (obj != null && obj.IsActive == true)
            {
                obj.IsActive = false;
                obj.UpdatedDate = DateTime.UtcNow;
                dc.SaveChanges();

            }
            else
            {
                obj = obj1;
            }
            return Json(
     new
     {
         referencenumber = obj.ReferenceNumber,
         IsActive = obj.IsActive
     }
     , JsonRequestBehavior.AllowGet
     );
            //return Json(obj, JsonRequestBehavior.AllowGet);
          }
          catch (Exception ex)
          {
              ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
              return Json(obj, JsonRequestBehavior.AllowGet);
          }
        }

    }
}