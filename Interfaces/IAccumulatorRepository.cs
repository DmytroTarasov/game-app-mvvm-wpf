using System.Collections.Generic;
using Entities;

namespace Interfaces
{
    public interface IAccumulatorRepository : IRepository<AccumulatorEntity>
    {
        public IEnumerable<AccumulatorEntity> GetAllWithDetails();
    }
}