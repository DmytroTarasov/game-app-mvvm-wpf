using System;
using System.Collections.Generic;
using Models;

namespace Services
{
    public interface IDetailService
    {
        DetailModel Get(Guid id);
        IEnumerable<DetailModel> GetAll();
        public double GetMinDetailPurchaseCost();
        void Add(DetailModel detail);
        void Remove(DetailModel detail);
        double CheckDetails(CarModel car, double money);
        double RepairDetail(DetailModel detail, double money);
        bool DecrStabilityAfterRepair(DetailModel detail);
        double ReplaceDetail(CarModel car, DetailModel detail, DetailModel detailToReplace, double money);
    }
}