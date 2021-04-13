using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Entities;
using Models;

namespace Mappers
{
    public static class DetailMapper
    {
        public static DetailEntity ModelToEntity(this DetailModel detail)
        {
            return new DetailEntity
            {
                Id = detail.Id,
                Stability = detail.Stability,
                PurchaseCost = detail.PurchaseCost,
                RepairCost = detail.RepairCost,
                IsBroken = detail.IsBroken,
                CanBeRepaired = detail.CanBeRepaired,
                CoeffDecrStability = detail.CoeffDecrStability,
                //Cars = detail.Cars?.Select(c => c.ModelToEntity()).ToList() ?? new List<CarEntity>()
            };
        }
        public static DetailEntity ModelToEntityUpdate(this DetailModel detailModel, DetailEntity detailEntity)
        {
            detailEntity.Id = detailModel.Id;
            detailEntity.Stability = detailModel.Stability;
            detailEntity.IsBroken = detailModel.IsBroken;
            detailEntity.CanBeRepaired = detailModel.CanBeRepaired;
            detailEntity.PurchaseCost = detailModel.PurchaseCost;
            detailEntity.RepairCost = detailModel.RepairCost;
            detailEntity.CoeffDecrStability = detailModel.CoeffDecrStability;
            return detailEntity;
        }
        public static DetailModel EntityToModel(this DetailEntity detail)
        {
            return new DetailModel
            {
                Id = detail.Id,
                Stability = detail.Stability,
                PurchaseCost = detail.PurchaseCost,
                RepairCost = detail.RepairCost,
                IsBroken = detail.IsBroken,
                CanBeRepaired = detail.CanBeRepaired,
                CoeffDecrStability = detail.CoeffDecrStability
            };
        }
        public static DetailModel EntityToModelUpdate(this DetailEntity detailEntity, DetailModel detailModel)
        {
            detailModel.Id = detailEntity.Id;
            detailModel.Stability = detailEntity.Stability;
            detailModel.IsBroken = detailEntity.IsBroken;
            detailModel.CanBeRepaired = detailEntity.CanBeRepaired;
            detailModel.PurchaseCost = detailEntity.PurchaseCost;
            detailModel.RepairCost = detailEntity.RepairCost;
            detailModel.CoeffDecrStability = detailEntity.CoeffDecrStability;
            return detailModel;
        }
    }
}