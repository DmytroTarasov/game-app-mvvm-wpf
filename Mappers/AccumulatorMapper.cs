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
        // public static AccumulatorEntity ModelToEntityUpdate(this AccumulatorModel accumulatorModel, AccumulatorEntity accumulatorEntity)
        // {
        //     accumulatorEntity.Capacity = accumulatorModel.Capacity;
        //     accumulatorEntity.Detail = accumulatorModel.Detail.ModelToEntityUpdate(new DetailEntity());
        //     return accumulatorEntity;
        // }
        public static AccumulatorModel EntityToModel(this AccumulatorEntity accumulator)
        {
            return new AccumulatorModel
            {
                Capacity = accumulator.Capacity,
                Detail = accumulator.Detail.EntityToModel()
            };
        }
        // public static AccumulatorModel EntityToModelUpdate(this AccumulatorEntity accumulatorEntity, AccumulatorModel accumulatorModel)
        // {
        //     accumulatorModel.Capacity = accumulatorEntity.Capacity;
        //     accumulatorModel.Detail = accumulatorEntity.Detail.EntityToModelUpdate(new DetailModel());
        //     return accumulatorModel;
        // }
    }
}