using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Models
{
    public class CarModel : BaseModel, IDataErrorInfo
    {
        private double _mileage;
        private double _coeffMoneyPerKilometer;
        private Guid _id;
        private ObservableCollection<DetailModel> _details;

        public double Mileage {
            get => _mileage;
            set
            {
                _mileage = value;
                RaisePropertyChanged("Mileage");
            } 
        }
        public double CoeffMoneyPerKilometer
        {
            get => _coeffMoneyPerKilometer;
            set
            {
                _coeffMoneyPerKilometer = value;
                RaisePropertyChanged("CoeffMoneyPerKilometer");
            }
        }

        public ObservableCollection<DetailModel> Details
        {
            get => _details;
            set
            {
                _details = value;
                RaisePropertyChanged("Details");
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
        public string Error
        {
            get
            {
                return null;
            }
        }
        public string this[string name]
        {
            get
            {
                string result = null;

                if (name == "CoeffMoneyPerKilometer")
                {
                    if (CoeffMoneyPerKilometer <= 0 || CoeffMoneyPerKilometer > 0.5)
                    {
                        result = "CoeffMoneyPerKilometer must not be less than 0 or greater than 0.5";
                    }
                }
                return result;
            }
        }
    }
}