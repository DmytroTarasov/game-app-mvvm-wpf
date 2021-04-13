using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using Interfaces;
using Mappers;
using Models;
using Services;

namespace ServicesImpl
{
    public class EngineService : IEngineService
    {
        private readonly IUnitOfWork _uof;
        
        public EngineService(IUnitOfWork uof)
        {
            _uof = uof;
        }
        public void Add(EngineModel engine)
        {
            _uof.Engines.Add(engine.ModelToEntity());
        }
        public EngineModel Get(Guid detailId)
        {
            return _uof.Engines.Get(detailId).EntityToModel();
        }
        public IEnumerable<EngineModel> GetAll()
        {
            return _uof.Engines.GetAll().Select(e => e.EntityToModel()).ToList();
        }
        public IEnumerable<EngineModel> GetAllWithDetails()
        {
            return _uof.Engines.GetAllWithDetails().Select(e => e.EntityToModel()).ToList();
        }
        public void Remove(EngineModel engine)
        {
            var engineEntity = _uof.Engines.Get(engine.Detail.Id);
            _uof.Engines.Remove(engineEntity);
        }
    }
}