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
    public class CustomerController : Controller
    {
        shortenURLEntities dc = new shortenURLEntities();

        // GET: Customer
        public JsonResult Index(string id)
        {
        //    return View();
        //}
        //public JsonResult GetclientDetails()
        //{
            List<ClientView> objc = new List<ClientView>();
            ClientView obj = new ClientView();
            int id1 = Convert.ToInt32(id);
            try
            {
                if (id == null)
                {
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
                    return Json(objc, JsonRequestBehavior.AllowGet);

                }
                else if(id!=null)
                {
                obj = (from c in dc.Clients
                                        where c.PK_ClientID==id1
                                        select new ClientView
                                        {
                                            id = c.PK_ClientID,
                                            UserName = c.UserName,
                                            Email = c.Email,
                                            IsActive = c.IsActive
                                            //Password = c.Password
                                        }).SingleOrDefault();
                return Json(objc, JsonRequestBehavior.AllowGet);

                }
                

                return Json(objc,JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                return Json(objc,JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult Search(string username, string email, bool? isactive)
        {
            List<ClientView> obj_search = new List<ClientView>();
            string isactivestr = Convert.ToString(isactive);
            try
            {
                //string username = Helper.CurrentUserName;
                //string email = Helper.CurrentUseremail;
                //bool isactive = Helper.CurrentUserActiveStatus;
                if (username != null && email == null && isactivestr == null)
                {
                    obj_search = (from c in dc.Clients
                                  where c.UserName.Contains(username.ToString())
                                  select new ClientView()
                                  {
                                      id = c.PK_ClientID,
                                      UserName = c.UserName,
                                      Email = c.Email,
                                      IsActive = c.IsActive
                                  }).ToList();
                }
                else if (email != null && username == null && isactivestr == null)
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
                else if (isactivestr != null && username == null && email == null)
                {
                    obj_search = (from c in dc.Clients
                                  where c.IsActive == isactive
                                  select new ClientView()
                                  {
                                      id = c.PK_ClientID,
                                      UserName = c.UserName,
                                      Email = c.Email,
                                      IsActive = c.IsActive
                                  }).ToList();
                }
                return Json(obj_search,JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                Error obj_err = new Error();
                Errormessage errmesobj = new Errormessage();
                errmesobj.message = "Exception occur.";
                obj_err.error = errmesobj;

                return Json(obj_err, JsonRequestBehavior.AllowGet);
                //return Json(obj_search,JsonRequestBehavior.AllowGet);

            }
        }
        public JsonResult AddClient([FromBody]JToken jObject)
        {
            Client obj = new Client();
            try
            {
                //string fields = "UserName,Email,IsActive";
                //string parameters = new StreamReader(parameter).ReadToEnd(); //email1;
                //JObject jObject = JObject.Parse(parameter);
                string UserName = (string)jObject["UserName"];
                string Email = (string)jObject["Email"];
                string Password = (string)jObject["Password"];
                bool IsActive = (bool)jObject["IsActive"];
                Client isEmailExists = new OperationsBO().CheckClientEmail(Email);
                //Client obj1 = new Client();
                if (isEmailExists == null && Session["id"] != null)
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
                else
                {
                    Error obj_err = new Error();
                    Errormessage errmesobj = new Errormessage();
                    errmesobj.message = "client already exists.";
                    obj_err.error = errmesobj;

                    return Json(obj_err, JsonRequestBehavior.AllowGet);
                }
                return Json(obj, JsonRequestBehavior.AllowGet);
                //obj.SetSerializableProperties(fields);
                //return Json(obj, new Newtonsoft.Json.JsonSerializerSettings()
                //{
                //    ContractResolver = new ShouldSerializeContractResolver1()
                //});
                
            }
            catch (Exception ex)
            {
                ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                Error obj_err = new Error();
                Errormessage errmesobj = new Errormessage();
                errmesobj.message = "exception occur.";
                obj_err.error = errmesobj;

                return Json(obj_err, JsonRequestBehavior.AllowGet);
               // return Json(obj,JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult UpdateClient([FromBody]JToken jObject)
        {
             Client obj1 = new Client();
            try{
            string id = (string)jObject["id"];
            string UserName = (string)jObject["UserName"];
            string Email = (string)jObject["Email"];
            //string Password = (string)jObject["Password"];
            bool? IsActive = (bool)jObject["IsActive"];
            int id1 = Convert.ToInt32(id);
            //string fields = "UserName,Email,IsActive";
            Client isEmailExists = new OperationsBO().CheckClientEmail(Email);
            Client obj = dc.Clients.Where(c => c.PK_ClientID == id1).Select(c1 => c1).SingleOrDefault();
            if (isEmailExists!=null)
                new OperationsBO().UpdateClient(UserName, Email, IsActive);
            else
                obj = obj1;
            return Json(obj, JsonRequestBehavior.AllowGet);
                
             }
            catch (Exception ex)
            {
                ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                Error obj_err = new Error();
                Errormessage errmesobj = new Errormessage();
                errmesobj.message = "exception occur.";
                obj_err.error = errmesobj;
                return Json(obj_err, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult DeleteClient([FromBody]JToken jObject)
        {
            Client obj1 = new Client();
            try{
            string id = (string)jObject["id"];
            string UserName = (string)jObject["UserName"];
            string Email = (string)jObject["Email"];
            string Password = (string)jObject["Password"];
            bool? IsActive = (bool)jObject["IsActive"];
            int id1 = Convert.ToInt32(id);
            //string fields = "UserName,Email,IsActive";
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
            return Json(obj, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                Error obj_err = new Error();
                Errormessage errmesobj = new Errormessage();
                errmesobj.message = "exception occur.";
                obj_err.error = errmesobj;
                return Json(obj_err, JsonRequestBehavior.AllowGet);
            }
        }
    }
}