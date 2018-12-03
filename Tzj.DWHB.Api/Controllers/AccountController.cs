using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.ApplicationServices;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using Tzj.Domain.Core.Service.Crm;
using Tzj.Domain.Core.Service.Pb;
using Tzj.DWHB.Api.Common;
using Tzj.DWHB.Api.Domain.Base;
using Tzj.DWHB.Api.Enum;
using Tzj.DWHB.Api.Models;

namespace Tzj.DWHB.Api.Controllers
{
    public class AccountController : ApiController
    {
        public ResultMsg resultMsg = null;
        [HttpGet]
        //[EnableCors("http://localhost:8805","*","*")]
        public HttpResponseMessage LoginOn(string userName, string passWord, string timestamp, bool remeberMe = false,
            string returnUrl = "")
        {
            var UserValidate = MemberShipBase.GetMemberShipServiceInstance().ValidateLogin(userName, passWord);
            if (!UserValidate.Item1)
            {
                resultMsg = new ResultMsg();
                resultMsg.StatusCode = (int) StatusCodeEnum.Unauthorized;
                resultMsg.Info = StatusCodeEnum.Unauthorized.GetEnumText();
                resultMsg.Data = UserValidate.Item2;
                return HttpResponseExtension.toJson(JsonConvert.SerializeObject(resultMsg));
            }
            
            
            var data = MemberShipBase.GetMemberShipServiceInstance().GetToken(userName, timestamp, remeberMe);
            resultMsg = new ResultMsg();
            resultMsg.StatusCode = (int) StatusCodeEnum.Success;
            resultMsg.Info = StatusCodeEnum.Success.GetEnumText();
            resultMsg.Data = data;

            //var getRole=
            return HttpResponseExtension.toJson(JsonConvert.SerializeObject(resultMsg));
        }

        public HttpResponseMessage LoginOut(string userName)
        {
            bool loginOut = MemberShipBase.GetMemberShipServiceInstance().LoginOut(userName);
            if (loginOut)
            {
                resultMsg = new ResultMsg();
                resultMsg.StatusCode = (int)StatusCodeEnum.Success;
                resultMsg.Info = StatusCodeEnum.Success.GetEnumText();
                resultMsg.Data = "登出成功!";
            }
            else
            {
                resultMsg = new ResultMsg();
                resultMsg.StatusCode = (int)StatusCodeEnum.Error;
                resultMsg.Info = StatusCodeEnum.Error.GetEnumText();
                resultMsg.Data = "退出出错!";
            }
            return HttpResponseExtension.toJson(JsonConvert.SerializeObject(resultMsg));
        }

        public HttpResponseMessage GetUserInfo(string userName)
        {
            var data = MemberShipBase.GetMemberShipServiceInstance().GetUserInfo(userName);
            resultMsg = new ResultMsg();
            resultMsg.StatusCode = (int)StatusCodeEnum.Success;
            resultMsg.Info = StatusCodeEnum.Success.GetEnumText();
            resultMsg.Data = data;
            return HttpResponseExtension.toJson(JsonConvert.SerializeObject(resultMsg));
        }

        public HttpResponseMessage GetProduct(string id)
        {

            resultMsg = new ResultMsg();
            resultMsg.StatusCode = (int)StatusCodeEnum.Success;
            resultMsg.Info = StatusCodeEnum.Success.GetEnumText();
            resultMsg.Data = "";
            return HttpResponseExtension.toJson(JsonConvert.SerializeObject(resultMsg));
        }
    }
}
