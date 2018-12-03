using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;
using NHibernate;
using NHibernate.Linq;
using Tzj.Domain.Core.IRepository;
using Tzj.Infrastructure.DataNhibernate;
using Tzj.Infrastructure.FrameworkCore.UnitofWork;

namespace Tzj.Domain.Core.Repository
{
    /// <summary>
    /// 数据持久基类
    /// </summary>
    public class RepositoryBase<TEntity, TKey> : IRepositoryBase<TEntity,TKey> where TEntity : class, IAggregateRoot
    {


        public TEntity GetById(TKey id)
        {
            ISession session = SessionFactoryManager.GetCurrentSession();
            return session.Get<TEntity>(id);
        }


        public TEntity Load(TKey id)
        {
            ISession session = SessionFactoryManager.GetCurrentSession();
            return session.Load<TEntity>(id);
        }

        public void Merge(TEntity entity)
        {

            ISession session = SessionFactoryManager.GetCurrentSession();
            using (var tx = TransactionHelper.NhTransactionHelper.BeginTransaction())
            {
                try
                {
                    session.Merge(entity);
                    tx.Commit();
                }
                catch
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        public IQueryable<TEntity> Query()
        {
            ISession session = SessionFactoryManager.GetCurrentSession();
            return session.Query<TEntity>();
        }

        public TKey Save(TEntity entity)
        {

            ISession session = SessionFactoryManager.GetCurrentSession();

            using (var tx = TransactionHelper.NhTransactionHelper.BeginTransaction())
            {
                try
                {
                    var key = (TKey)session.Save(entity);
                    tx.Commit(() => {
                        return true;
                    });
                    return key;
                }
                catch
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        public IList<TKey> Save(IList<TEntity> entitys)
        {

            ISession session = SessionFactoryManager.GetCurrentSession();

            using (var tx = TransactionHelper.NhTransactionHelper.BeginTransaction())
            {
                try
                {
                    IList<TKey> keys = entitys.Select(entity => (TKey)session.Save(entity)).ToList();
                    tx.Commit(() =>
                    {
                        return true;
                    });
                    return keys;
                }
                catch
                {
                    tx.Rollback();
                    throw;
                }
            }
        }


        public TKey Save2(TEntity entity, ISession session)
        {
            var key = (TKey)session.Save(entity);
            session.Flush();
            return key;
        }

        public void Update(IList<TEntity> entitys)
        {
            ISession session = SessionFactoryManager.GetCurrentSession();
            using (var tx = TransactionHelper.NhTransactionHelper.BeginTransaction())
            {
                try
                {
                    foreach (var entity in entitys)
                    {
                        session.Update(entity);
                    }
                    
                    tx.Commit(() =>
                    {
                        return true;
                    });
                }
                catch (Exception e)
                {
                    tx.Rollback();
                    throw;
                }
            }
        }
        public void Update(TEntity entity)
        {

            ISession session = SessionFactoryManager.GetCurrentSession();
            using (var tx = TransactionHelper.NhTransactionHelper.BeginTransaction())
            {
                try
                {
                    session.Update(entity);
                    tx.Commit(() =>
                    {
                        return true;
                    });
                }
                catch (Exception e)
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        public void Delete(TEntity entity)
        {
            ISession session = SessionFactoryManager.GetCurrentSession();
            using (var tx = TransactionHelper.NhTransactionHelper.BeginTransaction())
            {
                try
                {
                    session.Delete(entity);
                    tx.Commit();
                }
                catch
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        public void SaveOrUpdate(TEntity entity)
        {

            ISession session = SessionFactoryManager.GetCurrentSession();
            using (var tx = TransactionHelper.NhTransactionHelper.BeginTransaction())
            {
                try
                {
                    session.SaveOrUpdate(entity);
                    tx.Commit(() =>
                    {
                        return true;
                    });
                }
                catch
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        /// <summary>
        ///        SqlParameter[] cmdParms = new SqlParameter[] { };
        ///cmdParms[0] = new SqlParameter("@" + AccidentParameter.AccidentDate + "",);
        /// </summary>
        /// <param name="sql"></param>
        ///<param name="cmdParms"> </param>
        public void ExecuteNoQuery(string sql, params MySqlParameter[] cmdParms)
        {
            ISession session = SessionFactoryManager.GetCurrentSession();
            IDbCommand cmd = session.Connection.CreateCommand();
            session.Transaction.Enlist(cmd);
            
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            if (cmdParms != null)
            {
                foreach (MySqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
            cmd.Prepare();
            cmd.ExecuteNonQuery();

        }

        /// <summary>
        ///        SqlParameter[] cmdParms = new SqlParameter[] { };
        ///cmdParms[0] = new SqlParameter("@" + AccidentParameter.AccidentDate + "",);
        /// </summary>
        /// <param name="sql"></param>
        ///<param name="cmdParms"> </param>
        public int ExecuteQuery(string sql, params MySqlParameter[] cmdParms)
        {
            ISession session = SessionFactoryManager.GetCurrentSession();
            IDbCommand cmd = session.Connection.CreateCommand();
            session.Transaction.Enlist(cmd);
            
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            if (cmdParms != null)
            {
                foreach (MySqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
            cmd.Prepare();
            var count = cmd.ExecuteNonQuery();

            return count;
        }

        public DataTable ExecuteNoQueryToTable(string sql, params MySqlParameter[] cmdParms)
        {
            ISession session = SessionFactoryManager.GetCurrentSession();

            MySqlDataAdapter mysqlAdapter = new MySqlDataAdapter();
            mysqlAdapter.SelectCommand.Connection = (MySqlConnection) session.Connection;
            mysqlAdapter.SelectCommand.CommandType = CommandType.Text;
            mysqlAdapter.SelectCommand.CommandText = sql;
            if (cmdParms != null)
            {
                foreach (MySqlParameter parm in cmdParms)
                    mysqlAdapter.SelectCommand.Parameters.Add(parm);
            }
            DataSet ds = new DataSet();
            mysqlAdapter.Fill(ds);
            return ds.Tables[0];
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmdParms"></param>
        public void ExecuteProc(string sql, params MySqlParameter[] cmdParms)
        {
            ISession session = SessionFactoryManager.GetCurrentSession();
            IDbCommand cmd = session.Connection.CreateCommand();
            session.Transaction.Enlist(cmd);
            
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.StoredProcedure;
            if (cmdParms != null)
            {
                foreach (MySqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
            cmd.Prepare();
            cmd.ExecuteNonQuery();

        }

        /// <summary>
        /// 清除对象一级缓存(Session.Flush()不会同步到数据库)
        /// </summary>
        /// <param name="entity"></param>
        public void Evict(TEntity entity)
        {
            SessionFactoryManager.GetCurrentSession().Evict(entity);
        }
        /// <summary>
        /// 完全的清除缓存
        /// </summary>
        /// <param name="entity"></param>
        public void Clear()
        {
            SessionFactoryManager.GetCurrentSession().Clear();
        }
        /// <summary>
        /// 刷新一级缓存中的单个实体
        /// </summary>
        /// <param name="entity"></param>
        public void Refresh(TEntity entity)
        {
            SessionFactoryManager.GetCurrentSession().Refresh(entity);
        }


        /// <summary>
        /// 清除对象一级缓存(Session.Flush()不会同步到数据库)
        /// </summary>
        /// <param name="list"></param>
        public void Evict(IEnumerable<TEntity> list)
        {
            foreach (var p in list)
            {
                SessionFactoryManager.GetCurrentSession().Evict(p);
            }
        }

        public ISession GetSession()
        {
            return SessionFactoryManager.GetCurrentSession();
        }
    }
}
