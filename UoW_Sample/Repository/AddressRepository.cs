using NHibernate;
using UoW_Sample.Base.Repository;
using UoW_Sample.Models;

namespace UoW_Sample.Repository
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }
    }
}