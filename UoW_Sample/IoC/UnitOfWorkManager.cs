using NHibernate;
using NHibernate.Context;
using System;

namespace UoW_Sample.IoC
{
    public class UnitOfWorkManager : IUnitOfWorkManager
    {
        public static UnitOfWorkManager Current
        {
            get { return _current; }
            set { _current = value; }
        }
        [ThreadStatic]
        private static UnitOfWorkManager _current;
        
        public ISession Session { get; private set; }
        
        private readonly ISessionFactory _sessionFactory;
        
        private ITransaction _transaction;
        
        public UnitOfWorkManager(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }
        
        public void BeginTransaction()
        {
            Session = _sessionFactory.OpenSession();
            CurrentSessionContext.Bind(Session);
            _transaction = Session.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            finally
            {
                Session.Close();
            }
        }

        public void Rollback()
        {
            try
            {
                _transaction.Rollback();
            }
            finally
            {
                Session.Close();
            }
        }
    }
}