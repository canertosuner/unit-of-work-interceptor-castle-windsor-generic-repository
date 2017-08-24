

namespace UoW_Sample.Models
{
    public abstract class VersionedEntity
    {
        public virtual int EntityVersion { get; set; }
    }
}