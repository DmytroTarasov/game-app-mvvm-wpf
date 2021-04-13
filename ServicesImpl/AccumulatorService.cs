using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Entities;
using Interfaces;
using Mappers;
using Models;
using Services;

namespace ServicesImpl
{
   public class AccumulatorService : IAccumulatorService
    {
        private readonly IUnitOfWork _uof;
        public AccumulatorService(IUnitOfWork uof)
        {
            _uof = uof;
        }
        public void Add(AccumulatorModel accumulator)
        {
            _uof.Accumulators.Add(accumulator.ModelToEntity());
        }
        public AccumulatorModel Get(Guid detailId)
        {
            return _uof.Accumulators.Get(detailId).EntityToModel();
        }
        public IEnumerable<AccumulatorModel> GetAll()
        {
            return _uof.Accumulators.GetAll().Select(a => a.EntityToModel());
        }
        public IEnumerable<AccumulatorModel> GetAllWithDetails()
        {
            return _uof.Accumulators.GetAllWithDetails().Select(e => e.EntityToModel()).ToList();
        }
        public void Remove(AccumulatorModel accumulator)
        {
            var  accumulatorEntity = _uof.Accumulators.Get(accumulator.Detail.Id);
            _uof.Accumulators.Remove(accumulatorEntity);
        }
    }
}