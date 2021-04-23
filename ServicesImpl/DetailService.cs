using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Mappers;
using Models;
using Services;

namespace ServicesImpl
{
    public class DetailService : IDetailService
    {
        private readonly IUnitOfWork _uof;
        
        public DetailService(IUnitOfWork uof)
        {
            _uof = uof;
        }
        
        public DetailModel Get(Guid id)
        {
            return _uof.Details.Get(id).EntityToModel();
        }

        public IEnumerable<DetailModel> GetAll()
        {
            return _uof.Details.GetAll().Select(d => d.EntityToModel()).ToList();
        }

        public double GetMinDetailPurchaseCost()
        {
            return _uof.Details.GetMinDetailPurchaseCost();
        }

        public void Add(DetailModel detail)
        {
            _uof.Details.Add(detail.ModelToEntity());
        }

        public void Remove(DetailModel detail)
        {
            var detailEntity = _uof.Details.Get(detail.Id);
            _uof.Details.Remove(detailEntity);
        }
        
        public double CheckDetails(CarModel car, double money)
        {
            var carEntity = _uof.Cars.Get(car.Id);
            carEntity.Details.ForEach(d =>
            {
                var r = new Random().NextDouble();
                if (r > d.Stability)
                {
                    d.IsBroken = true;
                }
            });
            carEntity.EntityToModelUpdate(car);
            
            _uof.Complete();
            return money;
        }

        public double RepairDetail(DetailModel detail, double money)
        {
            var detailEntity = _uof.Details.Get(detail.Id);
            detailEntity.IsBroken = false;

            detailEntity.EntityToModelUpdate(detail);

            _uof.Complete();
            return detail.RepairCost;
        }

        public bool DecrStabilityAfterRepair(DetailModel detail)
        {
            var detailEntity = _uof.Details.Get(detail.Id);
            if (detailEntity.Stability - detailEntity.CoeffDecrStability > 0.1)
            {
                detailEntity.Stability = Math.Round(detailEntity.Stability - detailEntity.CoeffDecrStability, 1);
                if (detailEntity.Stability - detailEntity.CoeffDecrStability < 0.1)
                {
                    detailEntity.CanBeRepaired = false;
                }
                detailEntity.EntityToModelUpdate(detail);
                return true;
            }

            _uof.Complete();
            return false;
        }

        public double ReplaceDetail(CarModel car, DetailModel detail, DetailModel detailToReplace, double money)
        {
            if (detail != detailToReplace)
            {
                var carEntity = _uof.Cars.Get(car.Id);
                var newDetailEntity = _uof.Details.Get(detail.Id);
                var detailToReplaceEntity = _uof.Details.Get(detailToReplace.Id);

                carEntity.Details.Remove(detailToReplaceEntity);
                carEntity.Details.Add(newDetailEntity);

                carEntity.EntityToModelUpdate(car);

                money -= detail.PurchaseCost;
                _uof.Complete();
            }
            return money;
        }
    }
}