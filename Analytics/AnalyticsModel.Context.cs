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
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<RIDDATA> RIDDATAs { get; set; }
        public virtual DbSet<SHORTURLDATA> SHORTURLDATAs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<UIDandRIDData> UIDandRIDDatas { get; set; }
        public virtual DbSet<UIDDATA> UIDDATAs { get; set; }
    
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
    
        public virtual int InsertRIDData(string referencenumber, string pwd)
        {
            var referencenumberParameter = referencenumber != null ?
                new ObjectParameter("referencenumber", referencenumber) :
                new ObjectParameter("referencenumber", typeof(string));
    
            var pwdParameter = pwd != null ?
                new ObjectParameter("pwd", pwd) :
                new ObjectParameter("pwd", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertRIDData", referencenumberParameter, pwdParameter);
        }
    
        public virtual int InsertSHORTURLData(string ipv4, string ipv6, string browser, string browser_version, string city, string region, string country, string countrycode, string req_url, string useragent, string hostname, string deviceType, string isMobiledevice, Nullable<int> uniqueid)
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
    
            var cityParameter = city != null ?
                new ObjectParameter("city", city) :
                new ObjectParameter("city", typeof(string));
    
            var regionParameter = region != null ?
                new ObjectParameter("Region", region) :
                new ObjectParameter("Region", typeof(string));
    
            var countryParameter = country != null ?
                new ObjectParameter("country", country) :
                new ObjectParameter("country", typeof(string));
    
            var countrycodeParameter = countrycode != null ?
                new ObjectParameter("countrycode", countrycode) :
                new ObjectParameter("countrycode", typeof(string));
    
            var req_urlParameter = req_url != null ?
                new ObjectParameter("req_url", req_url) :
                new ObjectParameter("req_url", typeof(string));
    
            var useragentParameter = useragent != null ?
                new ObjectParameter("useragent", useragent) :
                new ObjectParameter("useragent", typeof(string));
    
            var hostnameParameter = hostname != null ?
                new ObjectParameter("hostname", hostname) :
                new ObjectParameter("hostname", typeof(string));
    
            var deviceTypeParameter = deviceType != null ?
                new ObjectParameter("DeviceType", deviceType) :
                new ObjectParameter("DeviceType", typeof(string));
    
            var isMobiledeviceParameter = isMobiledevice != null ?
                new ObjectParameter("IsMobiledevice", isMobiledevice) :
                new ObjectParameter("IsMobiledevice", typeof(string));
    
            var uniqueidParameter = uniqueid.HasValue ?
                new ObjectParameter("uniqueid", uniqueid) :
                new ObjectParameter("uniqueid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertSHORTURLData", ipv4Parameter, ipv6Parameter, browserParameter, browser_versionParameter, cityParameter, regionParameter, countryParameter, countrycodeParameter, req_urlParameter, useragentParameter, hostnameParameter, deviceTypeParameter, isMobiledeviceParameter, uniqueidParameter);
        }
    
        public virtual int InsertUIDData(string referencenumber, string longurl, string mobilenumber)
        {
            var referencenumberParameter = referencenumber != null ?
                new ObjectParameter("referencenumber", referencenumber) :
                new ObjectParameter("referencenumber", typeof(string));
    
            var longurlParameter = longurl != null ?
                new ObjectParameter("longurl", longurl) :
                new ObjectParameter("longurl", typeof(string));
    
            var mobilenumberParameter = mobilenumber != null ?
                new ObjectParameter("mobilenumber", mobilenumber) :
                new ObjectParameter("mobilenumber", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertUIDData", referencenumberParameter, longurlParameter, mobilenumberParameter);
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
    }
}
