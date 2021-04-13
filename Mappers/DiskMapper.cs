using Entities;
using Models;

namespace Mappers
{
    public static class DiskMapper
    {
        public static DiskEntity ModelToEntity(this DiskModel disk)
        {
            return new DiskEntity
            {
                Diameter = disk.Diameter,
                Detail = disk.Detail.ModelToEntity()
            };
        }
        // public static DiskEntity ModelToEntityUpdate(this DiskModel diskModel, DiskEntity diskEntity)
        // {
        //     diskEntity.Diameter = diskModel.Diameter;
        //     diskEntity.Detail = diskModel.Detail.ModelToEntityUpdate(new DetailEntity());
        //     return diskEntity;
        // }
        public static DiskModel EntityToModel(this DiskEntity disk)
        {
            return new DiskModel
            {
                Diameter = disk.Diameter,
                Detail = disk.Detail.EntityToModel()
            };
        }
        // public static DiskModel EntityToModelUpdate(this DiskEntity diskEntity, DiskModel diskModel)
        // {
        //     diskModel.Diameter = diskEntity.Diameter;
        //     diskModel.Detail = diskEntity.Detail.EntityToModelUpdate(new DetailModel());
        //     return diskModel;
        // }
    }
}