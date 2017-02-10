using Analytics.Helpers.BO;
using Analytics.Helpers.Utility;
using Analytics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Analytics.Controllers
{
    public class HomeController : Controller
    {
        shortenURLEntities dc = new shortenURLEntities();

        public ActionResult Index()
        
        {
            //var rnd = new Random();
            //string unsuffled = "0123456789ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmopqrstuvwxyz-.!~*'_";
            //string shuffled = new string(unsuffled.OrderBy(r => rnd.Next()).ToArray());
            UserViewModel obj = new UserViewModel();
            string url = Request.Url.ToString();
            obj = new OperationsBO().GetViewConfigDetails(url);
            //int t = 0;
            //for (int r = 0; r < 100000; r++)
            //{

            //    Helper.GenerateUniqueIDs();
            //    t = r;
            //}
            return View(obj);
            //return View();
        }

       
        //private static readonly char[] BaseChars =
        //"0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz./,".ToCharArray();
        //private static readonly Dictionary<char, int> CharValues = BaseChars
        //           .Select((c, i) => new { Char = c, Index = i })
        //           .ToDictionary(c => c.Char, c => c.Index);
        //public static long BaseToLong(string number)
        //{
        //    char[] chrs = number.ToCharArray();
        //    int m = chrs.Length - 1;
        //    int n = BaseChars.Length, x;
        //    long result = 0;
        //    for (int i = 0; i < chrs.Length; i++)
        //    {
        //        x = CharValues[chrs[i]];
        //        result += x * (long)Math.Pow(n, m--);
        //    }
        //    return result;
        //}

        public ActionResult Login()
        {
            return View();
        }
        //public string Validate(string uname,string password, string chkRemember)
        //{
        //    try
        //    {
        //        int loginCount=0;int checkCount=0;string contextData="";
        //        string previouspage = (string)Session["id"];
        //        if (Convert.ToBoolean(chkRemember) == true)
        //        {
        //            HttpCookie Logincookie = Request.Cookies["AnalyticsLogin"];
        //            if (Logincookie != null)
        //            {
        //                byte[] hash = Helper.GetHashKey("yasodha.bitra@gmail.com" + "Analytics");
        //                string credentials = Helper.DecryptQueryString(hash, Logincookie.Value);
        //                string[] cred = credentials.Split('~');
        //                uname = cred[0];
        //                password = cred[1];

        //            }
        //        }
        //        if (uname != null && password != null)
        //        {
        //            //string type = (string)TempData["mb"];
        //            string credentials = uname + "~" + password + "~" + chkRemember;
        //            AuthenticateBO objAuthenticateBO = new AuthenticateBO();
        //            if (objAuthenticateBO.GetAuthenticateUser(uname, password, out loginCount, out checkCount, out contextData))
        //            {
        //               // contextData = contextData + "^" + Helper.UrlRef;
        //                byte[] hash = Helper.GetHashKey("yasodha.bitra@gmail.com" + "Analytics");

        //                Session["userdata"] = contextData;
        //                Session["id"] = Helper.CurrentUserId;
        //                // if (Convert.ToBoolean(chkRemember) == true)
        //                //{
        //                    HttpCookie cookie = new HttpCookie("AnalyticsLogin");
        //                    string cookievalue = Helper.Encrypt(hash, credentials);
        //                    cookie.Value = cookievalue;
        //                    cookie.Expires = DateTime.Now.AddYears(2);
        //                    Response.Cookies.Add(cookie);
        //                //}
        //            }
        //        }
        //        if (previouspage == null)
        //        {
        //            if (Helper.CurrentUserRole == "Admin")
        //            return "Success~/../Admin/Admin";
        //            else
        //            return "Success~/../Analytics/Analytics";
        //        }
        //        else
        //            return "Success~/../Analytics/Analytics/" + Session["id"];
        //    }
        //        catch (Exception ex)
        //    {

        //        ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
        //        return new HttpStatusCodeResult(400, ex.Message).ToString();
        //    }
        //}

            //try
            //{

            //    if (password != null)
            //    {
            //        string rid_param = "";
            //        if (Request.UrlReferrer.LocalPath != "")
            //        {
            //            //rid_param = Request.Params["rid"];
            //            rid_param = Request.UrlReferrer.LocalPath;
            //            if (rid_param.Contains("/"))
            //                rid_param = rid_param.Replace("/", "");
            //            if (rid_param.Contains(@"\"))
            //                rid_param = rid_param.Replace(@"\", "");
            //            rid_param = rid_param.Trim();
            //            long decodedvalue = new ConvertionBO().BaseToLong(rid_param);
            //            int rid_shorturl = Convert.ToInt32(decodedvalue);
            //            int? rid_value = 0;
            //            PWDDataBO obj = new OperationsBO().GetUIDRIDDATA(rid_shorturl);
            //            if (obj != null && obj.typediff == "2")
            //            {
            //                rid_value = obj.UIDorRID;
            //                int? clientid = dc.RIDDATAs.Where(x => x.PK_Rid == rid_value).Select(y => y.FK_ClientId).SingleOrDefault();
            //                Client clientobj = dc.Clients.Where(x => x.PK_ClientID == clientid).SingleOrDefault();
            //                string userdata = clientobj.PK_ClientID + "^" + clientobj.UserName + "^" + clientobj.Role;
            //                Session["rid"] = rid_value;
            //                if (rid_value != 0)
            //                    if (new OperationsBO().CheckPassword_RIDDATA(rid_value, password))
            //                    {
            //                        if (Convert.ToBoolean(chkRemember) == true)
            //                        {
            //                            byte[] hash = Helper.GetHashKey("superadmin@moozup.com" + "Moozup");
            //                            string credentials = rid_value + "~" + password + "~" + chkRemember;
            //                            HttpCookie cookie = new HttpCookie("AnalyticsLogin");
            //                            string cookievalue = Helper.Encrypt(hash, credentials);
            //                            cookie.Value = cookievalue;
            //                            cookie.Expires = DateTime.Now.AddYears(1);
            //                            Response.Cookies.Add(cookie);
            //                        }
            //                        //return "Success~/../Analytics/Index?rid=" + rid_shorturl;
            //                        return "Success~/../Analytics/Analytics?rid=" + rid_shorturl;

            //                    }
            //            }
            //            //else if (obj != null && obj.TypeDiff == "1")
            //            //{
            //            //    //call monitize service here
            //            //    new OperationsBO().Monitize(rid_param);
            //            //}
            //            else
            //            {
            //                return "Failed~Wrong Password";
            //            }

            //        }
            //        return "Failed~Invalid password";

            //    }
            //    else
            //    {
            //        return "Failed~Invalid password";
            //    }
            //}
            //catch (Exception ex)
            //{

            //    ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
            //    return new HttpStatusCodeResult(400, ex.Message).ToString();
            //}

        //}

        //public ActionResult LoginRid()
        
        //{
        //    try
        //    {
        //        string rid_param = ""; int rid_shorturl = 0; int rid_cookie = 0;
        //        //if (Convert.ToBoolean(chkRemember) == true)
        //        //{
        //        HttpCookie Logincookie = Request.Cookies["AnalyticsLogin"];
                    
        //        //if (Logincookie != null)
        //        //    {
        //        //        byte[] hash = Helper.GetHashKey("yasodha.bitra@gmail.com" + "Analytics");
        //        //        string credentials = Helper.DecryptQueryString(hash, Logincookie.Value);
        //        //        string[] cred = credentials.Split('~');
        //        //         rid_param = cred[0];
        //        //        string password = cred[1];
        //        //        rid_cookie = Convert.ToInt32(rid_param);

        //        //    }
        //        //}
        //            //if (rid_param == "" && rid_shorturl == 0)
        //            //{
        //                if (Request.UrlReferrer != null)
        //                    rid_param = Request.UrlReferrer.LocalPath;
        //                else
        //                    rid_param = Request.Path;
        //                if (rid_param.Contains("/"))
        //                    rid_param = rid_param.Replace("/", "");
        //                if (rid_param.Contains(@"\"))
        //                    rid_param = rid_param.Replace(@"\", "");
        //                rid_param = rid_param.Trim();
        //                long decodedvalue = new ConvertionBO().BaseToLong(rid_param);
        //                rid_shorturl = Convert.ToInt32(decodedvalue);
        //                //string base64 = new ConvertionBO().LongToBase(Convert.ToInt32(rid_param));
        //            //}
        //    PWDDataBO obj = new OperationsBO().GetUIDRIDDATA(rid_shorturl);
        //    if (obj != null && obj.typediff == "2" && obj.pwd != "" && obj.pwd != null)
        //    {
        //        if (Logincookie == null)
        //            return View();
        //        else
        //        {
        //            if (rid_shorturl == rid_cookie)
        //                Response.Redirect("~/Analytics?rid=" + rid_param);
        //            else
        //                return View();
        //        }

        //    }
        //    else if (obj != null && obj.typediff == "2" && (obj.pwd == "" || obj.pwd == null))
        //    {
        //        //Response.Redirect("~/Analytics/Index?rid=" + rid_shorturl); 
        //        Response.Redirect("~/Analytics?rid=" + rid_param); 

        //    }
        //    else if (obj != null && obj.typediff == "1")
        //    {
        //        //call monitize service here
        //        new OperationsBO().Monitize(rid_param);
        //    }
        //    return View();
        //    }
        //    catch (Exception ex)
        //    {

        //        ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
        //        return View();
        //        //return new HttpStatusCodeResult(400, ex.Message).ToString();
        //    }
        //}

        //public string ValidateRid(string password, string chkRemember)
        //{
        //    try
        //    {
                
        //        if (password != null)
        //        {
        //            string rid_param = "";
        //            if (Request.UrlReferrer.LocalPath != "")
        //            {
        //                //rid_param = Request.Params["rid"];
        //                rid_param = Request.UrlReferrer.LocalPath;
        //                if (rid_param.Contains("/"))
        //                    rid_param = rid_param.Replace("/", "");
        //                if (rid_param.Contains(@"\"))
        //                    rid_param = rid_param.Replace(@"\", "");
        //                rid_param = rid_param.Trim();
        //                long decodedvalue = new ConvertionBO().BaseToLong(rid_param);
        //                int rid_shorturl = Convert.ToInt32(decodedvalue);
        //                int? rid_value = 0;
        //                PWDDataBO obj = new OperationsBO().GetUIDRIDDATA(rid_shorturl);
        //                if (obj != null && obj.typediff == "2")
        //                {
        //                    rid_value = obj.UIDorRID;
        //                    int? clientid = dc.RIDDATAs.Where(x => x.PK_Rid == rid_value).Select(y => y.FK_ClientId).SingleOrDefault();
        //                    Client clientobj = dc.Clients.Where(x => x.PK_ClientID == clientid).SingleOrDefault();
        //                    string userdata = clientobj.PK_ClientID + "^" + clientobj.UserName + "^" + clientobj.Role;
        //                    Session["rid"] = rid_value;
        //                    if (rid_value != 0)
        //                        if (new OperationsBO().CheckPassword_RIDDATA(rid_value, password))
        //                        {
        //                            if (Convert.ToBoolean(chkRemember) == true)
        //                            {
        //                                byte[] hash = Helper.GetHashKey("superadmin@moozup.com" + "Moozup");
        //                                string credentials = rid_value + "~" + password+"~"+chkRemember;
        //                                HttpCookie cookie = new HttpCookie("AnalyticsLogin");
        //                                string cookievalue = Helper.Encrypt(hash, credentials);
        //                                cookie.Value = cookievalue;
        //                                cookie.Expires = DateTime.Now.AddYears(1);
        //                                Response.Cookies.Add(cookie);
        //                            }
        //                            //return "Success~/../Analytics/Index?rid=" + rid_shorturl;
        //                            return "Success~/../Analytics/Analytics?rid=" + rid_shorturl;

        //                        }
        //                }
        //                //else if (obj != null && obj.TypeDiff == "1")
        //                //{
        //                //    //call monitize service here
        //                //    new OperationsBO().Monitize(rid_param);
        //                //}
        //                else
        //                {
        //                    return "Failed~Wrong Password";
        //                }

        //            }
        //            return "Failed~Invalid password";

        //        }
        //        else
        //        {
        //            return "Failed~Invalid password";
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
        //        return new HttpStatusCodeResult(400, ex.Message).ToString();
        //    }

        //}
    }
}