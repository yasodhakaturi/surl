using Analytics.Helpers.BO;
using Analytics.Helpers.Utility;
using Analytics.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace Analytics.Controllers
{
  // [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class CampaignApiController : ApiController
    {
        shortenURLEntities dc = new shortenURLEntities();
        //api/campaigns
        public IEnumerable<CampaignView> Get()
        {
            CampaignView obj = new CampaignView();
                //get all Campaigns
                List<CampaignView> listcamps = (from r in dc.RIDDATAs
                                                select new CampaignView
                                                {
                                                    id = r.PK_Rid,
                                                    ReferenceNumber = r.ReferenceNumber,
                                                   // pwd = r.Pwd,
                                                    isactive = r.IsActive
                                                }).ToList();

                //.Skip(parameters.PageSize * (parameters.Page - 1)).Take(parameters.PageSize);    http://codereview.stackexchange.com/questions/69602/net-rest-api-json-filtering
                //return new JsonResult()
                //{
                //    Data = objc,
                //    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                //};
               // HttpContext.Current.Response.AppendHeader("Access-Control-Allow-Credentials", "true");
                //HttpContext.Current.Response.AppendHeader("SupportsCredentials ", "true");

                return listcamps;

            
        }
        public JsonResult<CampaignView> Get(int? id)
        {
            CampaignView objc = new CampaignView();
            string fields = "id,ReferenceNumber,isactive";
            if (id != null)
            {
                objc = (from r in dc.RIDDATAs
                        where r.PK_Rid==id
                        select new CampaignView
                        {
                         id = r.PK_Rid,
                         ReferenceNumber = r.ReferenceNumber,
                         //pwd = r.Pwd,
                         isactive = r.IsActive
                         }).SingleOrDefault();
               
                objc.SetSerializableProperties(fields);
                return Json(objc, new Newtonsoft.Json.JsonSerializerSettings()
                {
                    ContractResolver = new ShouldSerializeContractResolver()
                });
                //return objc;
               /// return Json(objc, JsonRequestBehavior.AllowGet);
            }
            return Json(objc); ;
        }
        [System.Web.Http.HttpGet]
        public IEnumerable<CampaignView> Search(string referencenumber,bool? isactive)
        {
            List<CampaignView> obj_search = new List<CampaignView>();

            if (referencenumber != null  && isactive == null)
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

            else if (isactive != null && referencenumber == "")
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
            return obj_search;
        }
        public JsonResult<RIDDATA> Post([FromBody]JToken jObject)
        {
            RIDDATA obj = new RIDDATA();
            string fields = "id,ReferenceNumber,isactive";
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
                obj.CreatedDate= DateTime.UtcNow;
                obj.FK_ClientId = FK_ClientId;
                dc.RIDDATAs.Add(obj);
                dc.SaveChanges();
              new OperationsBO().InsertUIDRIDData(ReferenceNumber);
            }
            //else
            //    obj = obj1;
            // return Json(obj1, JsonRequestBehavior.AllowGet);
          //  HttpContext.Current.Response.AppendHeader("Access-Control-Allow-Credentials", "true");
           // HttpContext.Current.Response.AppendHeader("SupportsCredentials ", "true");

            obj.SetSerializableProperties(fields);
            return Json(obj, new Newtonsoft.Json.JsonSerializerSettings()
            {
                ContractResolver = new ShouldSerializeContractResolver1()
            });
        }

        public JsonResult<RIDDATA> Put([FromBody]JToken jObject)
        {
            RIDDATA obj = new RIDDATA();
            RIDDATA obj1 = new RIDDATA();
            string fields = "id,ReferenceNumber,isactive";
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
           // HttpContext.Current.Response.AppendHeader("Access-Control-Allow-Credentials", "true");
            //HttpContext.Current.Response.AppendHeader("SupportsCredentials ", "true");
            obj.SetSerializableProperties(fields);
            return Json(obj, new Newtonsoft.Json.JsonSerializerSettings()
            {
                ContractResolver = new ShouldSerializeContractResolver1()
            });
        }
        public JsonResult<RIDDATA> Delete([FromBody]JToken jObject)
        {
            RIDDATA obj = new RIDDATA();
            RIDDATA obj1 = new RIDDATA();
            string fields = "id,ReferenceNumber,isactive";
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
            //return Json(objclient, JsonRequestBehavior.AllowGet);
           // HttpContext.Current.Response.AppendHeader("Access-Control-Allow-Credentials", "true");
            //HttpContext.Current.Response.AppendHeader("SupportsCredentials ", "true");

            obj.SetSerializableProperties(fields);
            return Json(obj, new Newtonsoft.Json.JsonSerializerSettings()
            {
                ContractResolver = new ShouldSerializeContractResolver1()
            });   
            
        }

        public JsonResult<RIDDATA> Login([FromBody]JToken jObject)
        {
            RIDDATA objc = new RIDDATA();
            try
            {
                string fields = "id,ReferenceNumber,isactive";
                string ReferenceNumber = (string)jObject["ReferenceNumber"];
                string Pwd = (string)jObject["Pwd"];
                 objc = new OperationsBO().CheckReferenceNumber1(ReferenceNumber);

                if (objc != null && objc.IsActive == true)
                {

                   // HttpContext.Current.Response.AppendHeader("Access-Control-Allow-Credentials", "true");
                    //HttpContext.Current.Response.AppendHeader("SupportsCredentials ", "true");
                    objc.SetSerializableProperties(fields);
                    return Json(objc, new Newtonsoft.Json.JsonSerializerSettings()
                    {
                        ContractResolver = new ShouldSerializeContractResolver()
                    });
                }
                return Json(objc);
            }
        
            catch (Exception ex)
            {
                ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                return Json(objc);
            }
        }
  

    }
}