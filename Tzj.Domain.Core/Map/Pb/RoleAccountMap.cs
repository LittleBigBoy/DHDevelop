using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Tzj.Domain.Core.Model.Pb;

namespace Tzj.Domain.Core.Map.Pb
{
    public class RoleAccountMap:ClassMap<RoleAccount>
    {
        public RoleAccountMap()
        {
            Table("Pb_accountrole");
            Id(p => p.ARID);
            Map(p => p.AccountID);
            Map(p => p.RoleID);
        }
    }
}
