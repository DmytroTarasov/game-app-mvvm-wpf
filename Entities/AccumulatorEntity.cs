using System;

namespace Entities
{
    public class AccumulatorEntity
    {
        public DetailEntity Detail { get; set; }
        public Guid DetailId { get; set; }
        public int Capacity { get; set; }
    }
}