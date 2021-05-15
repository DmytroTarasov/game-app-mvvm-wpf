using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Entities;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class AccumulatorRepository : Repository<AccumulatorEntity, Guid>, IAccumulatorRepository
    {
        public AccumulatorRepository(DataContext context) : base(context) { }
        
        public IEnumerable<AccumulatorEntity> GetAllWithDetails()
        {
            return Context.Accumulators
                .Include(e => e.Detail)
                .Where(a => a.Detail.Stability - a.Detail.CoeffDecrStability > 0.1)
                .ToList();
        }
    }
}
