
namespace UoW_Sample.Models
{
    public class Address
    {
        public virtual int Id { get; set; }
        public virtual string CityCode { get; set; }
        public virtual string DistrictCode { get; set; }
        public virtual string Description { get; set; }
        public virtual int UserId { get; set; }
    }
}