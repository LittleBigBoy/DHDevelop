using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tzj.Domain.Core.Model.Pb
{
    public class RoleAccount:Entity<Int32>
    {
        public override int Id {
            get { return ARID;}
        }
        public virtual int ARID { get; set; }
        public virtual int AccountID { get; set; }
        public virtual int RoleID { get; set; }
    }
}
