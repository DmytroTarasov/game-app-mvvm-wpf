using System.Collections.Generic;

namespace Entities
{
    public class DetailEntity : BaseEntity
    {
        public double Stability { get; set; }
        public double PurchaseCost { get; set; }
        public double RepairCost { get; set; }
        public bool IsBroken { get; set; }
        public bool CanBeRepaired { get; set; }
        public double CoeffDecrStability { get; set; }
        public EngineEntity Engine { get; set; }
        public AccumulatorEntity Accumulator { get; set; }
        public DiskEntity Disk { get; set; }
        public List<CarEntity> Cars { get; set; }
    }
}