using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Tzj.Domain.Core.IService.Crm;
using Tzj.Domain.Core.Model.Crm;
using Tzj.Domain.Core.Repository.Crm;
using Tzj.Infrastructure.DataNhibernate;
using Tzj.Infrastructure.DataNhibernate.Helpers;

namespace Tzj.Domain.Core.Service.Crm
{
    public class AccountService:IAccountService
    {
        #region

        private static readonly AccountService Instance = new AccountService();
        private readonly AccountRepository _accountRepository;
        public AccountService()
        {
            _accountRepository = new AccountRepository();
        }

        public static AccountService GetInstance()
        {
            return Instance;
        }
        #endregion

        public int Add(AccountModel model)
        {
            return 0;
        }

        public void Delete(AccountModel account)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(AccountModel model)
        {
            using (var tx = TransactionHelper.NhTransactionHelper.BeginTransaction())
            {
                try
                {
                    _accountRepository.Update(model);
                    tx.Commit();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw ex;
                }

            }

           // throw new NotImplementedException();
        }

        public AccountModel GetModelById(int id)
        {
            try
            {
                return _accountRepository.Query().Single(p => p.Id == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<AccountModel> GetModel(AccountModel model)
        {
            var expr = PredicateBuilder.True<AccountModel>();
            if (!string.IsNullOrWhiteSpace(model.UserID))
                expr = expr.And(p => p.UserID == model.UserID);
            if (!string.IsNullOrWhiteSpace(model.PassWord))
                expr = expr.And(p => p.PassWord == model.PassWord);
            expr = expr.And(p => p.IsUse == "Y");
            var result = _accountRepository.Query().Where(expr).ToList();
            return result;
        }
    }
}
