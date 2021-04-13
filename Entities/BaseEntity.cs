using System;

namespace Entities
{
    public class BaseEntity : IBaseEntity
    {
        public Guid Id { get; set; }
        protected BaseEntity()
        {
            if (Id == Guid.Empty)
            {
                Id = Guid.NewGuid();
            }
        }
    }
}