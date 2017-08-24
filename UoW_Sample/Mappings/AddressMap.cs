using FluentNHibernate.Mapping;
using UoW_Sample.Models;

namespace UoW_Sample.Mappings
{
    public class AddressNap : ClassMap<Address>
    {
        public AddressNap()
        {
            Table("Address");
            Id(x => x.Id);
            Map(x => x.CityCode);
            Map(x => x.DistrictCode);
            Map(x => x.Description);
            Map(x => x.UserId);
        }
    }
}