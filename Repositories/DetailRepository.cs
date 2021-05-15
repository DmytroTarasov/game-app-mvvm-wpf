using System;
using System.Linq;
using Data;
using Entities;
using Interfaces;

namespace Repositories
{
    public class DetailRepository : Repository<DetailEntity, Guid>, IDetailRepository
    {
        public DetailRepository(DataContext context) : base(context) { }

        public double GetMinDetailPurchaseCost()
        {
            return Context.Details.Select(d => d.PurchaseCost).Min();
        }
    }
}