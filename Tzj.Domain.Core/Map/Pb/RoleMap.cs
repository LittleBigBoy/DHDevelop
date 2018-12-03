using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Tzj.Domain.Core.Model.Pb;

namespace Tzj.Domain.Core.Map.Pb
{
    public class RoleMap : ClassMap<Role>
    {
        public RoleMap()
        {
            Table("Pb_Role");
            Id(p => p.RoleID);
            Map(p => p.RoleName);
            Map(p => p.Sort);
            Map(p => p.Type);
            Map(p => p.IsUse);
            Map(p => p.ParentID);
        }
    }
}
