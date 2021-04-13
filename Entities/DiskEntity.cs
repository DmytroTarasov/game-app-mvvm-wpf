using System;

namespace Entities
{
    public class DiskEntity 
    {
        public DetailEntity Detail { get; set; }
        public Guid DetailId { get; set; }
        public int Diameter { get; set; }
    }
}