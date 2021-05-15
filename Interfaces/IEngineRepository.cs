using System;
using System.Collections.Generic;
using Entities;

namespace Interfaces
{
    public interface IEngineRepository : IRepository<EngineEntity, Guid>
    {
        public IEnumerable<EngineEntity> GetAllWithDetails();
        
    }
}