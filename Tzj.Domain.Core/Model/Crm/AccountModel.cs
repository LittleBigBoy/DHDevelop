using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tzj.Domain.Core.Model.Crm
{

    public class AccountModel : Entity<Int32>
    {
        public override int Id
        {
            get { return AccountID; }
        }

        public virtual int AccountID { get; set; }
        public virtual string UserID { get; set; }
        public virtual string NickName { get; set; }
        public virtual string Avator { get; set; }
        public virtual string PassWord { get; set; }
        public virtual string PayPassWord { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual DateTime LastLoginDate { get; set; }
        public virtual int LoginCount { get; set; }
        public virtual decimal RemainMoney { get; set; }
        public virtual decimal TotalMoney { get; set; }
        public virtual decimal FrozenMoney { get; set; }
        public virtual string Type { get; set; }
        public virtual string TopRank { get; set; }
        public virtual string IsUse { get; set; }
    }
}
