using FluentNHibernate.Mapping;
using UoW_Sample.Models;

namespace UoW_Sample.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("Users");
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.SurName);

            Version(X => X.EntityVersion);
            
            OptimisticLock.Version();
        }
    }
}