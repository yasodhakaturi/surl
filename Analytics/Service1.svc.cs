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
namespace Analytics
{
    
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        shortenURLEntities dc = new shortenURLEntities();
       
        public string GETUID(string referencenumber, string longurl, string mobilenumber, out string uid)
        {
            int uniquieid = 0; int uid_uid = 0; UIDandRIDData obj = new UIDandRIDData();
            if (referencenumber.Trim() != "" && longurl.Trim() != "" && mobilenumber.Trim() != "")
            {

                uid_uid = (from registree in dc.UIDDATAs
                           where registree.ReferenceNumber.Trim() == referencenumber.Trim() &&
                           registree.Longurl.Trim() == longurl.Trim() &&
                           registree.MobileNumber.Trim() == mobilenumber.Trim()
                           select registree.PK_Uid).SingleOrDefault();
                //if data found in UIDDATA insert data into UIDDATA 
                if (uid_uid == 0)
                {
                    insertUIDdata(referencenumber, longurl, mobilenumber);
                    uid_uid = (from registree in dc.UIDDATAs
                               where registree.ReferenceNumber.Trim() == referencenumber.Trim() &&
                               registree.Longurl.Trim() == longurl.Trim() &&
                               registree.MobileNumber.Trim() == mobilenumber.Trim()
                               select registree.PK_Uid).SingleOrDefault();
                }
                
                //if data found in uiddata table get data frim UIDRIDDATA 
                    uniquieid = (from uniqueid1 in dc.UIDandRIDDatas
                                 where uniqueid1.TypeDiff == "1" &&
                                 uniqueid1.UIDorRID == uid_uid
                                 select uniqueid1.PK_UniqueId).SingleOrDefault();
                    //if (uniquieid == 0)
                    //{
                    //    obj.TypeDiff = "1";
                    //    obj.UIDorRID = uniquieid;
                    //    dc.UIDandRIDDatas.Add(obj);
                    //    dc.SaveChanges();
                    //    uniquieid = (from uniqueid1 in dc.UIDandRIDDatas
                    //                 where uniqueid1.TypeDiff == "1" &&
                    //                 uniqueid1.UIDorRID == uid_uid
                    //                 select uniqueid1.ID).SingleOrDefault();
                    //}

                    //var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(uniquieid.ToString());
                    //return Convert.ToBase64String(plainTextBytes);
                    uid = uniquieid.ToString();    
                    string base64value = LongToBase(Convert.ToInt64(uniquieid));
                    return base64value;
                
            }
            else
            {
                uid = "NULL";
                return "uniqueid not found";
            }
       }

        public string GETRID(string referencenumber, string Password, out string rid)

     {
         int uniquieid = 0; int rid_rid = 0;
            if (referencenumber.Trim() != "" && Password.Trim() != "")
            {
                rid_rid = (from registree in dc.RIDDATAs
                             where registree.ReferenceNumber.Trim() == referencenumber.Trim() &&
                                   registree.Pwd.Trim() == Password.Trim()
                             select registree.PK_Rid).SingleOrDefault();
                if (rid_rid == 0)
                {
                     insertRIDdata(referencenumber, Password);
                    rid_rid = (from registree in dc.RIDDATAs
                               where registree.ReferenceNumber.Trim() == referencenumber.Trim() &&
                               registree.Pwd.Trim() == Password.Trim() 
                               select registree.PK_Rid).SingleOrDefault();
                }

                //if data found in uiddata table get data frim UIDRIDDATA 
                uniquieid = (from uniqueid1 in dc.UIDandRIDDatas
                             where uniqueid1.TypeDiff == "2" &&
                             uniqueid1.UIDorRID == rid_rid
                             select uniqueid1.PK_UniqueId).SingleOrDefault();
                 
                }
            else if(referencenumber.Trim() != "" && Password.Trim() == "")
            {
                rid_rid = (from registree in dc.RIDDATAs
                             where registree.ReferenceNumber.Trim() == referencenumber.Trim() 
                                   select registree.PK_Rid).SingleOrDefault();
                if (rid_rid == 0)
                {
                    insertRIDdata(referencenumber, "");
                    rid_rid = (from registree in dc.RIDDATAs
                               where registree.ReferenceNumber.Trim() == referencenumber.Trim() 
                               select registree.PK_Rid).SingleOrDefault();
                }
                //if data found in uiddata table get data frim UIDRIDDATA 
                uniquieid = (from uniqueid1 in dc.UIDandRIDDatas
                             where uniqueid1.TypeDiff == "2" &&
                             uniqueid1.UIDorRID == rid_rid
                             select uniqueid1.PK_UniqueId).SingleOrDefault();
               
            }
            if (uniquieid != 0)
            {
                
                rid = uniquieid.ToString();
                string base64value = LongToBase(Convert.ToInt64(uniquieid));
                return base64value;
                //var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(uniquieid.ToString());
                //return Convert.ToBase64String(plainTextBytes);
            }
            else
            {
                
                rid = "NULL";
                return "ReferenceID not found";
            }


        }


        void insertUIDdata(string referencenumber, string longurl, string mobilenumber)
        {
            SqlConnection lSQLConn = null;
            SqlCommand lSQLCmd = new SqlCommand();
            string connStr = "";
            connStr = ConfigurationManager.ConnectionStrings["shortenURLConnectionString"].ConnectionString;
            try
            {
                // create and open a connection object
                lSQLConn = new SqlConnection(connStr);
                lSQLConn.Open();
                //The CommandType must be StoredProcedure if we are using an ExecuteScalar
                lSQLCmd.CommandType = CommandType.StoredProcedure;
                lSQLCmd.CommandText = "InsertUIDData";
                lSQLCmd.Parameters.Add(new SqlParameter("@referencenumber", referencenumber));
                lSQLCmd.Parameters.Add(new SqlParameter("@longurl", longurl));
                lSQLCmd.Parameters.Add(new SqlParameter("@mobilenumber", mobilenumber));
                lSQLCmd.Connection = lSQLConn;
                //Executes the SP and returns the single select output to a variable
                lSQLCmd.ExecuteNonQuery();
            }
            catch (Exception Exc)
            {
                
            }
            finally
            {
                lSQLCmd.Dispose();
                lSQLConn.Close();
            }
        }
        void insertRIDdata(string referencenumber, string pwd)
        {
            SqlConnection lSQLConn = null;
            SqlCommand lSQLCmd = new SqlCommand();
            string connStr = "";
            connStr = ConfigurationManager.ConnectionStrings["shortenURLConnectionString"].ConnectionString;
            try
            {
                // create and open a connection object
                lSQLConn = new SqlConnection(connStr);
                lSQLConn.Open();
                //The CommandType must be StoredProcedure if we are using an ExecuteScalar
                lSQLCmd.CommandType = CommandType.StoredProcedure;
                lSQLCmd.CommandText = "InsertRIDData";
                lSQLCmd.Parameters.Add(new SqlParameter("@referencenumber", referencenumber));
                lSQLCmd.Parameters.Add(new SqlParameter("@pwd", pwd));
                lSQLCmd.Connection = lSQLConn;
                //Executes the SP and returns the single select output to a variable
                lSQLCmd.ExecuteNonQuery();
            }
            catch (Exception Exc)
            {

            }
            finally
            {
                lSQLCmd.Dispose();
                lSQLConn.Close();
            }
        }
        void insertShortUrldata(string ipv4, string ipv6, string browser, string browser_version, string city,string Region, string country, string countrycode, string req_url, string useragent, string hostname, string devicetype, string ismobiledevice,int uniqueid)
        {
            SqlConnection lSQLConn = null;
            SqlCommand lSQLCmd = new SqlCommand();
            string connStr = "";
            connStr = ConfigurationManager.ConnectionStrings["shortenURLConnectionString"].ConnectionString;
            try
            {
                // create and open a connection object
                lSQLConn = new SqlConnection(connStr);
                lSQLConn.Open();
                //The CommandType must be StoredProcedure if we are using an ExecuteScalar
                lSQLCmd.CommandType = CommandType.StoredProcedure;
                lSQLCmd.CommandText = "InsertSHORTURLData";
                lSQLCmd.Parameters.Add(new SqlParameter("@ipv4", ipv4));
                lSQLCmd.Parameters.Add(new SqlParameter("@ipv6", ipv6));
                lSQLCmd.Parameters.Add(new SqlParameter("@browser", browser));
                lSQLCmd.Parameters.Add(new SqlParameter("@browser_version", browser_version));
                lSQLCmd.Parameters.Add(new SqlParameter("@city", city));
                lSQLCmd.Parameters.Add(new SqlParameter("@Region", Region));
                lSQLCmd.Parameters.Add(new SqlParameter("@country", country));
                lSQLCmd.Parameters.Add(new SqlParameter("@countrycode",countrycode));
                lSQLCmd.Parameters.Add(new SqlParameter("@req_url", req_url));
                lSQLCmd.Parameters.Add(new SqlParameter("@useragent", useragent));
                lSQLCmd.Parameters.Add(new SqlParameter("@hostname", hostname));
                lSQLCmd.Parameters.Add(new SqlParameter("@DeviceType", devicetype));
                lSQLCmd.Parameters.Add(new SqlParameter("@IsMobiledevice", ismobiledevice));
                lSQLCmd.Parameters.Add(new SqlParameter("@uniqueid", uniqueid));
                lSQLCmd.Connection = lSQLConn;
                //Executes the SP and returns the single select output to a variable
                lSQLCmd.ExecuteNonQuery();
            }
            catch (Exception Exc)
            {

            }
            finally
            {
                lSQLCmd.Dispose();
                lSQLConn.Close();
            }
        }

        private static readonly char[] BaseChars =
         "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz./,".ToCharArray();
        private static readonly Dictionary<char, int> CharValues = BaseChars
                   .Select((c, i) => new { Char = c, Index = i })
                   .ToDictionary(c => c.Char, c => c.Index);

        public static string LongToBase(long value)
        {
            long targetBase = BaseChars.Length;
            // Determine exact number of characters to use.
            char[] buffer = new char[Math.Max(
                       (int)Math.Ceiling(Math.Log(value + 1, targetBase)), 1)];

            var i = (long)buffer.Length;
            do
            {
                buffer[--i] = BaseChars[value % targetBase];
                value = value / targetBase;
            }
            while (value > 0);
            return new string(buffer);
        }

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
        
        private static string GetIP4Address()
        {
            string IP4Address = String.Empty;

            foreach (IPAddress IPA in Dns.GetHostAddresses(HttpContext.Current.Request.UserHostAddress))
            {
                if (IPA.AddressFamily.ToString() == "InterNetwork")
                {
                    IP4Address = IPA.ToString();
                    break;
                }
            }

            if (IP4Address != String.Empty)
            {
                return IP4Address;
            }

            foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (IPA.AddressFamily.ToString() == "InterNetwork")
                {
                    IP4Address = IPA.ToString();
                    break;
                }
            }

            return IP4Address;
        }

        private bool checkuniqueid(int uid)
        {
            bool check;
            UIDandRIDData obj = (from uniid in dc.UIDandRIDDatas
                              
                              where uniid.PK_UniqueId == uid
                              select uniid).SingleOrDefault();
            if (obj != null)
            {
                check = true;
                return check;
            }
            else 
            { check = false; 
              return check; 
            }
        }
        public void Monitize(string shorturl)

         {

        //string base64value=LongToBase(10);
        //long decodedvalue = BaseToLong(base64value);
        string longurl = "";
        long decodedvalue = BaseToLong(shorturl);
        int uid_shorturl = Convert.ToInt32(decodedvalue);
        if (checkuniqueid(uid_shorturl))
        {
            //retrive ipaddress and browser
            string ipv4 = GetIP4Address();
            string ipv6 = HttpContext.Current.Request.UserHostAddress;
            string browser = HttpContext.Current.Request.Browser.Browser;
            string browserversion = HttpContext.Current.Request.Browser.Version;
            string req_url = HttpContext.Current.Request.Url.ToString();
            //string[] header_array = HttpContext.Current.Request.Headers.AllKeys;
            string useragent =  HttpContext.Current.Request.UserAgent;
            System.Collections.ArrayList browsers = HttpContext.Current.Request.Browser.Browsers;
            string hostname = HttpContext.Current.Request.UserHostName;
            string devicetype = HttpContext.Current.Request.Browser.Platform;
            string ismobiledevice = HttpContext.Current.Request.Browser.IsMobileDevice.ToString();
            //retrieve longurl from uid
             longurl = (from uniid in dc.UIDandRIDDatas
                              join uidtable in dc.UIDDATAs on uniid.UIDorRID equals uidtable.PK_Uid
                              where uniid.PK_UniqueId == uid_shorturl
                              select uidtable.Longurl).SingleOrDefault();
            //if(longurl!=null)
            //    HttpContext.Current.Response.Redirect(longurl);

            //retrive city,country
            var City = "";var Region=""; var Country = ""; var CountryCode = ""; var url = "";
            url = "http://freegeoip.net/json/" + "99.25.39.48";
            //url = "http://freegeoip.net/json/" + ipv4;
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
            insertShortUrldata(ipv4, ipv6, browser, browserversion, City, Region, Country, CountryCode, req_url, useragent, hostname, devicetype,ismobiledevice, uid_shorturl);
        }
        WebOperationContext.Current.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Redirect;
        if (!longurl.StartsWith("http://") && !longurl.StartsWith("https://"))
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Location", "http://" + longurl);
        else
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Location", longurl);

}


    
    
    }
}
//public class AnalyticsServiceHostFactory : ServiceHostFactory
//{
//    protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
//    {
//        // Specify the exact URL of your web service
//        //Uri webServiceAddress = new Uri("http://moozup.com/Service1.svc");
//        // Uri webServiceAddress = new Uri("http://dev.moozup.com/Services/MoozupService.svc");
//        Uri webServiceAddress = new Uri("http://localhost:55492/Service1.svc");

//        ServiceHost webServiceHost = new ServiceHost(serviceType, webServiceAddress);
//        return webServiceHost;
//    }
//}
