using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;

using System.Net.Http;
using System.Web.Http.Cors;
using Analytics.Models;
using Analytics.Helpers.Utility;
using Analytics.Helpers.BO;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Web.Http.Results;
using System.Net;


namespace Analytics.Controllers
{
    [EnableCors(origins: "http://localhost:3300", headers: "*", methods: "*")]
    public class CustomerController : ApiController
    {
        shortenURLEntities dc = new shortenURLEntities();
        // OPTIONS http-verb handler
        //public HttpResponseMessage OptionsUser()
        //{
        //    var response = new HttpResponseMessage();
        //    response.StatusCode = HttpStatusCode.OK;
        //    return response;
        //}
        //public HttpResponseMessage Get()
        //{
        //    return new HttpResponseMessage()
        //    {
        //        Content = new StringContent("GET: Test message")
        //    };
        //}
        //[System.Web.Http.AcceptVerbs("GET", "POST")]
        //[System.Web.Http.HttpGet]
        //public JsonResult Users()
        //{
        //    return new JsonResult()
        //    {
        //        Data = "Test Result",
        //        JsonRequestBehavior = JsonRequestBehavior.AllowGet
        //    };
        //}
        
        //get api/users
        public IEnumerable<ClientView> Get()
        {
            Client obj1 = new Client();
           //get all client detials
            List<ClientView> objc = (from c in dc.Clients
                                         select new ClientView
                                         {
                                             id = c.PK_ClientID,
                                             UserName = c.UserName,
                                             Email = c.Email,
                                             IsActive = c.IsActive
                                             //Password = c.Password
                                         }).ToList();

            //.Skip(parameters.PageSize * (parameters.Page - 1)).Take(parameters.PageSize);    http://codereview.stackexchange.com/questions/69602/net-rest-api-json-filtering
                //return new JsonResult()
                //{
                //    Data = objc,
                //    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                //};
            HttpContext.Current.Response.AppendHeader("Access-Control-Allow-Credentials", "true");
            HttpContext.Current.Response.AppendHeader("SupportsCredentials ", "true");

                return objc;
            
        }
        //api/Users/id
        public JsonResult<ClientView> Get(int? id)
        {
            ClientView objc = new ClientView();
            string fields = "id,UserName,Email,IsActive";
            if(id!=null)
           {
                objc = (from c in dc.Clients
                                        where c.PK_ClientID==id
                                        select new ClientView
                                        {
                                            id = c.PK_ClientID,
                                            UserName = c.UserName,
                                            Email = c.Email,
                                            IsActive = c.IsActive
                                            //Password = c.Password
                                        }).SingleOrDefault();
               //return  Json(objc, JsonRequestBehavior.AllowGet);
               //return new JsonResult()
               //{
               //    Data = objc,
               //    JsonRequestBehavior = JsonRequestBehavior.AllowGet
               //};
                HttpContext.Current.Response.AppendHeader("Access-Control-Allow-Credentials", "true");
                HttpContext.Current.Response.AppendHeader("SupportsCredentials ", "true");
                objc.SetSerializableProperties(fields);
                return Json(objc, new Newtonsoft.Json.JsonSerializerSettings()
                {
                    ContractResolver = new ShouldSerializeContractResolver()
                });
               //return objc;
           }
            return Json(objc); ;
           //return new JsonResult()
           //{
           //    Data = "Not Valid Input",
           //    JsonRequestBehavior = JsonRequestBehavior.AllowGet
           //};
        }
        [System.Web.Http.HttpGet]
        public IEnumerable<ClientView> Search(string username,string email,bool? isactive)
        {
            List<ClientView> obj_search = new List<ClientView>();

            if(username!=null && email==null && isactive==null)
            {
                obj_search = (from c in dc.Clients
                              where c.UserName.Contains(username.ToString())
                              select new ClientView()
                              {
                                  id=c.PK_ClientID,
                                  UserName = c.UserName,
                                  Email = c.Email,
                                  IsActive = c.IsActive
                              }).ToList();
            }
            else if(email!=null && username==null && isactive==null)
            {
                obj_search = (from c in dc.Clients
                              where c.Email.Contains(email.ToString())
                              select new ClientView()
                              {
                                  id = c.PK_ClientID,
                                  UserName = c.UserName,
                                  Email = c.Email,
                                  IsActive = c.IsActive
                              }).ToList();
            }
            else if(isactive!=null && username==null && email==null)
            {
                obj_search = (from c in dc.Clients
                              where c.IsActive==isactive
                              select new ClientView()
                              {
                                  id = c.PK_ClientID,
                                  UserName = c.UserName,
                                  Email = c.Email,
                                  IsActive = c.IsActive
                              }).ToList();
            }
            return obj_search;
        }

        //public JsonResult Post(Stream parameter)
        //{
        public JsonResult<Client> Post([FromBody]JToken jObject)
        {
            Client obj = new Client();
            string fields = "UserName,Email,IsActive";
            //string parameters = new StreamReader(parameter).ReadToEnd(); //email1;
            //JObject jObject = JObject.Parse(parameter);
            string UserName = (string)jObject["UserName"];
            string Email = (string)jObject["Email"];
            string Password = (string)jObject["Password"];
            bool IsActive = (bool)jObject["IsActive"];
            bool isEmailExists = new OperationsBO().CheckClientEmail(Email);
            Client obj1 = new Client();
            if (isEmailExists == false)
            {
                //add client details
                string ApiKey = new OperationsBO().GetApiKey();
                obj.UserName = UserName;
                obj.Email = Email;
                obj.Password = Password;
                obj.APIKey = ApiKey;
                obj.IsActive = IsActive;
                dc.Clients.Add(obj);
                dc.SaveChanges();
            }
            else
                obj = obj1;
            // return Json(obj1, JsonRequestBehavior.AllowGet);
            HttpContext.Current.Response.AppendHeader("Access-Control-Allow-Credentials", "true");
            HttpContext.Current.Response.AppendHeader("SupportsCredentials ", "true");

            obj.SetSerializableProperties(fields);
            return Json(obj, new Newtonsoft.Json.JsonSerializerSettings()
            {
                ContractResolver = new ShouldSerializeContractResolver1()
            });
            //return obj1;
            //return new JsonResult()
            //{
            //    Data = obj1,
            //    JsonRequestBehavior = JsonRequestBehavior.AllowGet
            //};
        }


        //public JsonResult Post([FromBody]ClientView objclient)
        //{
        //    Client obj1 = new Client();

        //    bool isEmailExists = new OperationsBO().CheckClientEmail(objclient.Email);
        //    if (isEmailExists == false)
        //    {
        //        //add client details
        //        string ApiKey = new OperationsBO().GetApiKey();
        //        obj1.UserName = objclient.UserName;
        //        obj1.Email = objclient.Email;
        //        obj1.Password = objclient.Password;
        //        obj1.APIKey = ApiKey;
        //        obj1.IsActive = objclient.IsActive;
        //        dc.Clients.Add(obj1);
        //        dc.SaveChanges();
        //    }
        //    // return Json(obj1, JsonRequestBehavior.AllowGet);
        //    HttpContext.Current.Response.AppendHeader("Access-Control-Allow-Credentials", "true");
        //    HttpContext.Current.Response.AppendHeader("SupportsCredentials ", "true");

        //    return new JsonResult()
        //    {
        //        Data = obj1
        //        //JsonRequestBehavior = JsonRequestBehavior.AllowGet
        //    };
        //}


        public JsonResult<Client> Put([FromBody]JToken jObject)
        {
            string id = (string)jObject["id"];
            string UserName = (string)jObject["UserName"];
            string Email = (string)jObject["Email"];
            //string Password = (string)jObject["Password"];
            bool? IsActive = (bool)jObject["IsActive"];
            int id1 = Convert.ToInt32(id);
            string fields = "UserName,Email,IsActive";
            bool isEmailExists = new OperationsBO().CheckClientEmail(Email);
            Client obj = dc.Clients.Where(c => c.PK_ClientID == id1).Select(c1 => c1).SingleOrDefault();
            Client obj1 = new Client();
            if (isEmailExists == true)
                new OperationsBO().UpdateClient(UserName, Email, IsActive);
            else
                obj = obj1;
            //return Json(objclient, JsonRequestBehavior.AllowGet);
            HttpContext.Current.Response.AppendHeader("Access-Control-Allow-Credentials", "true");
            HttpContext.Current.Response.AppendHeader("SupportsCredentials ", "true");
            obj.SetSerializableProperties(fields);
            return Json(obj, new Newtonsoft.Json.JsonSerializerSettings()
            {
                ContractResolver = new ShouldSerializeContractResolver1()
            });
            //return new JsonResult()
            //{
            //    Data = obj,
            //    JsonRequestBehavior = JsonRequestBehavior.AllowGet
            //};
        }
        public JsonResult<Client> Delete([FromBody]JToken jObject)
        {
            string id = (string)jObject["id"];
            string UserName = (string)jObject["UserName"];
            string Email = (string)jObject["Email"];
            string Password = (string)jObject["Password"];
            bool? IsActive = (bool)jObject["IsActive"];
            int id1 = Convert.ToInt32(id);
            string fields = "UserName,Email,IsActive";
            bool isEmailExists = new OperationsBO().CheckClientEmail(Email);
            Client obj = dc.Clients.Where(c => c.PK_ClientID == id1).Select(c1 => c1).SingleOrDefault();
            Client obj1 = new Client();
            if (isEmailExists == true && obj.IsActive == true)
            {
                    obj.IsActive = false;
                    dc.SaveChanges();
                
            }
            else
            {
                obj = obj1;  
            }
            //return Json(objclient, JsonRequestBehavior.AllowGet);
            HttpContext.Current.Response.AppendHeader("Access-Control-Allow-Credentials", "true");
            HttpContext.Current.Response.AppendHeader("SupportsCredentials ", "true");

            obj.SetSerializableProperties(fields);
            return Json(obj, new Newtonsoft.Json.JsonSerializerSettings()
            {
                ContractResolver = new ShouldSerializeContractResolver1()
            });
            //return new JsonResult()
            //{
            //    Data = obj,
            //    JsonRequestBehavior = JsonRequestBehavior.AllowGet
            //};
        }
       
    }
    
}