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
        public static DiskModel EntityToModel(this DiskEntity disk)
        {
            return new DiskModel
            {
                Diameter = disk.Diameter,
                Detail = disk.Detail.EntityToModel()
            };
        }
    }
}