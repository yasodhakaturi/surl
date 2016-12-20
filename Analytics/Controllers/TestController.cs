using Analytics.Helpers;
using Analytics.Helpers.BO;
using Analytics.Models;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace Analytics.Controllers
{
     [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TestController : ApiController
    {
         shortenURLEntities dc = new shortenURLEntities();

         //public HttpResponseMessage Get()
         //{
         //    return new HttpResponseMessage()
         //    {
         //        Content = new StringContent("GET: Test message")
         //    };
         //}
         //public IEnumerable<ClientView> Get()
         //{
         //    Client obj1 = new Client();
         //    //get all client detials
         //    List<ClientView> objc = (from c in dc.Clients
         //                             select new ClientView
         //                             {
         //                                 id = c.PK_ClientID,
         //                                 UserName = c.UserName,
         //                                 Email = c.Email,
         //                                 isactive = c.IsActive
         //                                 //Password = c.Password
         //                             }).ToList();
         //    //return  Json(objc, JsonRequestBehavior.AllowGet);
         //    //return new JsonResult()
         //    //{
         //    //    Data = objc,
         //    //    JsonRequestBehavior = JsonRequestBehavior.AllowGet
         //    //};
         //    return objc;
         //}
         public static string GetProps<T>(Expression<Func<T, object>> parameters)
         {
             StringBuilder requestedParametersString = new StringBuilder();
             if (parameters != null && parameters.Body != null)
             {
                 var body = parameters.Body as System.Linq.Expressions.NewExpression;
                 if (body.Members != null && body.Members.Any())
                 {
                     foreach (var member in body.Members)
                     {
                         requestedParametersString.Append(member.Name + ",");
                     }
                 }
             }
             return requestedParametersString.ToString();
         }
         //public async Task<List<ClientView>> GetProducts(Expression<Func<ClientView, object>> parameters)
         //{
         //    HttpClient cl = new HttpClient();
         //    string BaseUrl = "http://localhost:8080/api/test";
         //    string requestedParametersString =GetProps(parameters);
         //    HttpResponseMessage response = await cl.GetAsync(BaseUrl + "?fields=" + requestedParametersString);
         //    if (response.IsSuccessStatusCode)
         //    {
         //        var products = await response.Content.ReadAsAsync<List<ClientView>>();
         //        return products;
         //    }
         //    return new List<ClientView>();
         //}
        

         //}
         // GET api/test/5
         public System.Web.Http.Results.JsonResult<ClientView> Get(int id)
         {
             string fields = "id,UserName,Email,isactive";
             ClientView obj = (from c in dc.Clients
                               where c.PK_ClientID == id
                               select new ClientView
                               {
                                   id = c.PK_ClientID,
                                   UserName = c.UserName,
                                   Email = c.Email,
                                   IsActive = c.IsActive
                                   //Password = c.Password
                               }).SingleOrDefault();
               obj.SetSerializableProperties(fields);
               return Json(obj, new Newtonsoft.Json.JsonSerializerSettings()
               {
                   ContractResolver = new ShouldSerializeContractResolver()
               });
               
         }
    }

}