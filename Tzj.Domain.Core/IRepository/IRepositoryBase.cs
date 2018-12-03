using System.Collections.Generic;
using System.Linq;
using NHibernate;
using MySql.Data;
using MySql.Data.MySqlClient;
using Tzj.Infrastructure.FrameworkCore.UnitofWork;

namespace Tzj.Domain.Core.IRepository
{
    public interface IRepositoryBase<TEntity, TKey>
     where TEntity : IAggregateRoot
    {
        IQueryable<TEntity> Query();
        TEntity GetById(TKey id);
        TKey Save(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void SaveOrUpdate(TEntity entity);
        void ExecuteNoQuery(string sql, params MySqlParameter[] cmdParms);

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmdParms"></param>
        void ExecuteProc(string sql, params MySqlParameter[] cmdParms);

        /// <summary>
        /// 清除对象一级缓存(Session.Flush()不会同步到数据库)
        /// </summary>
        /// <param name="entity"></param>
        void Evict(TEntity entity);

        /// <summary>
        /// 清除对象一级缓存(Session.Flush()不会同步到数据库)
        /// </summary>
        /// <param name="list"></param>
        void Evict(IEnumerable<TEntity> list);
        /// <summary>
        /// 获取当前会话
        /// </summary>
        /// <returns></returns>
        ISession GetSession();
    }
}
