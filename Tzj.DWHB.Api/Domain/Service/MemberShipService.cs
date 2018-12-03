using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Security;
using Microsoft.ApplicationInsights.Web;
using Newtonsoft.Json;
using Tzj.Domain.Core.DTO;
using Tzj.Domain.Core.Model.Crm;
using Tzj.Domain.Core.Service.Crm;
using Tzj.Domain.Core.Service.Pb;
using Tzj.DWHB.Api.Common;
using Tzj.DWHB.Api.Domain.Interface;
using Tzj.DWHB.Api.Models;
using Tzj.DWHB.Api.Models.Account;

namespace Tzj.DWHB.Api.Domain.Service
{
    internal class MemberShipService : IMemberShipService
    {
        private static readonly MemberShipService Instance = new MemberShipService();
        protected MemberShipService()
        {

        }

        public static MemberShipService GetInstance()
        {
            return Instance;
        }

        public Tuple<bool,string> ValidateLogin(string userName, string passWord)
        {
            #region 判断用户名或密码
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(passWord))
            {
                return new Tuple<bool, string>(false,"用户名及密码不能为空");
            }
            var model = new AccountModel();
            model.UserID = userName;
            model.PassWord =  passWord;
            //model.PassWord = FormsAuthentication.HashPasswordForStoringInConfigFile(passWord, "md5");
            var user = AccountService.GetInstance().GetModel(model).SingleOrDefault();
            
            if (user == null)
            {
                return new Tuple<bool, string>(false, "用户名或密码错误");
            }
            user.LastLoginDate=DateTime.Now;
            user.LoginCount++;
            AccountService.GetInstance().Update(user);
            #endregion

            #region 判断角色及模块是否存在

            var RoleId = RoleAccountService.GetInstance().GetRoleIDByAccountID(user.AccountID);
            if (RoleId == 0)
            {
                return new Tuple<bool, string>(false, "该用户没有配置角色，请联系管理员!");
            }
            var Module = (Module)HttpRuntime.Cache.Get(RoleId.ToString());
            if (Module == null)
            {

            }
            #endregion


            return new Tuple<bool, string>(true, ""); 
        }

        public bool LoginOut(string userName)
        {
            HttpRuntime.Cache.Remove(userName);
            return true;
        }

        public string GetToken(string userName, string timestamp, bool remeberMe)
        {
            Token getToken = (Token)HttpRuntime.Cache.Get(userName);
            var signToken = Guid.NewGuid().ToString();
            if (getToken != null)
            {
                getToken.SignToken = SignExtension.GetSignToken(userName, signToken, timestamp);
                getToken.ExpireTime = remeberMe ? DateTime.Now.AddYears(1) : DateTime.Now.AddDays(1);
                HttpRuntime.Cache.Remove(userName);
                HttpRuntime.Cache.Insert(userName, getToken);
                return signToken;
            }
            Token token = new Token();
            token.SignToken = SignExtension.GetSignToken(userName, signToken, timestamp);
            token.StaffId = userName;
            token.ExpireTime = remeberMe ? DateTime.Now.AddYears(1) : DateTime.Now.AddDays(1);
            HttpRuntime.Cache.Insert(userName, token);
            return signToken;
        }

        public string GetUserInfo(string userName)
        {
            User user = new User();
            if (userName.Contains("admin"))
            {
                user.Id = 1;
                user.UserName = userName;
                user.NickName = "administator";
                user.CelPhone = "13735824764";
                var roles=new List<string>();
                roles.Add("admin");
                roles.Add("edit");
                user.Roles = roles;
                return JsonConvert.SerializeObject(user);
            }
            else
            {
                user.Id = 2;
                user.UserName = userName;
                user.NickName = "editor";
                user.CelPhone = "1681886869";
                var roles = new List<string>();
                roles.Add("edit");
                user.Roles = roles;
                return JsonConvert.SerializeObject(user);
            }
        }
    }
}