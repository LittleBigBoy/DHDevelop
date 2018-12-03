using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tzj.Domain.Core.Model.Crm;

namespace Tzj.Domain.Core.IService.Crm
{
    public interface IAccountService
    {
        int Add(AccountModel model);
        void Delete(AccountModel account);
        void DeleteById(int id);
        void Update(AccountModel model);
        AccountModel GetModelById(int id);
        List<AccountModel> GetModel(AccountModel model);

    }
}
