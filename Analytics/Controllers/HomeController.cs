using Analytics.Helpers.BO;
using Analytics.Helpers.Utility;
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
            return View();
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
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
            string rid_param="";
            if (Request.UrlReferrer != null)
                rid_param = Request.UrlReferrer.LocalPath;
            else
                rid_param = Request.Path;
            if (rid_param.Contains("/"))
                rid_param = rid_param.Replace("/", "");
            if (rid_param.Contains(@"\"))
                rid_param = rid_param.Replace(@"\", "");
            rid_param = rid_param.Trim();
            long decodedvalue = new ConvertionBO().BaseToLong(rid_param);
            int rid_shorturl = Convert.ToInt32(decodedvalue);

            PWDDataBO obj = new OperationsBO().GetUIDRIDDATA(rid_shorturl);
            if (obj != null && obj.typediff == "2" && obj.pwd!="" && obj.pwd!=null)
            {
                return View();
            }
            else if (obj != null && obj.typediff == "2" && (obj.pwd == "" || obj.pwd == null))
            {
                Response.Redirect("~/Analytics/Index?rid=" + rid_shorturl); 
            }
            else if (obj != null && obj.typediff == "1")
            {
                //call monitize service here
                new OperationsBO().Monitize(rid_param);
            }
            return View();
        }

        public string Validate(string password, string chkRemember)
        {
            try
            {
                if (Convert.ToBoolean(chkRemember) == true)
                {
                    HttpCookie Logincookie = Request.Cookies["AnalyticsLogin"];
                    if (Logincookie != null)
                    {
                        //do logic here ..later
                    }
                }
                if (password != null)
                {
                    string rid_param = "";
                    if (Request.UrlReferrer.LocalPath != "")
                    {
                        //rid_param = Request.Params["rid"];
                        rid_param = Request.UrlReferrer.LocalPath;
                        if (rid_param.Contains("/"))
                            rid_param = rid_param.Replace("/", "");
                        if (rid_param.Contains(@"\"))
                            rid_param = rid_param.Replace(@"\", "");
                        rid_param = rid_param.Trim();
                        long decodedvalue = new ConvertionBO().BaseToLong(rid_param);
                        int rid_shorturl = Convert.ToInt32(decodedvalue);
                        int? rid_value = 0;
                        PWDDataBO obj = new OperationsBO().GetUIDRIDDATA(rid_shorturl);
                        if (obj != null && obj.typediff == "2")
                        {
                            rid_value = obj.UIDorRID;
                            Session["rid"] = rid_value;
                            if (rid_value != 0)
                                if (new OperationsBO().CheckPassword_RIDDATA(rid_value, password))
                                {
                                    return "Success~/../Analytics/Index?rid=" + rid_shorturl;
                                }
                        }
                        //else if (obj != null && obj.TypeDiff == "1")
                        //{
                        //    //call monitize service here
                        //    new OperationsBO().Monitize(rid_param);
                        //}
                        else
                        {
                            return "Failed~Wrong Password";
                        }

                    }
                    return "Failed~Invalid password";

                }
                else
                {
                    return "Failed~Invalid password";
                }
            }
            catch (Exception ex)
            {

                ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                return new HttpStatusCodeResult(400, ex.Message).ToString();
            }

        }
    }
}