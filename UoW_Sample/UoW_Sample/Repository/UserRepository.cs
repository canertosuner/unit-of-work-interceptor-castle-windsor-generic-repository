using NHibernate;
using UoW_Sample.Base.Repository;
using UoW_Sample.Models;

namespace UoW_Sample.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }
    }
}