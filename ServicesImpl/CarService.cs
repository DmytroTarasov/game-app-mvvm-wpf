using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Entities;
using Interfaces;
using Mappers;
using Models;
using Services;

namespace ServicesImpl
{
    public class CarService : ICarService
    {
        private readonly IUnitOfWork _uof;
        
        public CarService(IUnitOfWork ouf)
        {
            _uof = ouf;
        }
        public DetailModel GetCarDetailByDetailId(Guid carId, Guid detailId)
        {
            return _uof.Cars.GetCarDetailByDetailId(carId, detailId).EntityToModel();
        }

        public void Add(CarModel car)
        {
            _uof.Cars.Add(car.ModelToEntity());
            _uof.Complete();
        }

        public (double, CarModel) CreateCar(EngineModel e, AccumulatorModel a, DiskModel d, double coeffMoneyPerKilometer, 
            double money)
        {
            //if (!(money - (e.Detail.PurchaseCost + a.Detail.PurchaseCost + d.Detail.PurchaseCost) >= 0)) return (-1, null);
            var car = new CarModel
            {
                CoeffMoneyPerKilometer = coeffMoneyPerKilometer,
                Details = new ObservableCollection<DetailModel> {e.Detail, a.Detail, d.Detail}
            };
            money -= (e.Detail.PurchaseCost + a.Detail.PurchaseCost + d.Detail.PurchaseCost);
            var carEntity = car.ModelToEntity();
            var trackDetails = carEntity.Details.Select(detailEntity => _uof.Details.Get(detailEntity.Id)).ToList();
            carEntity.Details = trackDetails;
            _uof.Cars.Add(carEntity);
            car.Id = carEntity.Id;
            
            foreach (var detailModel in car.Details)
            {
                detailModel.Cars ??= new ObservableCollection<CarModel>();
                detailModel.Cars.Add(car);
            }
            _uof.Complete();
            return (money, car);
        }
        public CarModel Get(Guid id)
        {
            return _uof.Cars.Get(id).EntityToModel();
        }
        public IEnumerable<CarModel> GetAll()
        {
            return _uof.Cars.GetAll().Select(c => c.EntityToModel());
        }

        public IEnumerable<DetailModel> GetAllCarDetails(Guid carId)
        {
            return _uof.Cars.GetAllCarDetails(carId).Select(d => d.EntityToModel()).ToList();
        }

        public void IncreaseMileage(CarModel car)
        {
            var carEntity = _uof.Cars.Get(car.Id);
            carEntity.Mileage += 25;
            carEntity.EntityToModelUpdate(car);
            _uof.Complete();
        }
        public void Remove(CarModel car)
        {
            var carEntity = _uof.Cars.Get(car.Id);
            _uof.Cars.Remove(carEntity);
            _uof.Complete();
        }
        public double RiseMoney(CarModel car, double distance, double money)
        {
            money += distance * car.CoeffMoneyPerKilometer;
            return money;
        }
    }
}