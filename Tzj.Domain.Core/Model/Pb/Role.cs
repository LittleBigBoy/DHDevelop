using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tzj.Domain.Core.Model.Pb
{
   public class Role:Entity<Int32>
    {
       public override int Id {
           get { return RoleID; }
       }
       public virtual int RoleID { get; set; }
       public virtual string RoleName { get; set; }
       public virtual int Sort { get; set; }
       public virtual string Type { get; set; }
        /// <summary>
        /// Yes or No
        /// </summary>
       public virtual string IsUse { get; set; }
       public virtual int ParentID { get; set; }
    }
}
