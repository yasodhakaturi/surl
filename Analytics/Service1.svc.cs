using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;
using System.Web;
using System.ServiceModel.Channels;
using System.ServiceModel.Activation;
using System.Net.Sockets;
using Analytics;
using Analytics.Helpers.BO;
using Analytics.Helpers.Utility;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace Analytics
{
    
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        shortenURLEntities dc = new shortenURLEntities();

        int Uniqueid_UID = 0; int Uniqueid_RID = 0; int Uniqueid_SHORTURLDATA = 0; int RID = 0; int UID = 0;
        public class error
        {

            public string message { get; set; }
        }
        public string GETUID(string referencenumber, string longurl, string mobilenumber, out string UID_UIDRID)
        {
            try
            {
                if (referencenumber.Trim() != "" && longurl.Trim() != "" && mobilenumber.Trim() != "")
                {

                    Uniqueid_UID = (from registree in dc.UIDDATAs
                                    where registree.ReferenceNumber.Trim() == referencenumber.Trim() &&
                                    registree.Longurl.Trim() == longurl.Trim() &&
                                    registree.MobileNumber.Trim() == mobilenumber.Trim()
                                    select registree.PK_Uid).SingleOrDefault();
                    //if data found in UIDDATA insert data into UIDDATA 
                    if (Uniqueid_UID == 0)
                    {
                        new DataInsertionBO().InsertUIDdata(referencenumber, longurl, mobilenumber);
                        Uniqueid_UID = (from registree in dc.UIDDATAs
                                        where registree.ReferenceNumber.Trim() == referencenumber.Trim() &&
                                        registree.Longurl.Trim() == longurl.Trim() &&
                                        registree.MobileNumber.Trim() == mobilenumber.Trim()
                                        select registree.PK_Uid).SingleOrDefault();
                    }

                    //if data found in uiddata table get data frim UIDRIDDATA 
                    UID = new OperationsBO().GetUniqueid(Uniqueid_UID, "1");

                    UID_UIDRID = UID.ToString();
                    //convert uid to base64 format    
                    string base64value = new ConvertionBO().LongToBase(Convert.ToInt64(UID));
                    return base64value;

                }
                else
                {
                    UID_UIDRID = "NULL";
                    return "uniqueid not found";
                }
            }
            catch (Exception ex)
            {
                ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                error errobj = new error();
                UID_UIDRID = "NULL";
                errobj.message = "Exception" + ex.Message;
                return JsonConvert.SerializeObject(errobj);
            }
       }

        public string GETRID(string ReferenceNumber, string Password, out string RID_UIDRIID)

         {
             try
             {
                 if (ReferenceNumber.Trim() != "" && Password.Trim() != "")
                 {
                     Uniqueid_RID = (from registree in dc.RIDDATAs
                                     where registree.ReferenceNumber.Trim() == ReferenceNumber.Trim() &&
                                             registree.Pwd.Trim() == Password.Trim()
                                     select registree.PK_Rid).SingleOrDefault();
                     if (Uniqueid_RID == 0)
                     {
                         new DataInsertionBO().InsertRIDdata(ReferenceNumber, Password);
                         Uniqueid_RID = (from registree in dc.RIDDATAs
                                         where registree.ReferenceNumber.Trim() == ReferenceNumber.Trim() &&
                                         registree.Pwd.Trim() == Password.Trim()
                                         select registree.PK_Rid).SingleOrDefault();
                     }

                     //if data found in uiddata table get data frim UIDRIDDATA 
                     RID = (from uniqueid1 in dc.UIDandRIDDatas
                            where uniqueid1.TypeDiff == "2" &&
                            uniqueid1.UIDorRID == Uniqueid_RID
                            select uniqueid1.PK_UniqueId).SingleOrDefault();

                 }
                 else if (ReferenceNumber.Trim() != "" && Password.Trim() == "")
                 {
                     Uniqueid_RID = (from registree in dc.RIDDATAs
                                     where registree.ReferenceNumber.Trim() == ReferenceNumber.Trim()
                                     select registree.PK_Rid).SingleOrDefault();
                     if (Uniqueid_RID == 0)
                     {
                         new DataInsertionBO().InsertRIDdata(ReferenceNumber, "");
                         Uniqueid_RID = (from registree in dc.RIDDATAs
                                         where registree.ReferenceNumber.Trim() == ReferenceNumber.Trim()
                                         select registree.PK_Rid).SingleOrDefault();
                     }
                     //if data found in uiddata table get data frim UIDRIDDATA 
                     RID = new OperationsBO().GetUniqueid(Uniqueid_RID, "2");

                 }
                 if (Uniqueid_RID != 0)
                 {

                     RID_UIDRIID = Uniqueid_RID.ToString();
                     string base64value = new ConvertionBO().LongToBase(Convert.ToInt64(RID));
                     return base64value;

                 }
                 else
                 {

                     RID_UIDRIID = "NULL";
                     return "ReferenceID not found";
                 }

             }
             catch (Exception ex)
             {
                 ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                 error errobj = new error();
                 RID_UIDRIID = "NULL";
                 errobj.message = "Exception" + ex.Message;
                 return JsonConvert.SerializeObject(errobj);
             }
        }

        public void Monitize(string Shorturl)

         {
             try
             {
                 string longurl = "";
                 long decodedvalue = new ConvertionBO().BaseToLong(Shorturl);
                 Uniqueid_SHORTURLDATA = Convert.ToInt32(decodedvalue);
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
                     System.Collections.ArrayList browsers = HttpContext.Current.Request.Browser.Browsers;
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
                 WebOperationContext.Current.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Redirect;
                 if (!longurl.StartsWith("http://") && !longurl.StartsWith("https://"))
                     WebOperationContext.Current.OutgoingResponse.Headers.Add("Location", "http://" + longurl);
                 else
                     WebOperationContext.Current.OutgoingResponse.Headers.Add("Location", longurl);
             }
             catch (Exception ex)
             {
                 ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                 
             }
}


    
    
    }
}
