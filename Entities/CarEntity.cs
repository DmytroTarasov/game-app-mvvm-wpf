using System;
using System.Collections.Generic;

namespace Entities
{
    public class CarEntity : BaseEntity<Guid>
    {
        public double Mileage { get; set; }
        public double CoeffMoneyPerKilometer { get; set; }
        public List<DetailEntity> Details { get; set; }
        public CarEntity()
        {
            if (Id == Guid.Empty)
            {
                Id = Guid.NewGuid();
            }
            Mileage = 0;
        }
    }
}