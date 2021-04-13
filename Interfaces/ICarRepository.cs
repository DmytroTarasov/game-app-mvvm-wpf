using System;
using System.Collections.Generic;
using Entities;

namespace Interfaces
{
    public interface ICarRepository : IRepository<CarEntity>
    {
        IEnumerable<DetailEntity> GetAllCarDetails(Guid carId);
        DetailEntity GetCarDetailByDetailId(Guid carId, Guid detailId);
    }
}