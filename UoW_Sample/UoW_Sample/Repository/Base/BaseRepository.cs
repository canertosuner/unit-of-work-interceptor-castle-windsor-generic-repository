using NHibernate;
using NHibernate.Linq;
using System;
using System.Linq;
using System.Linq.Expressions;
using UoW_Sample.Repository;

namespace UoW_Sample.Base.Repository
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        public ISessionFactory SessionFactory { get; private set; }

        public ISession _session
        {
            get { return this.SessionFactory.GetCurrentSession(); }
        }

        public BaseRepository(ISessionFactory sessionFactory)
        {
            SessionFactory = sessionFactory;
        }

        public T Get(int id)
        {
            return _session.Get<T>(id);
        }

        public IQueryable<T> SelectAll()
        {
            return _session.Query<T>();
        }

        public T GetBy(Expression<Func<T, bool>> expression)
        {
            return SelectAll().Where(expression).SingleOrDefault();
        }
        public IQueryable<T> SelectBy(Expression<Func<T, bool>> expression)
        {
            return SelectAll().Where(expression).AsQueryable();
        }

        public int Insert(T entity)
        {
            var savedId = _session.Save(entity);
            _session.Flush();
            return Convert.ToInt32(savedId);
        }

        public void Update(T entity)
        {
            _session.Update(entity);
            _session.Flush();
        }
    }
}