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
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Globalization;
using System.Web.Hosting;
using System.Web.Configuration;
using System.Web.Security;

namespace Analytics
{
    
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
     [ServiceBehavior(IncludeExceptionDetailInFaults = true, InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Single)]
        [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
        
    public class Service1 : IService1
    {
        shortenURLEntities dc = new shortenURLEntities();
        SqlConnection lSQLConn = null;
        SqlCommand lSQLCmd = new SqlCommand();
        int Uniqueid_UID = 0; int Uniqueid_RID = 0; int Uniqueid_SHORTURLDATA = 0; int RID = 0; int UID = 0;

        public class error
        {

            public string message { get; set; }
        }

        public string GETClientid(string UserName, string Email, string Password)
        {
            try
            {
                 Client obj = new Client();bool isactive=true;int cid=0;
                if (UserName.Trim() != "" && Email.Trim() != "" && Password.Trim() != "")
                {
                    
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
                obj.IsActive = isactive;
                obj.Role = "Client";
                obj.CreatedDate = DateTime.Today;
                dc.Clients.Add(obj);
                dc.SaveChanges();
            }
                    Client cl_obj=new OperationsBO().CheckClientEmail(Email);
                    if(cl_obj!=null)
                    {  cid=cl_obj.PK_ClientID;}
                        return "APi_Key:"+cl_obj.APIKey;

                    }
                    else
                    {
                       return cid.ToString(); 
                    }
               
            }
            catch (Exception ex)
            {
                ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                error errobj = new error();
                errobj.message = "Exception" + ex.Message;
                return null;
            }
        }



        public string GETUID(string referencenumber, string longurl, string mobilenumber,string api_key)
        {
            try
            {
                Client cl_obj = (from c in dc.Clients
                                 where c.APIKey == api_key
                                 select c).SingleOrDefault();
                string Uniqueid="";
                if(cl_obj != null)
                { 
                if (referencenumber.Trim() != "" && longurl.Trim() != "" && mobilenumber.Trim() != "")
                {
                    //check reference number in RID table
                    RIDDATA objrid = (from registree in dc.RIDDATAs
                                    where registree.ReferenceNumber.Trim() == referencenumber.Trim()
                                    select registree).SingleOrDefault();
                    Uniqueid_RID = objrid.PK_Rid;
                    //if (Uniqueid_RID == 0)
                    //{
                    //    new DataInsertionBO().InsertRIDdata(referencenumber, "");
                    //    Uniqueid_RID = (from registree in dc.RIDDATAs
                    //                    where registree.ReferenceNumber.Trim() == referencenumber.Trim()
                    //                    select registree.PK_Rid).SingleOrDefault();
                    //}
                    if (objrid!=null)
                    {
                        //check data in UID table
                        Uniqueid = (from registree in dc.UIDDATAs
                                        where registree.ReferenceNumber.Trim() == referencenumber.Trim() &&
                                        registree.Longurl.Trim() == longurl.Trim() &&
                                        registree.MobileNumber.Trim() == mobilenumber.Trim()
                                        select registree.UniqueNumber).SingleOrDefault();
                        //if data found in UIDDATA insert data into UIDDATA 
                        if (Uniqueid==null)
                        {
                            Uniqueid = Helper.GetRandomAlphanumericString(5);
                            new DataInsertionBO().InsertUIDdata(Uniqueid_RID, objrid.FK_ClientId, referencenumber, longurl, mobilenumber, Uniqueid);
                            Uniqueid = (from registree in dc.UIDDATAs
                                            where registree.ReferenceNumber.Trim() == referencenumber.Trim() &&
                                            registree.Longurl.Trim() == longurl.Trim() &&
                                            registree.MobileNumber.Trim() == mobilenumber.Trim()
                                            select registree.UniqueNumber).SingleOrDefault();
                        }

                        //if data found in uiddata table get data frim UIDRIDDATA 
                        //UID = new OperationsBO().GetUniqueid(Uniqueid_UID, "1");

                        //UID_UIDRID = UID.ToString();
                        //convert uid to base64 format    
                        //string base64value = new ConvertionBO().LongToBase(Convert.ToInt64(Uniqueid));
                        //update record with base64 value
                        //UIDandRIDData obj = (from u in dc.UIDandRIDDatas
                        //                     where u.PK_UniqueId == UID
                        //                     select u).SingleOrDefault();
                        //obj.Base64Value = base64value;
                        //dc.SaveChanges();
                        //return base64value;
                        return "http://g0.pe/"+Uniqueid;

                    }
                    else
                    {
                        //UID_UIDRID = "NULL";
                        return "Referencenumber not valid";
                    }
                }
                else
                {
                    //UID_UIDRID = "NULL";
                    return "Please pass all values.";
                }
                }
                else
                {
                    //RID_UIDRIID = "NULL";
                    return "Please Pass valid APiKey";
                }
                }
            catch (Exception ex)
            {
                ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                error errobj = new error();
                //UID_UIDRID = "NULL";
                errobj.message = "Exception" + ex.Message;
                return JsonConvert.SerializeObject(errobj);
            }
       }
        public string IpAddress()
        {
            string strIpAddress;
            strIpAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (strIpAddress == null)
            {
                strIpAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            return strIpAddress;
        }
        public string GETRID(string CampaignName, string Password, string api_key)

         {
             try
             {
                 int clientid = 0; int Uni_RID = 0;
                 Client cl_obj = (from c in dc.Clients
                                 where c.APIKey == api_key
                                 select c).SingleOrDefault();
                // string ReferenceNumber = string.Format("{0}_{1:N}", cl_obj.Email, Guid.NewGuid());
                 Random randNum = new Random();
                 int r = randNum.Next(00000, 99999);
                 string ReferenceNumber = r.ToString("D5");
                  //if (CampaignName != "")
                  //{
                  //    Uni_RID = (from registree in dc.RIDDATAs
                  //               where registree.CampaignName.Trim() == CampaignName.Trim()
                  //               select registree.PK_Rid).SingleOrDefault();
                  //}
                 if (cl_obj != null)
                  {
                      //if (Uni_RID == 0)
                      //{
                          if (CampaignName.Trim() != "" && Password.Trim() != "")
                      {
                          //Uniqueid_RID = (from registree in dc.RIDDATAs
                          //                where registree.CampaignName.Trim() == CampaignName.Trim() &&
                          //                        registree.Pwd.Trim() == Password.Trim() && registree.FK_ClientId==clientid
                          //                select registree.PK_Rid).SingleOrDefault();

                          //if (Uniqueid_RID == 0)
                          //{
                          new DataInsertionBO().InsertRIDdata(CampaignName,ReferenceNumber, Password, cl_obj.PK_ClientID);
                              //Uniqueid_RID = (from registree in dc.RIDDATAs
                              //                where registree.ReferenceNumber.Trim() == ReferenceNumber.Trim() &&
                              //                registree.Pwd.Trim() == Password.Trim()
                              //                select registree.PK_Rid).SingleOrDefault();
                          //}

                          //if data found in uiddata table get data frim UIDRIDDATA 
                          //RID = (from uniqueid1 in dc.UIDandRIDDatas
                          //       where uniqueid1.TypeDiff == "2" &&
                          //       uniqueid1.UIDorRID == Uniqueid_RID
                          //       select uniqueid1.PK_UniqueId).SingleOrDefault();
                         // RID = new OperationsBO().GetUniqueid(Uniqueid_RID, "2");


                      }
                          else if (CampaignName.Trim() != "" && Password.Trim() == "")
                      {
                          //Uniqueid_RID = (from registree in dc.RIDDATAs
                          //                where registree.CampaignName.Trim() == ReferenceNumber.Trim() && registree.FK_ClientId==clientid
                          //                select registree.PK_Rid).SingleOrDefault();
                          //if (Uniqueid_RID == 0)
                          //{
                          new DataInsertionBO().InsertRIDdata(CampaignName,ReferenceNumber, "", cl_obj.PK_ClientID);
                              //Uniqueid_RID = (from registree in dc.RIDDATAs
                              //                where registree.ReferenceNumber.Trim() == ReferenceNumber.Trim()
                              //                select registree.PK_Rid).SingleOrDefault();
                          //}
                          //if data found in uiddata table get data frim UIDRIDDATA 
                          //RID = new OperationsBO().GetUniqueid(Uniqueid_RID, "2");

                      }
                      //if (Uniqueid_RID != 0)
                      //{

                      //    RID_UIDRIID = Uniqueid_RID.ToString();
                      //    string base64value = new ConvertionBO().LongToBase(Convert.ToInt64(RID));
                      //    //update record with base64 value
                      //    UIDandRIDData obj = (from u in dc.UIDandRIDDatas
                      //                         where u.PK_UniqueId == RID
                      //                         select u).SingleOrDefault();
                      //    obj.Base64Value = base64value;
                      //    dc.SaveChanges();
                      //    return base64value;

                      //}
                      //else
                      //{

                      //    RID_UIDRIID = "NULL";
                      //    return "ReferenceID not found";
                      //}

                          return "ReferenceNumber :"+ ReferenceNumber;
                //  }
                // else
                //{

                //  RID_UIDRIID = "NULL";
                //  return "CampaignName Already exists.";
                //}
                  }
                  else
                  {
                     // RID_UIDRIID = "NULL";
                      return "Please Pass valid APiKey";
                  }
             }
             catch (Exception ex)
             {
                 ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                 error errobj = new error();
                 //RID_UIDRIID = "NULL";
                 errobj.message = "Exception" + ex.Message;
                 return JsonConvert.SerializeObject(errobj);
             }
        }

//        public void Monitize(string Shorturl)

//         {
//             try
//             {
//                 string longurl = "";
//                 long decodedvalue = new ConvertionBO().BaseToLong(Shorturl);
//                 Uniqueid_SHORTURLDATA = Convert.ToInt32(decodedvalue);
//                 //Uniqueid_SHORTURLDATA = Convert.ToInt32(Shorturl);
//                 if (new OperationsBO().CheckUniqueid(Uniqueid_SHORTURLDATA, "1"))
//                 {
//                     int? Fk_UID = (from u in dc.UIDandRIDDatas
//                                    where u.PK_UniqueId == Uniqueid_SHORTURLDATA && u.TypeDiff=="1"
//                                    select u.UIDorRID).SingleOrDefault();
//                     int? FK_RID = (from u in dc.UIDDATAs
//                                   where u.PK_Uid == Fk_UID
//                                   select u.FK_RID).SingleOrDefault();
//                     int? FK_clientid = (from r in dc.RIDDATAs
//                                     where r.PK_Rid == FK_RID
//                                     select r.FK_ClientId).SingleOrDefault();
//                     //retrive ipaddress and browser
//                     string ipv4 = new ConvertionBO().GetIP4Address();
//                     string ipv6 = HttpContext.Current.Request.UserHostAddress;
//                     string browser = HttpContext.Current.Request.Browser.Browser;
//                     string browserversion = HttpContext.Current.Request.Browser.Version;
//                     string req_url = HttpContext.Current.Request.Url.ToString();
//                     //string[] header_array = HttpContext.Current.Request.Headers.AllKeys;
//                     string useragent = HttpContext.Current.Request.UserAgent;
//                     System.Collections.ArrayList browsers = HttpContext.Current.Request.Browser.Browsers;
//                     string hostname = HttpContext.Current.Request.UserHostName;
//                     string devicetype = HttpContext.Current.Request.Browser.Platform;
//                     string ismobiledevice = HttpContext.Current.Request.Browser.IsMobileDevice.ToString();
//                     //retrieve longurl from uid
//                     longurl = new OperationsBO().GetLongURL(Uniqueid_SHORTURLDATA);
//                     //if(longurl!=null)
//                     //    HttpContext.Current.Response.Redirect(longurl);

//                     //retrive city,country
//                     var City = ""; var Region = ""; var Country = ""; var CountryCode = ""; var url = "";
//                     //url = "http://freegeoip.net/json/" + "99.25.39.48";
//                     url = "http://freegeoip.net/json/" + ipv4;
//                     var request = System.Net.WebRequest.Create(url);
//                     using (WebResponse wrs = request.GetResponse())
//                     using (Stream stream = wrs.GetResponseStream())
//                     using (StreamReader reader = new StreamReader(stream))
//                     {
//                         string json = reader.ReadToEnd();
//                         var obj = JObject.Parse(json);
//                         City = (string)obj["city"];
//                         Region = (string)obj["region_name"];
//                         Country = (string)obj["country_name"];
//                         CountryCode = (string)obj["country_code"];
//                     }
//                     //retrive city,country if city country not found with ipv4
//                     if (City == "" && Country == "")
//                     {
//                         url = "http://freegeoip.net/json/" + ipv6;
//                         var request1 = System.Net.WebRequest.Create(url);
//                         using (WebResponse wrs = request1.GetResponse())
//                         using (Stream stream = wrs.GetResponseStream())
//                         using (StreamReader reader = new StreamReader(stream))
//                         {
//                             string json = reader.ReadToEnd();
//                             var obj = JObject.Parse(json);
//                             City = (string)obj["city"];
//                             Region = (string)obj["region_name"];
//                             Country = (string)obj["country_name"];
//                             CountryCode = (string)obj["country_code"];
//                         }
//                     }
//                     new DataInsertionBO().InsertShortUrldata(ipv4, ipv6, browser, browserversion, City, Region, Country, CountryCode, req_url, useragent, hostname, devicetype, ismobiledevice, Fk_UID, FK_RID, FK_clientid, Uniqueid_SHORTURLDATA);
//                 }
//                 WebOperationContext.Current.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Redirect;
//                 if (!longurl.StartsWith("http://") && !longurl.StartsWith("https://"))
//                     WebOperationContext.Current.OutgoingResponse.Headers.Add("Location", "http://" + longurl);
//                 else
//                     WebOperationContext.Current.OutgoingResponse.Headers.Add("Location", longurl);
//             }
//             catch (Exception ex)
//             {
//                 ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                 
//             }
//}
        //[DataContract]
        //public class CountsData
        //{
        //     [DataMember(EmitDefaultValue = false)]
        //    public List<DayWiseData> activity { get; set; }
        //    public List<CountryWiseData> locations { get; set; }
        //    public List<DeviceWiseData> devices { get; set; }
        //    public List<BrowserWiseData> platforms { get; set; }

        // }
        //[DataContract]
        //public class DayWiseData
        //{
        //   [DataMember(EmitDefaultValue = false, Name = "RequestedDate")]
        //    public string RequestedDateStr
        //    {
        //        get
        //        {
        //            if (this.RequestedDate.HasValue)
        //            {
        //               // return this.RequestedDate.Value.ToUniversalTime().ToString("s", CultureInfo.InvariantCulture);
        //                return this.RequestedDate.Value.ToString();
        //            }
        //            else
        //                return null;
        //        }
        //        set
        //        {
        //            // should implement this...
        //        }
        //    }

        //    //// this property is not transformed to JSon. Basically hidden
        //    [IgnoreDataMember]
        //    private DateTime? RequestedDate { get; set; }
           
        //   [DataMember(EmitDefaultValue = false)]
        //    public int RequestCount { get; set; }

        //}
        
        //public class CountryWiseData
        //{
        //    public string code { get; set; }
        //    public int value { get; set; }
        //    public string name { get; set; }
        //}
        //public class DeviceWiseData
        //{
        //    public string name { get; set; }
        //    public int y { get; set; }
        //}
        //public class BrowserWiseData
        //{
        //    public string name { get; set; }
        //    public int y { get; set; }
        //}
        //public class Summary
        //{
        //    public string url { get; set; }
        //    public int visits { get; set; }
        //    public int? unique_users { get; set; }
        //    public int total_users { get; set; }
        //}
        //public Stream GETAllCounts(string Fk_Uniqueid, string DateFrom, string DateTo)
        //{
        //    try 
        //    { 
        //    if (Fk_Uniqueid != "" && Fk_Uniqueid != null)
        //    {
        //        CountsData countobj = new CountsData();
        //        long decodedvalue = new ConvertionBO().BaseToLong(Fk_Uniqueid);
        //        Uniqueid_SHORTURLDATA = Convert.ToInt32(decodedvalue);
        //        int? rid = (from u in dc.UIDandRIDDatas
        //                    where u.PK_UniqueId == Uniqueid_SHORTURLDATA
        //                    select u.UIDorRID).SingleOrDefault();
        //        string connStr = ConfigurationManager.ConnectionStrings["shortenURLConnectionString"].ConnectionString;

        //        // create and open a connection object
        //        lSQLConn = new SqlConnection(connStr);
        //        SqlDataReader myReader;
        //        lSQLConn.Open();
        //        lSQLCmd.CommandType = CommandType.StoredProcedure;
        //        lSQLCmd.CommandText = "spGetALLCOUNTS1";
        //        //lSQLCmd.Parameters.Add(new SqlParameter("@Fk_Uniqueid", Uniqueid_SHORTURLDATA));
        //        lSQLCmd.Parameters.Add(new SqlParameter("@rid", rid));
        //        lSQLCmd.Parameters.Add(new SqlParameter("@DateFrom", DateFrom));
        //        lSQLCmd.Parameters.Add(new SqlParameter("@DateTo", DateTo));
        //        lSQLCmd.Connection = lSQLConn;
        //        myReader = lSQLCmd.ExecuteReader();


        //        List<DayWiseData> activity = ((IObjectContextAdapter)dc)
        //          .ObjectContext
        //          .Translate<DayWiseData>(myReader, "SHORTURLDATAs", MergeOption.AppendOnly).ToList();


        //        // Move to locations result 
        //        myReader.NextResult();
        //        List<CountryWiseData> locations = ((IObjectContextAdapter)dc)
        //       .ObjectContext
        //       .Translate<CountryWiseData>(myReader, "SHORTURLDATAs", MergeOption.AppendOnly).ToList();

        //        // Move to devices result 
        //        myReader.NextResult();
        //        List<DeviceWiseData> devices = ((IObjectContextAdapter)dc)
        //      .ObjectContext
        //      .Translate<DeviceWiseData>(myReader, "SHORTURLDATAs", MergeOption.AppendOnly).ToList();

        //        // Move to platforms result 
        //        myReader.NextResult();
        //        List<BrowserWiseData> platforms = ((IObjectContextAdapter)dc)
        //      .ObjectContext
        //      .Translate<BrowserWiseData>(myReader, "SHORTURLDATAs", MergeOption.AppendOnly).ToList();

                
        //        countobj.activity = activity;
        //        countobj.locations = locations;
        //        countobj.devices = devices;
        //        countobj.platforms = platforms;


        //        var s = new JavaScriptSerializer();
        //        string jsonClient = s.Serialize(countobj);

        //        WebOperationContext.Current.OutgoingResponse.ContentType =
        //            "application/json; charset=utf-8";
        //        return new MemoryStream(Encoding.UTF8.GetBytes(jsonClient));
        //    }
        //    else
        //    {
        //        string jsonClient = "please pass reference number";

        //        WebOperationContext.Current.OutgoingResponse.ContentType =
        //            "application/json; charset=utf-8";
        //        return new MemoryStream(Encoding.UTF8.GetBytes(jsonClient));
        //    }
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
        //        string jsonClient = "Exception occurs";

        //        WebOperationContext.Current.OutgoingResponse.ContentType =
        //            "application/json; charset=utf-8";
        //        return new MemoryStream(Encoding.UTF8.GetBytes(jsonClient));
        //    }
        //}

        //public Stream GETSummary(string Fk_Uniqueid)
        //{
        //    try
        //    {
        //        Summary s_obj = new Summary();
        //        long decodedvalue = new ConvertionBO().BaseToLong(Fk_Uniqueid);
        //        Uniqueid_SHORTURLDATA = Convert.ToInt32(decodedvalue);
        //        //Uniqueid_SHORTURLDATA = Convert.ToInt32(Fk_Uniqueid);
        //        int? rid = (from u in dc.UIDandRIDDatas
        //                    where u.PK_UniqueId == Uniqueid_SHORTURLDATA && u.TypeDiff == "2"
        //                    select u.UIDorRID).SingleOrDefault();
        //        var surl = (from ss in dc.SHORTURLDATAs
        //                    where ss.FK_RID == rid
        //                    select new { ss.Req_url }).ToList().Take(1);
        //        int totalVisits = dc.SHORTURLDATAs.Where(sh => sh.FK_RID == rid).Count();
        //        //int totalUsers = dc.SHORTURLDATAs.Where(sh => sh.FK_RID == rid).Count();
        //        int totalUsers = dc.UIDDATAs.Where(sh => sh.FK_RID == rid).Count();
        //        int? totalUniqueUsers = (from sh in dc.SHORTURLDATAs
        //                                 where sh.FK_RID == rid
        //                                 select sh.FK_Uid).Distinct().Count();
        //        s_obj.url = surl.Select(x => x.Req_url).SingleOrDefault();
        //        s_obj.visits = totalVisits;
        //        s_obj.total_users = totalUsers;
        //        s_obj.unique_users = totalUniqueUsers;
        //        var s = new JavaScriptSerializer();
        //        string jsonClient = s.Serialize(s_obj);

        //        WebOperationContext.Current.OutgoingResponse.ContentType =
        //            "application/json; charset=utf-8";
        //        return new MemoryStream(Encoding.UTF8.GetBytes(jsonClient));
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
        //        string jsonClient = "Exception occurs";

        //        WebOperationContext.Current.OutgoingResponse.ContentType =
        //            "application/json; charset=utf-8";
        //        return new MemoryStream(Encoding.UTF8.GetBytes(jsonClient));
        //    }
        //}


    //    public string Authenticate_Token(Stream api_key)
    //    {
    //        string parameters = new StreamReader(api_key).ReadToEnd(); //email1;
    //        JObject jObject = JObject.Parse(parameters);
    //        string apikey = (string)jObject["_apikey"];
    //        bool check = ValidateAPIKey(apikey);
    //        //need to return token
    //        string token = "";
    //        return token;
    //    }


    //    bool ValidateAPIKey(string key)
    //    {

    //        //string key = HttpContext.Current.Request.QueryString["apikey"];
    //        //if (string.IsNullOrEmpty(key))
    //        //   key = HttpContext.Current.Request.Headers["apikey"];
    //        if (!string.IsNullOrEmpty(key))
    //        {
    //            Guid apiKey;
    //            Guid hardKey = new Guid("F5D14784-2D9E-4F57-A69E-50FB0551940A");
    //            // Convert the string into a Guid and validate it
    //            if (!Guid.TryParse(key, out apiKey) || !apiKey.Equals(hardKey)) //we are not validating yet just hard code one guid
    //            {
    //                //throw new System.ServiceModel.Web.WebFaultException<string>("Invalid API Key", HttpStatusCode.Forbidden);
    //                return false;
    //            }
    //            else
    //                return false;
    //        }
    //        else
    //            return false;
    //            //throw new System.ServiceModel.Web.WebFaultException<string>("Please Provide  API Key", HttpStatusCode.Forbidden);

    //    }


    //    public string IsAuthorized(string username, string password, string apikey)
    //    {
    //        MembershipUser user = Membership.GetAllUsers()[username];

    //        Configuration config = ConfigurationManager.OpenExeConfiguration(HostingEnvironment.MapPath("~") + "\\web.config");

    //        SessionStateSection sessionStateConfig = (SessionStateSection)config.SectionGroups.Get("system.web").Sections.Get("sessionState");

    //        InMemoryInstances instance = InMemoryInstances.Instance;
    //        // Check for session state timeout (could use a constant here instead if you don't want to rely on the config).
    //        if (user.LastLoginDate.AddMinutes(sessionStateConfig.Timeout.TotalMinutes) < DateTime.Now)
    //        {
    //            // Remove token from the singleton in this instance, effectively a logout.                
    //            instance.removeTokenUserPair(username);
    //            return "User Unauthorized - login has expired!";
    //        }
    //        if (!instance.checkTokenUserPair(username, apikey))
    //            return "User Unauthorized - not a valid token!";

    //        return "Success - User is Authorized!";

    //    }
    //    public string AuthenticateUser(string username, string encryptedPassword)
    //    {
    //        //string pwd = Decrypt(encryptedPassword);
    //        string pwd = "";
    //        if (Membership.ValidateUser(username, pwd))
    //        {
    //            // Not sure if this is actually needed, but reading some documentation I think it's a safe bet to do here anyway.
    //            Membership.GetAllUsers()[username].LastLoginDate = DateTime.Now;

    //            // Send back a token!
    //            Guid token = Guid.NewGuid();

    //            // Store a token for this username.
    //            InMemoryInstances instance = InMemoryInstances.Instance;
    //            instance.removeTokenUserPair(username); //Because we don't implement a "Logout" method.
    //            instance.addTokenUserPair(username, token.ToString());

    //            return token.ToString();
    //        }

    //        return "Error - User was not able to be validated!";
    //    }



    //     public class InMemoryInstances
    //{
    //    private static volatile InMemoryInstances instance;
    //    private static object syncRoot = new Object();

    //    private Dictionary<string, string> usersAndTokens = null;

    //    private InMemoryInstances() 
    //    {
    //        usersAndTokens = new Dictionary<string, string>();
    //    }

    //    public static InMemoryInstances Instance
    //    {
    //        get 
    //        {
    //            if (instance == null) 
    //            {
    //                lock (syncRoot)                  
    //                {
    //                    if (instance == null) 
    //                        instance = new InMemoryInstances();
    //                }
    //            }

    //            return instance;
    //        }
    //    }

    //    public void addTokenUserPair(string username, string token)
    //    {
    //        usersAndTokens.Add(username, token);
    //    }

    //    public bool checkTokenUserPair(string username, string token)
    //    {
    //        if (usersAndTokens.ContainsKey(username)) {
    //            string value = usersAndTokens[username];
    //            if (value.Equals(token))
    //                return true;
    //        }

    //        return false;
    //    }

    //    public void removeTokenUserPair(string username)
    //    {
    //        usersAndTokens.Remove(username);
    //    }
    //}








            /// <summary>
            /// Initializes a new instance of the REST
            /// </summary>
            //public Service1()
            //{
            //    ValidateKey(); //since we have InstanceContextMode = InstanceContextMode.PerCall, this is called per every api call yay!!!

            //}

            //void ValidateKey()
            //{

            //    string key = HttpContext.Current.Request.QueryString["apikey"];
            //    if (string.IsNullOrEmpty(key))
            //        key = HttpContext.Current.Request.Headers["apikey"];
            //    if (!string.IsNullOrEmpty(key))
            //    {
            //        Guid apiKey;
            //        Guid hardKey = new Guid("F5D14784-2D9E-4F57-A69E-50FB0551940A");
            //        // Convert the string into a Guid and validate it
            //        if (!Guid.TryParse(key, out apiKey) || !apiKey.Equals(hardKey)) //we are not validating yet just hard code one guid
            //        {
            //            throw new System.ServiceModel.Web.WebFaultException<string>("Invalid API Key", HttpStatusCode.Forbidden);
            //        }
            //    }
            //    else
            //        throw new System.ServiceModel.Web.WebFaultException<string>("Please Provide  API Key", HttpStatusCode.Forbidden);

            //}


    }
}
