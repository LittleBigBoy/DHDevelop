using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Tzj.Domain.Core.Service.Crm;
using Tzj.DWHB.Api.Common;
using Tzj.DWHB.Api.Enum;
using Tzj.DWHB.Api.Models;


namespace Tzj.DWHB.Api.Controllers
{
    public class ProductController : ApiController
    {
        private ResultMsg resultMsg = null;
        
        public HttpResponseMessage GetList(string id)
        {

            var a = AccountService.GetInstance().GetModelById(1);

            resultMsg = new ResultMsg();
            resultMsg.StatusCode = (int) StatusCodeEnum.Success;
            resultMsg.Info = StatusCodeEnum.Success.GetEnumText();
            resultMsg.Data = a;
            return HttpResponseExtension.toJson(JsonConvert.SerializeObject(resultMsg));
        }

     

       
    }
}