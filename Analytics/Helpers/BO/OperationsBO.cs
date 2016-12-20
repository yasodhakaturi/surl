using Analytics.Helpers.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
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
                               where uniid.PK_UniqueId == Uniqueid_UIDRID 
                               select new PWDDataBO
                             {
                                 typediff=uniid.TypeDiff,
                                 UIDorRID=uniid.UIDorRID
                             }).SingleOrDefault();
                string pwd = (from r in dc.RIDDATAs
                              where r.PK_Rid == obj.UIDorRID && obj.typediff == "2"
                              select r.Pwd).SingleOrDefault();
                obj.pwd = pwd;
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
                    int? Fk_UID = (from u in dc.UIDandRIDDatas
                                   where u.PK_UniqueId == Uniqueid_SHORTURLDATA && u.TypeDiff == "1"
                                   select u.UIDorRID).SingleOrDefault();
                    int? FK_RID = (from u in dc.UIDDATAs
                                   where u.PK_Uid == Fk_UID
                                   select u.FK_RID).SingleOrDefault();
                    int? FK_clientid = (from r in dc.RIDDATAs
                                        where r.PK_Rid == FK_RID
                                        select r.FK_ClientId).SingleOrDefault();
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
                    new DataInsertionBO().InsertShortUrldata(ipv4, ipv6, browser, browserversion, City, Region, Country, CountryCode, req_url, useragent, hostname, devicetype, ismobiledevice,Fk_UID,FK_RID,FK_clientid, Uniqueid_SHORTURLDATA);
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


        public string GetApiKey()
        {
            string APIKey="";
            using (var cryptoProvider = new RNGCryptoServiceProvider())
            {
                byte[] secretKeyByteArray = new byte[32]; //256 bit
                cryptoProvider.GetBytes(secretKeyByteArray);
                APIKey = Convert.ToBase64String(secretKeyByteArray);
            }
            return APIKey;
        }
        public bool CheckClientEmail(string email)
        {
            Client obj = new Client();bool check=false;
            obj = dc.Clients.Where(c => c.Email == email).Select(x => x).SingleOrDefault();
            if (obj != null)
                check = true;
            //else
            //    check = false;
            return check;

        }

        public void UpdateClient(string username,string email,bool? isactive)
        {
            try
            {
                //string strQuery = "Update MMPersonMessage set Status = 'R' where FKMessageId = (" + messageid + ") and FKToPersonId = (" + personid + ")";

                string strQuery = "Update Client set UserName = '" + username + "' ,IsActive='" + isactive + "' where Email ='" + email + "'";
                SqlHelper.ExecuteNonQuery(Helper.ConnectionString, CommandType.Text, strQuery);
            }
            catch (Exception ex)
            {
                ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
            }
        }


        public bool CheckReferenceNumber(string referencenumber)
        {
            RIDDATA obj = new RIDDATA(); bool check = false;
            obj = dc.RIDDATAs.Where(c => c.ReferenceNumber == referencenumber).Select(x => x).SingleOrDefault();
            if (obj != null)
                check = true;
            //else
            //    check = false;
            return check;

        }

        public void UpdateCampaign(string referencenumber, string password, bool? isactive)
        {
            try
            {
                string strQuery = "Update RIDDATA set Pwd=" + password + ",IsActive=" + isactive + " where ReferenceNumber =" + referencenumber + "";
                SqlHelper.ExecuteNonQuery(Helper.ConnectionString, CommandType.Text, strQuery);
            }
            catch (Exception ex)
            {
                ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
            }
        }

        //public CountsData GetCountsData(SqlDataReader myReader,string filterBy,string DateFrom,string DateTo)
        //{

        //    CountsData countobj = new CountsData();
        //    if (filterBy != "" && DateFrom == "" && DateTo == "")
        //    {
        //        if (filterBy == "Year")
        //        {
        //            List<YearData> YearsDataObj = ((IObjectContextAdapter)dc)
        //                                .ObjectContext
        //                                .Translate<YearData>(myReader, "SHORTURLDATAs", MergeOption.AppendOnly).ToList();
        //            //countobj.YearsData = YearsDataObj;
                   
        //        }
        //        if (filterBy == "Month")
        //        {
        //            List<MonthData> MonthDataObj = ((IObjectContextAdapter)dc)
        //                                .ObjectContext
        //                                .Translate<MonthData>(myReader, "SHORTURLDATAs", MergeOption.AppendOnly).ToList();
        //            //countobj.MonthsData = MonthDataObj;
        //        }
        //        if (filterBy == "CurrentMonth")
        //        {
        //            List<CurrentMonthData> CurrentMonthDataObj = ((IObjectContextAdapter)dc)
        //             .ObjectContext
        //             .Translate<CurrentMonthData>(myReader, "SHORTURLDATAs", MergeOption.AppendOnly).ToList();

        //            //countobj.CurrentMonthData = CurrentMonthDataObj;
        //        }
        //        if (filterBy == "Today")
        //        {
        //            List<TodayData> TodayDataObj = ((IObjectContextAdapter)dc)
        //            .ObjectContext
        //            .Translate<TodayData>(myReader, "SHORTURLDATAs", MergeOption.AppendOnly).ToList();
        //            //countobj.TodaysData = TodayDataObj;
        //        }
        //    }

        //    else if (filterBy == "" && DateFrom == "" && DateTo == "")
        //    {
        //        List<YearData> YearsDataObj = ((IObjectContextAdapter)dc)
        //            .ObjectContext
        //            .Translate<YearData>(myReader, "SHORTURLDATAs", MergeOption.AppendOnly).ToList();


        //        // Move to Month result 
        //        myReader.NextResult();
        //        List<MonthData> MonthDataObj = ((IObjectContextAdapter)dc)
        //            .ObjectContext
        //            .Translate<MonthData>(myReader, "SHORTURLDATAs", MergeOption.AppendOnly).ToList();

        //        // Move to CurrentMonth result 
        //        myReader.NextResult();
        //        List<CurrentMonthData> CurrentMonthDataObj = ((IObjectContextAdapter)dc)
        //            .ObjectContext
        //            .Translate<CurrentMonthData>(myReader, "SHORTURLDATAs", MergeOption.AppendOnly).ToList();

        //        // Move to TodayData result 
        //        myReader.NextResult();
        //        List<TodayData> TodayDataObj = ((IObjectContextAdapter)dc)
        //            .ObjectContext
        //            .Translate<TodayData>(myReader, "SHORTURLDATAs", MergeOption.AppendOnly).ToList();

        //        // Move to YesterDayData result 
        //        myReader.NextResult();
        //        List<YesterDayData> YesterDayDataObj = ((IObjectContextAdapter)dc)
        //            .ObjectContext
        //            .Translate<YesterDayData>(myReader, "SHORTURLDATAs", MergeOption.AppendOnly).ToList();

        //        // Move to Last7DaysData result 
        //        myReader.NextResult();
        //        List<Last7DaysData> Last7DaysDataObj = ((IObjectContextAdapter)dc)
        //            .ObjectContext
        //            .Translate<Last7DaysData>(myReader, "SHORTURLDATAs", MergeOption.AppendOnly).ToList();

        //        // Move to BrowsersData result 
        //        myReader.NextResult();
        //        List<BrowsersData> BrowsersDataObj = ((IObjectContextAdapter)dc)
        //            .ObjectContext
        //            .Translate<BrowsersData>(myReader, "SHORTURLDATAs", MergeOption.AppendOnly).ToList();

        //        // Move to CountryData result 
        //        myReader.NextResult();
        //        List<CountryData> CountryDataObj = ((IObjectContextAdapter)dc)
        //            .ObjectContext
        //            .Translate<CountryData>(myReader, "SHORTURLDATAs", MergeOption.AppendOnly).ToList();

        //        // Move to CityData result 
        //        myReader.NextResult();
        //        List<CityData> CityDataObj = ((IObjectContextAdapter)dc)
        //            .ObjectContext
        //            .Translate<CityData>(myReader, "SHORTURLDATAs", MergeOption.AppendOnly).ToList();

        //        // Move to RegionData result 
        //        myReader.NextResult();
        //        List<RegionData> RegionDataObj = ((IObjectContextAdapter)dc)
        //            .ObjectContext
        //            .Translate<RegionData>(myReader, "SHORTURLDATAs", MergeOption.AppendOnly).ToList();

        //        // Move to DeviceTypeData result 
        //        myReader.NextResult();
        //        List<DeviceTypeData> DeviceTypeDataObj = ((IObjectContextAdapter)dc)
        //            .ObjectContext
        //            .Translate<DeviceTypeData>(myReader, "SHORTURLDATAs", MergeOption.AppendOnly).ToList();


        //        //countobj.YearsData = YearsDataObj;
        //        //countobj.MonthsData = MonthDataObj;
        //        //countobj.CurrentMonthData = CurrentMonthDataObj;
        //        //countobj.TodaysData = TodayDataObj;
        //        //countobj.YesterdaysData = YesterDayDataObj;
        //        //countobj.Last7DaysData = Last7DaysDataObj;
        //        //countobj.BrowsersData = BrowsersDataObj;
        //        //countobj.CountriesData = CountryDataObj;
        //        //countobj.CitiesData = CityDataObj;
        //        //countobj.RegionsData = RegionDataObj;
        //        //countobj.DevicesData = DeviceTypeDataObj;
        //    }
        //    return countobj;
        //}

    
    }
}