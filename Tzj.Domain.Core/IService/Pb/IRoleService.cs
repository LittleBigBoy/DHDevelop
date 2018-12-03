using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tzj.Domain.Core.Model.Pb;

namespace Tzj.Domain.Core.IService.Pb
{
    public interface IRoleService
    {
        Role GetModelByID(int ID);
        List<Role> GetModelList();
        List<Role> GetModelList(Role model);
    }
}
