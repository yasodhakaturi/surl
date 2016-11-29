using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Analytics;

namespace Analytics
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebInvoke(Method = "GET",
            //ResponseFormat = WebMessageFormat.Json,
             BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "GETUID?referencenumber={referencenumber}&longurl={longurl}&mobilenumber={mobilenumber}")]
        string GETUID(string referencenumber, string longurl, string mobilenumber, out string uid);

        [OperationContract]
        [WebInvoke(Method = "GET",
            //ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "GETRID?referencenumber={referencenumber}&Password={Password}")]
        string GETRID(string referencenumber, string Password, out string rid);

        [OperationContract]
        [WebInvoke(Method = "GET",
            //ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Monitize?uid={uid}")]
            //UriTemplate = "/{uid}")]
        void Monitize(string uid);
        
    }

    
}
