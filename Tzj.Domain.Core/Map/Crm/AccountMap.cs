using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Tzj.Domain.Core.Model.Crm;

namespace Tzj.Domain.Core.Map.Crm
{
    public class AccountMap : ClassMap<AccountModel>
    {
        public AccountMap()
        {
            Table("Crm_account");
           
            Id(p => p.AccountID);
            Map(p => p.UserID);
            Map(p => p.NickName);
            Map(p => p.Avator);
            Map(p => p.PassWord);
            Map(p => p.PayPassWord);
            Map(p => p.CreateDate);
            Map(p => p.LastLoginDate);
            Map(p => p.LoginCount);
            Map(p => p.RemainMoney);
            Map(p => p.TotalMoney);
            Map(p => p.FrozenMoney);
            Map(p => p.TopRank);
            Map(p => p.Type);
            Map(p => p.IsUse);
        }
    }
}
