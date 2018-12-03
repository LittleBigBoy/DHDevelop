using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tzj.Domain.Core.IService.Pb;
using Tzj.Domain.Core.Repository.Pb;

namespace Tzj.Domain.Core.Service.Pb
{
    public class RoleAccountService : IRoleAccounService
    {
        #region 初始化

        private static readonly RoleAccountService Instance = new RoleAccountService();
        private readonly RoleAccountRepository _roleAccountRepository;

        public RoleAccountService()
        {
            _roleAccountRepository = new RoleAccountRepository();
        }
        public static RoleAccountService GetInstance()
        {
            return Instance;
        }
        #endregion

        public int GetRoleIDByAccountID(int AccountId)
        {
            try
            {
                return _roleAccountRepository.Query().Single(p => p.AccountID == AccountId).RoleID;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }
    }
}
