using Entities;
using Models;

namespace Mappers
{
    public static class EngineMapper
    {
        public static EngineEntity ModelToEntity(this EngineModel engine)
        {
            return new EngineEntity
            {
                Type = engine.Type,
                Detail = engine.Detail.ModelToEntity()
            };
        }
        // public static EngineEntity ModelToEntityUpdate(this EngineModel engineModel, EngineEntity engineEntity)
        // {
        //     engineEntity.Type = engineModel.Type;
        //     engineEntity.Detail = engineModel.Detail.ModelToEntityUpdate(new DetailEntity());
        //     return engineEntity;
        // }
        public static EngineModel EntityToModel(this EngineEntity engine)
        {
            return new EngineModel
            {
                Type = engine.Type,
                Detail = engine.Detail.EntityToModel()
            };
        }
        // public static EngineModel EntityToModelUpdate(this EngineEntity engineEntity, EngineModel engineModel)
        // {
        //     engineModel.Type = engineEntity.Type;
        //     engineModel.Detail = engineEntity.Detail.EntityToModelUpdate(new DetailModel());
        //     return engineModel;
        // }
    }
}