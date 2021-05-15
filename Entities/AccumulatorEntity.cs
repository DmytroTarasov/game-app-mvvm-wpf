using System;

namespace Entities
{
    public class AccumulatorEntity : BaseEntity<Guid>
    {
        public DetailEntity Detail { get; set; }
        public int Capacity { get; set; }
    }
}