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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        private static readonly char[] BaseChars =
        "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz./,".ToCharArray();
        private static readonly Dictionary<char, int> CharValues = BaseChars
                   .Select((c, i) => new { Char = c, Index = i })
                   .ToDictionary(c => c.Char, c => c.Index);
        public static long BaseToLong(string number)
        {
            char[] chrs = number.ToCharArray();
            int m = chrs.Length - 1;
            int n = BaseChars.Length, x;
            long result = 0;
            for (int i = 0; i < chrs.Length; i++)
            {
                x = CharValues[chrs[i]];
                result += x * (long)Math.Pow(n, m--);
            }
            return result;
        }
        public bool CheckPassword_RIDDATA(int? rid, string pwd)
        {
            int row_rid = 0; bool check;
            row_rid = (from r in dc.RIDDATAs
                       where r.PK_Rid == rid && r.Pwd == pwd
                       select r.PK_Rid).SingleOrDefault();
            if (row_rid != 0 && row_rid != null)
                check = true;
            else
                check = false;
            return check;
        }
        public ActionResult Login()
        {
            //string rid = Request.RawUrl;
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
                    //HttpRequest Request;
                    if (Request.UrlReferrer.LocalPath != "")
                    {
                        //rid_param = Request.Params["rid"];
                        rid_param = Request.UrlReferrer.LocalPath;
                        if (rid_param.Contains("/"))
                            rid_param = rid_param.Replace("/", "");
                        rid_param = rid_param.Trim();
                        long decodedvalue = BaseToLong(rid_param);
                        int rid_shorturl = Convert.ToInt32(decodedvalue);
                        int? rid_value = (from uid_rid in dc.UIDandRIDDatas
                                          where uid_rid.PK_UniqueId == rid_shorturl
                                          select uid_rid.UIDorRID).SingleOrDefault();
                        Session["rid"] = rid_value;

                        if (CheckPassword_RIDDATA(rid_value, password))
                        {
                            //Response.Redirect("~/Analytics.aspx?rid="+rid_shorturl);
                            return "Success~/../Analytics/Index?rid=" + rid_shorturl;
                        }
                        else
                        {//Page.ClientScript.RegisterStartupScript(this.GetType(), DateTime.Now.ToString(), "alert('Wrong Password');", true);
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

                //ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                return new HttpStatusCodeResult(400, ex.Message).ToString();
            }

        }
    }
}