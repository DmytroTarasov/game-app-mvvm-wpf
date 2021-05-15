using System;
using System.Collections.Generic;
using Entities;

namespace Interfaces
{
    public interface IAccumulatorRepository : IRepository<AccumulatorEntity, Guid>
    {
        public IEnumerable<AccumulatorEntity> GetAllWithDetails();
    }
}