using System;

namespace Entities
{
    public class BaseEntity<TKey> : IBaseEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}