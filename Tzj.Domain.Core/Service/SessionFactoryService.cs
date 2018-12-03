using NHibernate;
using Tzj.Infrastructure.DataNhibernate;

namespace Tzj.Domain.Core.Service
{
    public class SessionFactoryService
    {
        #region
        private static ISessionFactory _sessionFactory;
        private static readonly SessionFactoryService Instance = new SessionFactoryService();
        public static SessionFactoryService GetInstance()
        {
            return Instance;
        }

        private SessionFactoryService()
        {
            _sessionFactory = SessionFactoryManager.SessionFactory;
        }
        #endregion


        /// <summary>
        /// Get Current Session
        /// </summary>
        /// <returns>返回ISession</returns>
        public ISession GetCurrentSession()
        {
            return SessionFactoryManager.GetCurrentSession();
        }

        public void ClearSession()
        {
            SessionFactoryManager.Clear();
        }

        public void DisposeSession()
        {
            SessionFactoryManager.Dispose();
        }

    }
}
