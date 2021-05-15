using System;

namespace Entities
{
    public class DiskEntity : BaseEntity<Guid>
    {
        public DetailEntity Detail { get; set; }
        public int Diameter { get; set; }
    }
}