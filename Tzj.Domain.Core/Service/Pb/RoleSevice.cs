using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tzj.Domain.Core.IService.Pb;
using Tzj.Domain.Core.Model.Pb;
using Tzj.Domain.Core.Repository.Pb;
using Tzj.Infrastructure.DataNhibernate.Helpers;

namespace Tzj.Domain.Core.Service.Pb
{
    public class RoleSevice : IRoleService
    {
        #region 初始化

        private static readonly RoleSevice Instance = new RoleSevice();
        private readonly RoleRepository _roleRepository;

        public RoleSevice()
        {
            _roleRepository = new RoleRepository();
        }
        public static RoleSevice GetInstance()
        {
            return Instance;
        }
        #endregion

        public Role GetModelByID(int roleID)
        {
            try
            {
                var result = _roleRepository.Query().SingleOrDefault(p => p.RoleID == roleID);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Role> GetModelList()
        {
            try
            {
                var result = _roleRepository.Query().ToList();
                return result;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public List<Role> GetModelList(Role model)
        {
            try
            {
                var exp = PredicateBuilder.True<Role>();
                if (!string.IsNullOrWhiteSpace(model.RoleName))
                    exp = exp.And(p => p.RoleName == model.RoleName);
                var result = _roleRepository.Query().Where(exp).OrderByDescending(p => p.RoleID).ToList();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
