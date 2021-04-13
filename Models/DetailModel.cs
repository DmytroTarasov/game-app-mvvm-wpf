using System;
using System.Collections.ObjectModel;

namespace Models
{
    public class DetailModel : BaseModel
    {
        private double _stability;
        private double _purchaseCost;
        private double _repairCost;
        private bool _isBroken;
        private bool _canBeRepaired;
        private double _coeffDecrStability;
        private Guid _id;
        private ObservableCollection<CarModel> _cars;
        public double Stability
        {
            get => _stability;
            set
            {
                _stability = value;
                RaisePropertyChanged("Stability");
            }
        }
        public double PurchaseCost
        {
            get => _purchaseCost;
            set
            {
                _purchaseCost = value;
                RaisePropertyChanged("PurchaseCost");
            }
        }
        
        public double RepairCost
        {
            get => _repairCost;
            set
            {
                _repairCost = value;
                RaisePropertyChanged("RepairCost");
            }
        }
        public bool IsBroken
        {
            get => _isBroken;
            set
            {
                _isBroken = value;
                RaisePropertyChanged("IsBroken");
            }
        }
        public bool CanBeRepaired
        {
            get => _canBeRepaired;
            set
            {
                _canBeRepaired = value;
                RaisePropertyChanged("CanBeRepaired");
            }
        }
        public double CoeffDecrStability
        {
            get => _coeffDecrStability;
            set
            {
                _coeffDecrStability = value;
                RaisePropertyChanged("CoeffDecrStability");
            }
        }
        public ObservableCollection<CarModel> Cars
        {
            get => _cars;
            set
            {
                _cars = value;
                RaisePropertyChanged("Cars");
            }
        }
        public Guid Id
        {
            get => _id;
            set
            {
                _id = value;
                RaisePropertyChanged("Id");
            }
        }
    }
}