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
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }

        [System.Web.Http.HttpPost]
        public JsonResult Login(string uname, string password)
     //   [System.Web.Http.HttpPost]
     //public JsonResult Login([FromBody]JToken jObject)    
    {
        //string uname = (string)jObject["uname"];
        //string password = (string)jObject["password"];
            string message = "";
            try
            {
                int loginCount = 0; int checkCount = 0; string contextData = ""; 
                LoginUserInfo obj = new LoginUserInfo();

                if (uname != null && password != null)
                {
                    string credentials = uname + "~" + password + "~";
                    AuthenticateBO objAuthenticateBO = new AuthenticateBO();
                    if (objAuthenticateBO.GetAuthenticateUser(uname, password, out loginCount, out checkCount, out contextData))
                    {
                        // contextData = contextData + "^" + Helper.UrlRef;
                        byte[] hash = Helper.GetHashKey("yasodha.bitra@gmail.com" + "Analytics");

                        Session["userdata"] = contextData;
                        Session["id"] = Helper.CurrentUserId;
                        UserInfo user_obj = new UserInfo();
                        if (Helper.CurrentUserRole == "Admin")
                            obj.redirect_url = "/Admin";
                        else
                            obj.redirect_url = "/Analytics";
                        user_obj.user_id = Helper.CurrentUserId;
                        user_obj.user_name = Helper.CurrentUserName;
                        user_obj.user_role = Helper.CurrentUserRole;
                        obj.user_info = user_obj;
                        return Json(obj, JsonRequestBehavior.AllowGet);

                    }
                    else
                    {
                        Error obj_err = new Error();
                        Errormessage errmesobj = new Errormessage();
                        errmesobj.message = "Authentication Failed";
                        obj_err.error = errmesobj;
                        //Response.StatusCode = 401;
                        return Json(obj_err, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    Error obj_err = new Error();
                    Errormessage errmesobj = new Errormessage();
                    errmesobj.message = "Username and Password should not be null";
                    obj_err.error = errmesobj;

                    return Json(obj_err, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {

                ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                Error obj_err = new Error();
                Errormessage errmesobj = new Errormessage();
                errmesobj.message = "Exception Occured";
                obj_err.error = errmesobj;

                return Json(obj_err, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult UserInfo()
        {
            string message = "";
            try
            {
               if(Session["userdata"]!=null && Session["id"]!=null)
               {
                   UserInfo user_obj = new UserInfo();
                   user_obj.user_id = Helper.CurrentUserId;
                   user_obj.user_name = Helper.CurrentUserName;
                   user_obj.user_role = Helper.CurrentUserRole;
                   return Json(user_obj);
               }
                else
               {
                   message = "404 error";
                   return Json(message);
               }

            }
            catch (Exception ex)
            {

                ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                message = "Exception Occured";
                return Json(message);
            }
        }
        public JsonResult Logout()
        {
            string message = "";
            try
            {
                if(Session["id"]!=null)
                {
                    Session.Remove("id");
                    Session.Remove("userdata");
                   message="Successfully Logout";
                    return Json(message);
                }
                else
                {
                    message = "No User Found";
                    return Json(message);
                }
            }
            catch (Exception ex)
            {

                ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                message = "Exception Occured";
                return Json(message);
            }
        }
    }
}