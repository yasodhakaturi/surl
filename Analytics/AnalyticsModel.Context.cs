﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Analytics
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class shortenURLEntities : DbContext
    {
        public shortenURLEntities()
            : base("name=shortenURLEntities")
        {
            var adapter = (IObjectContextAdapter)this;
            var objectContext = adapter.ObjectContext;
            objectContext.CommandTimeout = 4 * 60;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BatchUploadData> BatchUploadDatas { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ErrorLog> ErrorLogs { get; set; }
        public virtual DbSet<LoginHistory> LoginHistories { get; set; }
        public virtual DbSet<RIDDATA> RIDDATAs { get; set; }
        public virtual DbSet<SHORTURLDATA> SHORTURLDATAs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<UIDDATA> UIDDATAs { get; set; }
    
        [DbFunction("shortenURLEntities", "fnSplitStringAsTable")]
        public virtual IQueryable<fnSplitStringAsTable_Result> fnSplitStringAsTable(string inputString, string delimiter)
        {
            var inputStringParameter = inputString != null ?
                new ObjectParameter("inputString", inputString) :
                new ObjectParameter("inputString", typeof(string));
    
            var delimiterParameter = delimiter != null ?
                new ObjectParameter("delimiter", delimiter) :
                new ObjectParameter("delimiter", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<fnSplitStringAsTable_Result>("[shortenURLEntities].[fnSplitStringAsTable](@inputString, @delimiter)", inputStringParameter, delimiterParameter);
        }
    
        [DbFunction("shortenURLEntities", "Split")]
        public virtual IQueryable<Split_Result> Split(string @string, string delimiter)
        {
            var stringParameter = @string != null ?
                new ObjectParameter("String", @string) :
                new ObjectParameter("String", typeof(string));
    
            var delimiterParameter = delimiter != null ?
                new ObjectParameter("Delimiter", delimiter) :
                new ObjectParameter("Delimiter", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<Split_Result>("[shortenURLEntities].[Split](@String, @Delimiter)", stringParameter, delimiterParameter);
        }
    
        [DbFunction("shortenURLEntities", "Split_cte")]
        public virtual IQueryable<Split_cte_Result> Split_cte(string list, string delimiter)
        {
            var listParameter = list != null ?
                new ObjectParameter("List", list) :
                new ObjectParameter("List", typeof(string));
    
            var delimiterParameter = delimiter != null ?
                new ObjectParameter("Delimiter", delimiter) :
                new ObjectParameter("Delimiter", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<Split_cte_Result>("[shortenURLEntities].[Split_cte](@List, @Delimiter)", listParameter, delimiterParameter);
        }
    
        [DbFunction("shortenURLEntities", "Split1")]
        public virtual IQueryable<Split1_Result> Split1(string @string, string delimiter)
        {
            var stringParameter = @string != null ?
                new ObjectParameter("String", @string) :
                new ObjectParameter("String", typeof(string));
    
            var delimiterParameter = delimiter != null ?
                new ObjectParameter("Delimiter", delimiter) :
                new ObjectParameter("Delimiter", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<Split1_Result>("[shortenURLEntities].[Split1](@String, @Delimiter)", stringParameter, delimiterParameter);
        }
    
        public virtual int InsertintoUIDRID(string typediff, Nullable<int> uidorrid)
        {
            var typediffParameter = typediff != null ?
                new ObjectParameter("typediff", typediff) :
                new ObjectParameter("typediff", typeof(string));
    
            var uidorridParameter = uidorrid.HasValue ?
                new ObjectParameter("uidorrid", uidorrid) :
                new ObjectParameter("uidorrid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertintoUIDRID", typediffParameter, uidorridParameter);
        }
    
        public virtual int InsertRIDData(string campaignName, string referencenumber, string pwd, Nullable<int> clientid)
        {
            var campaignNameParameter = campaignName != null ?
                new ObjectParameter("CampaignName", campaignName) :
                new ObjectParameter("CampaignName", typeof(string));
    
            var referencenumberParameter = referencenumber != null ?
                new ObjectParameter("referencenumber", referencenumber) :
                new ObjectParameter("referencenumber", typeof(string));
    
            var pwdParameter = pwd != null ?
                new ObjectParameter("pwd", pwd) :
                new ObjectParameter("pwd", typeof(string));
    
            var clientidParameter = clientid.HasValue ?
                new ObjectParameter("clientid", clientid) :
                new ObjectParameter("clientid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertRIDData", campaignNameParameter, referencenumberParameter, pwdParameter, clientidParameter);
        }
    
        public virtual int InsertSHORTURLData(string ipv4, string ipv6, string browser, string browser_version, string latitude, string longitude, string ipnum, string req_url, string useragent, string hostname, string isMobiledevice, Nullable<int> fk_uid, Nullable<int> fk_rid, Nullable<int> fK_clientid)
        {
            var ipv4Parameter = ipv4 != null ?
                new ObjectParameter("ipv4", ipv4) :
                new ObjectParameter("ipv4", typeof(string));
    
            var ipv6Parameter = ipv6 != null ?
                new ObjectParameter("ipv6", ipv6) :
                new ObjectParameter("ipv6", typeof(string));
    
            var browserParameter = browser != null ?
                new ObjectParameter("browser", browser) :
                new ObjectParameter("browser", typeof(string));
    
            var browser_versionParameter = browser_version != null ?
                new ObjectParameter("browser_version", browser_version) :
                new ObjectParameter("browser_version", typeof(string));
    
            var latitudeParameter = latitude != null ?
                new ObjectParameter("latitude", latitude) :
                new ObjectParameter("latitude", typeof(string));
    
            var longitudeParameter = longitude != null ?
                new ObjectParameter("longitude", longitude) :
                new ObjectParameter("longitude", typeof(string));
    
            var ipnumParameter = ipnum != null ?
                new ObjectParameter("ipnum", ipnum) :
                new ObjectParameter("ipnum", typeof(string));
    
            var req_urlParameter = req_url != null ?
                new ObjectParameter("req_url", req_url) :
                new ObjectParameter("req_url", typeof(string));
    
            var useragentParameter = useragent != null ?
                new ObjectParameter("useragent", useragent) :
                new ObjectParameter("useragent", typeof(string));
    
            var hostnameParameter = hostname != null ?
                new ObjectParameter("hostname", hostname) :
                new ObjectParameter("hostname", typeof(string));
    
            var isMobiledeviceParameter = isMobiledevice != null ?
                new ObjectParameter("IsMobiledevice", isMobiledevice) :
                new ObjectParameter("IsMobiledevice", typeof(string));
    
            var fk_uidParameter = fk_uid.HasValue ?
                new ObjectParameter("fk_uid", fk_uid) :
                new ObjectParameter("fk_uid", typeof(int));
    
            var fk_ridParameter = fk_rid.HasValue ?
                new ObjectParameter("fk_rid", fk_rid) :
                new ObjectParameter("fk_rid", typeof(int));
    
            var fK_clientidParameter = fK_clientid.HasValue ?
                new ObjectParameter("FK_clientid", fK_clientid) :
                new ObjectParameter("FK_clientid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertSHORTURLData", ipv4Parameter, ipv6Parameter, browserParameter, browser_versionParameter, latitudeParameter, longitudeParameter, ipnumParameter, req_urlParameter, useragentParameter, hostnameParameter, isMobiledeviceParameter, fk_uidParameter, fk_ridParameter, fK_clientidParameter);
        }
    
        public virtual int InsertUIDData(Nullable<int> fk_rid, Nullable<int> fk_clientid, string referencenumber, string longurl, string mobilenumber)
        {
            var fk_ridParameter = fk_rid.HasValue ?
                new ObjectParameter("fk_rid", fk_rid) :
                new ObjectParameter("fk_rid", typeof(int));
    
            var fk_clientidParameter = fk_clientid.HasValue ?
                new ObjectParameter("fk_clientid", fk_clientid) :
                new ObjectParameter("fk_clientid", typeof(int));
    
            var referencenumberParameter = referencenumber != null ?
                new ObjectParameter("referencenumber", referencenumber) :
                new ObjectParameter("referencenumber", typeof(string));
    
            var longurlParameter = longurl != null ?
                new ObjectParameter("longurl", longurl) :
                new ObjectParameter("longurl", typeof(string));
    
            var mobilenumberParameter = mobilenumber != null ?
                new ObjectParameter("mobilenumber", mobilenumber) :
                new ObjectParameter("mobilenumber", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertUIDData", fk_ridParameter, fk_clientidParameter, referencenumberParameter, longurlParameter, mobilenumberParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<spGetALLCOUNTS_Result> spGetALLCOUNTS(Nullable<int> filterBy, Nullable<System.DateTime> dateFrom, Nullable<System.DateTime> dateTo)
        {
            var filterByParameter = filterBy.HasValue ?
                new ObjectParameter("FilterBy", filterBy) :
                new ObjectParameter("FilterBy", typeof(int));
    
            var dateFromParameter = dateFrom.HasValue ?
                new ObjectParameter("DateFrom", dateFrom) :
                new ObjectParameter("DateFrom", typeof(System.DateTime));
    
            var dateToParameter = dateTo.HasValue ?
                new ObjectParameter("DateTo", dateTo) :
                new ObjectParameter("DateTo", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetALLCOUNTS_Result>("spGetALLCOUNTS", filterByParameter, dateFromParameter, dateToParameter);
        }
    
        public virtual ObjectResult<spGetALLCOUNTS1_Result> spGetALLCOUNTS1(Nullable<System.DateTime> dateFrom, Nullable<System.DateTime> dateTo, Nullable<int> rid)
        {
            var dateFromParameter = dateFrom.HasValue ?
                new ObjectParameter("DateFrom", dateFrom) :
                new ObjectParameter("DateFrom", typeof(System.DateTime));
    
            var dateToParameter = dateTo.HasValue ?
                new ObjectParameter("DateTo", dateTo) :
                new ObjectParameter("DateTo", typeof(System.DateTime));
    
            var ridParameter = rid.HasValue ?
                new ObjectParameter("rid", rid) :
                new ObjectParameter("rid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetALLCOUNTS1_Result>("spGetALLCOUNTS1", dateFromParameter, dateToParameter, ridParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> spGetCampaignSummary(string rid)
        {
            var ridParameter = rid != null ?
                new ObjectParameter("rid", rid) :
                new ObjectParameter("rid", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("spGetCampaignSummary", ridParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> spGetDashBoardSummary(Nullable<int> fkClientId)
        {
            var fkClientIdParameter = fkClientId.HasValue ?
                new ObjectParameter("FkClientId", fkClientId) :
                new ObjectParameter("FkClientId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("spGetDashBoardSummary", fkClientIdParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> spGetDashBoardSummary1(Nullable<int> fkClientId)
        {
            var fkClientIdParameter = fkClientId.HasValue ?
                new ObjectParameter("FkClientId", fkClientId) :
                new ObjectParameter("FkClientId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("spGetDashBoardSummary1", fkClientIdParameter);
        }
    }
}
