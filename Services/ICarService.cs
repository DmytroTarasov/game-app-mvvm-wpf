using System;
using System.Collections.Generic;
using Models;

namespace Services
{
    public interface ICarService
    {
        CarModel Get(Guid id);
        IEnumerable<CarModel> GetAll();
        IEnumerable<DetailModel> GetAllCarDetails(Guid carId);
        DetailModel GetCarDetailByDetailId(Guid carId, Guid detailId);
        void Add(CarModel car);
        void Remove(CarModel car);
        (double, CarModel) CreateCar(EngineModel e, AccumulatorModel a, DiskModel d, double coeffMoneyPerKilometer,
            double money);
        void IncreaseMileage(CarModel car);
        double RiseMoney(CarModel car, double distance, double money);
    }
}