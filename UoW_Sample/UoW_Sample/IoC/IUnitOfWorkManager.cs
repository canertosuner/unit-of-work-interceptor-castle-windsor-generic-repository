

namespace UoW_Sample.IoC
{
    public interface IUnitOfWorkManager
    {
        void BeginTransaction();
        
        void Commit();
        
        void Rollback();
    }
}
