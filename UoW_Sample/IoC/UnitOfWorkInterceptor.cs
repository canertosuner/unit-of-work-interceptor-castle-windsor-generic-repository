using Castle.DynamicProxy;
using Castle.MicroKernel;
using NHibernate;
using NHibernate.Context;
using System;

namespace UoW_Sample.IoC
{
    public class UnitOfWorkInterceptor : Castle.DynamicProxy.IInterceptor
    {
        private readonly ISessionFactory _sessionFactory;

        public UnitOfWorkInterceptor(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                UnitOfWorkManager.Current = new UnitOfWorkManager(_sessionFactory);
                UnitOfWorkManager.Current.BeginTransaction();

                try
                {
                    invocation.Proceed();
                    UnitOfWorkManager.Current.Commit();
                }
                catch
                {
                    UnitOfWorkManager.Current.Rollback();
                    throw new Exception("Db operation failed.");
                }
            }
            finally
            {
                UnitOfWorkManager.Current = null;
            }
        }
    }
}