using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Entities;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class EngineRepository : Repository<EngineEntity, Guid>, IEngineRepository
    {
        public EngineRepository(DataContext context) : base(context) { }
        public IEnumerable<EngineEntity> GetAllWithDetails()
        {
            return Context.Engines
                .Include(e => e.Detail)
                .Where(e => e.Detail.Stability - e.Detail.CoeffDecrStability > 0.1)
                .ToList();
        }
    }
}