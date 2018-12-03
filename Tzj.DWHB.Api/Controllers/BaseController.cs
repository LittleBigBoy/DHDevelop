using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Tzj.DWHB.Api.Models;

namespace Tzj.DWHB.Api.Controllers
{
    public class BaseController : ApiController
    {
        // GET: Base
        public void Out(ResultMsg ResultMessage, string callback)
        {
            //Response.Write(
            //        string.Format("{0}({1})", callback, ToJson(ResultMessage))
            //        );
        }
        public static string ToJson(object data)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(data);
        }
        //public static T ToObject<T>(string data)
        //{
        //    JavaScriptSerializer js = new JavaScriptSerializer();
        //    return js.Deserialize<T>(data);
        //}
    }
}