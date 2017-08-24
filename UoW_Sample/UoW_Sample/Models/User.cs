
using System;

namespace UoW_Sample.Models
{
    public class User : VersionedEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string SurName { get; set; }
    }
}