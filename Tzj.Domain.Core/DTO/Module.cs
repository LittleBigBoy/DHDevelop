using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tzj.Domain.Core.DTO
{
    public class Module
    {
        public string moduleName { get; set; }
        public string Url { get; set; }
        public string Rank { get; set; }
        public string ParentId { get; set; }
    }
}
