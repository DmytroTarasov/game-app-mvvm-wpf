using System;
using System.Collections.Generic;
using Models;

namespace Services
{
    public interface IAccumulatorService
    {
        AccumulatorModel Get(Guid detailId);
        IEnumerable<AccumulatorModel> GetAll();
        IEnumerable<AccumulatorModel> GetAllWithDetails();
        void Add(AccumulatorModel accumulator);
        void Remove(AccumulatorModel accumulator);
    }
}