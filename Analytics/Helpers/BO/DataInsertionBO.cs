using Analytics.Helpers.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Analytics.Helpers.BO
{
    public class DataInsertionBO
    {
        shortenURLEntities dc = new shortenURLEntities();
        SqlConnection lSQLConn = null;
        SqlCommand lSQLCmd = new SqlCommand();
        string connStr = "";
        public void InsertUIDdata(string referencenumber, string longurl, string mobilenumber)
        {
            connStr = ConfigurationManager.ConnectionStrings["shortenURLConnectionString"].ConnectionString;
            try
            {
                // create and open a connection object
                lSQLConn = new SqlConnection(connStr);
                lSQLConn.Open();
                lSQLCmd.CommandType = CommandType.StoredProcedure;
                lSQLCmd.CommandText = "InsertUIDData";
                lSQLCmd.Parameters.Add(new SqlParameter("@referencenumber", referencenumber));
                lSQLCmd.Parameters.Add(new SqlParameter("@longurl", longurl));
                lSQLCmd.Parameters.Add(new SqlParameter("@mobilenumber", mobilenumber));
                lSQLCmd.Connection = lSQLConn;
                lSQLCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
            }
            finally
            {
                lSQLCmd.Dispose();
                lSQLConn.Close();
            }
        }
        public void InsertRIDdata(string referencenumber, string pwd)
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
                lSQLCmd.CommandType = CommandType.StoredProcedure;
                lSQLCmd.CommandText = "InsertRIDData";
                lSQLCmd.Parameters.Add(new SqlParameter("@referencenumber", referencenumber));
                lSQLCmd.Parameters.Add(new SqlParameter("@pwd", pwd));
                lSQLCmd.Connection = lSQLConn;
                lSQLCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());

            }
            finally
            {
                lSQLCmd.Dispose();
                lSQLConn.Close();
            }
        }
        public void InsertShortUrldata(string ipv4, string ipv6, string browser, string browser_version, string city, string Region, string country, string countrycode, string req_url, string useragent, string hostname, string devicetype, string ismobiledevice, int uniqueid)
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
                lSQLCmd.CommandType = CommandType.StoredProcedure;
                lSQLCmd.CommandText = "InsertSHORTURLData";
                lSQLCmd.Parameters.Add(new SqlParameter("@ipv4", ipv4));
                lSQLCmd.Parameters.Add(new SqlParameter("@ipv6", ipv6));
                lSQLCmd.Parameters.Add(new SqlParameter("@browser", browser));
                lSQLCmd.Parameters.Add(new SqlParameter("@browser_version", browser_version));
                lSQLCmd.Parameters.Add(new SqlParameter("@city", city));
                lSQLCmd.Parameters.Add(new SqlParameter("@Region", Region));
                lSQLCmd.Parameters.Add(new SqlParameter("@country", country));
                lSQLCmd.Parameters.Add(new SqlParameter("@countrycode", countrycode));
                lSQLCmd.Parameters.Add(new SqlParameter("@req_url", req_url));
                lSQLCmd.Parameters.Add(new SqlParameter("@useragent", useragent));
                lSQLCmd.Parameters.Add(new SqlParameter("@hostname", hostname));
                lSQLCmd.Parameters.Add(new SqlParameter("@DeviceType", devicetype));
                lSQLCmd.Parameters.Add(new SqlParameter("@IsMobiledevice", ismobiledevice));
                lSQLCmd.Parameters.Add(new SqlParameter("@uniqueid", uniqueid));
                lSQLCmd.Connection = lSQLConn;
                lSQLCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());

            }
            finally
            {
                lSQLCmd.Dispose();
                lSQLConn.Close();
            }
        }

    }
}