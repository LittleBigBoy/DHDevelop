using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tzj.Domain.Core.IService.Pb
{
    public interface IRoleAccounService
    {
        int GetRoleIDByAccountID(int AccountID);
    }
}
