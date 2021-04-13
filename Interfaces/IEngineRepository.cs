using System;
using System.Collections.Generic;
using Entities;

namespace Interfaces
{
    public interface IEngineRepository : IRepository<EngineEntity>
    {
        public IEnumerable<EngineEntity> GetAllWithDetails();
        
    }
}