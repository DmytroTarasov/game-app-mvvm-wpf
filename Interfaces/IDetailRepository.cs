using System;
using Entities;

namespace Interfaces
{
    public interface IDetailRepository : IRepository<DetailEntity, Guid>
    {
        public double GetMinDetailPurchaseCost();
    }
}