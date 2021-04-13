using System;

namespace Entities
{
    public class EngineEntity 
    {
        public DetailEntity Detail { get; set; }    
        public Guid DetailId { get; set; }
        public string Type { get; set; }
    }
}