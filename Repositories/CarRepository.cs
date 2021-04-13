using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Entities;
using Interfaces;

namespace Repositories
{
    public class CarRepository : Repository<CarEntity>, ICarRepository
    {
        public CarRepository(DataContext context) : base(context) { }
        public IEnumerable<DetailEntity> GetAllCarDetails(Guid carId)
        {
            //return Context.Details.Where(d => d.Cars.Contains(car)).ToList();
            return Context.Cars.Single(c => c.Id == carId).Details;
        }
        public DetailEntity GetCarDetailByDetailId(Guid carId, Guid detailId)
        {
            //return GetAllCarDetails(car).ToList().FirstOrDefault(d => d.Id == detailId);
            return GetAllCarDetails(carId).Single(d => d.Id == detailId);
        }
    }
}