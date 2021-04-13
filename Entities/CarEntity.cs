using System.Collections.Generic;

namespace Entities
{
    public class CarEntity : BaseEntity
    {
        public double Mileage { get; set; }
        public double CoeffMoneyPerKilometer { get; set; }
        public List<DetailEntity> Details { get; set; }
        public CarEntity()
        {
            Mileage = 0;
        }
    }
}