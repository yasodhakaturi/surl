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
using System.Web.Http;



namespace Analytics.Controllers
{
    [EnableCors(origins: "http://localhost:3300", headers: "*", methods: "*")]
    //[System.Web.Http.RoutePrefix("api/CustomerApi")]
    public class CustomerApiController : ApiController
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
            List<ClientView> objc = new List<ClientView>();
            try{
           //get all client detials
             objc = (from c in dc.Clients
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
             catch (Exception ex)
             {
                 ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                 return objc;
             }
        }
        //api/Users/id
        public JsonResult<ClientView> Get(int? id)
        {
            ClientView objc = new ClientView();
            try{
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
            return Json(objc); 
           //return new JsonResult()
           //{
           //    Data = "Not Valid Input",
           //    JsonRequestBehavior = JsonRequestBehavior.AllowGet
           //};
            }
            catch (Exception ex)
             {
                 ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                 return Json(objc);
             }
        }
        [System.Web.Http.HttpGet]
        public IEnumerable<ClientView> Search(string username,string email,bool? isactive)
        {
            List<ClientView> obj_search = new List<ClientView>();

            try
            {

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
            catch (Exception ex)
             {
                 ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                 return obj_search;

             }
        }

        //public JsonResult Post(Stream parameter)
        //{
        [System.Web.Http.Route("api/CustomerApi/Create")]
        [System.Web.Http.HttpPost]
        public JsonResult<Client> Post([FromBody]JToken jObject)
        {
            Client obj = new Client();
           try{
            string fields = "UserName,Email,IsActive";
            //string parameters = new StreamReader(parameter).ReadToEnd(); //email1;
            //JObject jObject = JObject.Parse(parameter);
            string UserName = (string)jObject["UserName"];
            string Email = (string)jObject["Email"];
            string Password = (string)jObject["Password"];
            bool IsActive = (bool)jObject["IsActive"];
            Client isEmailExists = new OperationsBO().CheckClientEmail(Email);
            //Client obj1 = new Client();
            if (isEmailExists==null)
            {
                //add client details
                string ApiKey = new OperationsBO().GetApiKey();
                obj.UserName = UserName;
                obj.Email = Email;
                obj.Password = Password;
                obj.APIKey = ApiKey;
                obj.IsActive = IsActive;
                obj.Role = "Client";
                obj.CreatedDate = DateTime.Today;
                dc.Clients.Add(obj);
                dc.SaveChanges();
            }
            //else
            //    obj = obj1;
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
            catch (Exception ex)
             {
                 ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                 return Json(obj); 
            }
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
            Client obj1 = new Client();
            try{
            string id = (string)jObject["id"];
            string UserName = (string)jObject["UserName"];
            string Email = (string)jObject["Email"];
            //string Password = (string)jObject["Password"];
            bool? IsActive = (bool)jObject["IsActive"];
            int id1 = Convert.ToInt32(id);
            string fields = "UserName,Email,IsActive";
            Client isEmailExists = new OperationsBO().CheckClientEmail(Email);
            Client obj = dc.Clients.Where(c => c.PK_ClientID == id1).Select(c1 => c1).SingleOrDefault();
            if (isEmailExists!=null)
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

            catch (Exception ex)
             {
                 ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                 return Json(obj1);
             }
        }
        public JsonResult<Client> Delete([FromBody]JToken jObject)
        {
            Client obj1 = new Client();
            try{
            string id = (string)jObject["id"];
            string UserName = (string)jObject["UserName"];
            string Email = (string)jObject["Email"];
            string Password = (string)jObject["Password"];
            bool? IsActive = (bool)jObject["IsActive"];
            int id1 = Convert.ToInt32(id);
            string fields = "UserName,Email,IsActive";
            Client isEmailExists = new OperationsBO().CheckClientEmail(Email);
            Client obj = dc.Clients.Where(c => c.PK_ClientID == id1).Select(c1 => c1).SingleOrDefault();
            if (isEmailExists!=null && obj.IsActive == true)
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
            catch (Exception ex)
             {
                 ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                 return Json(obj1);
             }
        }
               
        [System.Web.Http.Route("api/CustomerApi/Login")]
        [System.Web.Http.HttpPost]
        public JsonResult<Client> Login([FromBody]JToken jObject)
        {
            Client objc=new Client();
            try
            {
                string fields = "Email,IsActive";
                string Email = (string)jObject["Email"];
                string Password = (string)jObject["Password"];
                objc = new OperationsBO().CheckClientEmail(Email);

                if (objc != null && objc.IsActive == true)
                {

                    HttpContext.Current.Response.AppendHeader("Access-Control-Allow-Credentials", "true");
                    HttpContext.Current.Response.AppendHeader("SupportsCredentials ", "true");
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