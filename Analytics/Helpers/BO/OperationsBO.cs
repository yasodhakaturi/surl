using Analytics.Helpers.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;
using System.Web;

namespace Analytics.Helpers.BO
{
    public class OperationsBO
    {
        shortenURLEntities dc = new shortenURLEntities();
        public bool CheckUniqueid(int Uniqueid_UIDRID, string type)
        {
            try
            {
                bool check;
                int un_UIDRID = 0;
                un_UIDRID = (from uniid in dc.UIDandRIDDatas
                             where uniid.PK_UniqueId == Uniqueid_UIDRID && uniid.TypeDiff == type
                             select uniid.PK_UniqueId).SingleOrDefault();
                if (un_UIDRID != 0)
                {
                    check = true;
                    return check;
                }
                else
                {
                    check = false;
                    return check;
                }
            }
            catch (Exception ex)
            {
                ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                return false;
            }
        }
        public bool CheckPassword_RIDDATA(int? rid, string pwd)
        {
            try
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
            catch (Exception ex)
            {
                ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                return false;
            }
        }
        public int GetUniqueid(int Uniqueid_UIDRID, string type)
        {
            try
            {
                int un_UIDRID = 0;
                un_UIDRID = (from uniid in dc.UIDandRIDDatas
                             where uniid.UIDorRID == Uniqueid_UIDRID && uniid.TypeDiff == type
                             select uniid.PK_UniqueId).SingleOrDefault();
                if (un_UIDRID != 0)
                    return un_UIDRID;
                else
                    return un_UIDRID;
            }
            catch (Exception ex)
            {
                ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                return 0;
            }
        }
        public string GetLongURL(int Uniqueid_ShortURL)
        {
            try
            {
                string LongURL = "";
                LongURL = (from uniid in dc.UIDandRIDDatas
                           join uidtable in dc.UIDDATAs on uniid.UIDorRID equals uidtable.PK_Uid
                           where uniid.PK_UniqueId == Uniqueid_ShortURL
                           select uidtable.Longurl).SingleOrDefault();
                if (LongURL != "")
                    return LongURL;
                else
                    return LongURL;
            }
            catch (Exception ex)
            {
                ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                return "";
            }

        }
        public PWDDataBO GetUIDRIDDATA(int Uniqueid_UIDRID)
        {
            try
            {

                
                PWDDataBO obj = (from uniid in dc.UIDandRIDDatas
                               join uidtable in dc.RIDDATAs on uniid.UIDorRID equals uidtable.PK_Rid
                               where uniid.PK_UniqueId == Uniqueid_UIDRID 
                               select new PWDDataBO
                             {
                                 typediff=uniid.TypeDiff,
                
                                 pwd=uidtable.Pwd,
                                 UIDorRID=uniid.UIDorRID
                             }).SingleOrDefault();
                if (obj != null)
                    return obj;
                else
                    return null;
                
                
            }
            catch (Exception ex)
            {
                ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                return null;
            }
        }
        public int? GetUIDRID(int Uniqueid_UIDRID, string type)
        {
            try
            {
                
                int? un_UIDRID = 0;
                un_UIDRID = (from uniid in dc.UIDandRIDDatas
                             where uniid.PK_UniqueId == Uniqueid_UIDRID && uniid.TypeDiff == type
                             select uniid.UIDorRID).SingleOrDefault();
                if (un_UIDRID != 0)
                {

                    return un_UIDRID;
                }
                else
                {

                    return un_UIDRID;
                }
            }
            catch (Exception ex)
            {
                ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                return 0;
            }
        }
        public void Monitize(string Shorturl)
        {
            try
            {
                string longurl = "";
                long decodedvalue = new ConvertionBO().BaseToLong(Shorturl);
                int Uniqueid_SHORTURLDATA = Convert.ToInt32(decodedvalue);
                if (new OperationsBO().CheckUniqueid(Uniqueid_SHORTURLDATA, "1"))
                {
                    //retrive ipaddress and browser
                    string ipv4 = new ConvertionBO().GetIP4Address();
                    string ipv6 = HttpContext.Current.Request.UserHostAddress;
                    string browser = HttpContext.Current.Request.Browser.Browser;
                    string browserversion = HttpContext.Current.Request.Browser.Version;
                    string req_url = HttpContext.Current.Request.Url.ToString();
                    //string[] header_array = HttpContext.Current.Request.Headers.AllKeys;
                    string useragent = HttpContext.Current.Request.UserAgent;
                    string hostname = HttpContext.Current.Request.UserHostName;
                    string devicetype = HttpContext.Current.Request.Browser.Platform;
                    string ismobiledevice = HttpContext.Current.Request.Browser.IsMobileDevice.ToString();
                    //retrieve longurl from uid
                    longurl = new OperationsBO().GetLongURL(Uniqueid_SHORTURLDATA);
                    //if(longurl!=null)
                    //    HttpContext.Current.Response.Redirect(longurl);

                    //retrive city,country
                    var City = ""; var Region = ""; var Country = ""; var CountryCode = ""; var url = "";
                    //url = "http://freegeoip.net/json/" + "99.25.39.48";
                    url = "http://freegeoip.net/json/" + ipv4;
                    var request = System.Net.WebRequest.Create(url);
                    using (WebResponse wrs = request.GetResponse())
                    using (Stream stream = wrs.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string json = reader.ReadToEnd();
                        var obj = JObject.Parse(json);
                        City = (string)obj["city"];
                        Region = (string)obj["region_name"];
                        Country = (string)obj["country_name"];
                        CountryCode = (string)obj["country_code"];
                    }
                    //retrive city,country if city country not found with ipv4
                    if (City == "" && Country == "")
                    {
                        url = "http://freegeoip.net/json/" + ipv6;
                        var request1 = System.Net.WebRequest.Create(url);
                        using (WebResponse wrs = request1.GetResponse())
                        using (Stream stream = wrs.GetResponseStream())
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            string json = reader.ReadToEnd();
                            var obj = JObject.Parse(json);
                            City = (string)obj["city"];
                            Region = (string)obj["region_name"];
                            Country = (string)obj["country_name"];
                            CountryCode = (string)obj["country_code"];
                        }
                    }
                    new DataInsertionBO().InsertShortUrldata(ipv4, ipv6, browser, browserversion, City, Region, Country, CountryCode, req_url, useragent, hostname, devicetype, ismobiledevice, Uniqueid_SHORTURLDATA);
                }
                //WebOperationContext.Current.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Redirect;
                //if (!longurl.StartsWith("http://") && !longurl.StartsWith("https://"))
                //    WebOperationContext.Current.OutgoingResponse.Headers.Add("Location", "http://" + longurl);
                //else
                //    WebOperationContext.Current.OutgoingResponse.Headers.Add("Location", longurl);
                if (longurl != null && !longurl.StartsWith("http://") && !longurl.StartsWith("https://"))
                    HttpContext.Current.Response.Redirect("http://" + longurl);
                else
                    HttpContext.Current.Response.Redirect(longurl);


            }
            catch (Exception ex)
            {
                ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());

            }
        }
    
    }
}