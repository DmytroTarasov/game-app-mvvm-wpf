using Entities;
using Models;

namespace Mappers
{
    public static class AccumulatorMapper
    {
        public static AccumulatorEntity ModelToEntity(this AccumulatorModel accumulator)
        {
            return new AccumulatorEntity
            {
                Capacity = accumulator.Capacity,
                Detail = accumulator.Detail.ModelToEntity()
            };
        }
        public static AccumulatorModel EntityToModel(this AccumulatorEntity accumulator)
        {
            return new AccumulatorModel
            {
                Capacity = accumulator.Capacity,
                Detail = accumulator.Detail.EntityToModel()
            };
        }
    }
}