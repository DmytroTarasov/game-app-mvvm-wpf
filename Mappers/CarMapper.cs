using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Entities;
using Models;

namespace Mappers
{
    public static class CarMapper
    {
        public static CarEntity ModelToEntity(this CarModel car)
        {
            return new CarEntity
            {
                Id = car.Id,
                Mileage = car.Mileage,
                CoeffMoneyPerKilometer = car.CoeffMoneyPerKilometer,
                Details = car.Details?.Select(d => d.ModelToEntity()).ToList() ?? new List<DetailEntity>()
            };
        }
        public static CarEntity ModelToEntityUpdate(this CarModel carModel, CarEntity carEntity)
        {
            carEntity.Id = carModel.Id;
            carEntity.Mileage = carModel.Mileage;
            carEntity.CoeffMoneyPerKilometer = carModel.CoeffMoneyPerKilometer;
            carEntity.Details = carModel.Details.Select(d => d.ModelToEntity()).ToList();
            return carEntity;
        }
        public static CarModel EntityToModel(this CarEntity car)
        {
            return new CarModel
            {
                Id = car.Id,
                Mileage = car.Mileage,
                CoeffMoneyPerKilometer = car.CoeffMoneyPerKilometer,
                Details = new ObservableCollection<DetailModel>(car.Details?.Select(d => d.EntityToModel()) ?? new ObservableCollection<DetailModel>())
            };
        }
        public static CarModel EntityToModelUpdate(this CarEntity carEntity, CarModel carModel)
        {
            carModel.Id = carEntity.Id;
            carModel.CoeffMoneyPerKilometer = carEntity.CoeffMoneyPerKilometer;
            carModel.Mileage = carEntity.Mileage;
            carModel.Details =
                new ObservableCollection<DetailModel>(carEntity.Details.Select(d => d.EntityToModel()).ToList());
            return carModel;
        }
    }
}