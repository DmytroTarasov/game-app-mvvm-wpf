using Entities;

namespace Interfaces
{
    public interface IDetailRepository : IRepository<DetailEntity>
    {
        public double GetMinDetailPurchaseCost();
    }
}