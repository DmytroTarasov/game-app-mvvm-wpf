using System;
using System.Collections.Generic;
using Models;

namespace Services
{
    public interface IEngineService
    {
        EngineModel Get(Guid detailId);
        IEnumerable<EngineModel> GetAll();
        IEnumerable<EngineModel> GetAllWithDetails();
        void Add(EngineModel engine);
        void Remove(EngineModel engine);
    }
}