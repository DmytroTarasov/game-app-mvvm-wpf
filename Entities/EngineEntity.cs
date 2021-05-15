using System;

namespace Entities
{
    public class EngineEntity : BaseEntity<Guid>
    {
        public DetailEntity Detail { get; set; }
        public string Type { get; set; }
    }
}