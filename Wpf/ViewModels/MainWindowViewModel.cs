using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Mappers;
using Microsoft.Extensions.DependencyInjection;
using Models;
using Services;
using Wpf.UserControls;

namespace Wpf.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        //private readonly IServiceProvider _serviceProvider;
        
        private readonly ICarService _carService;
        
        private readonly IDetailService _detailService;

        private readonly HomeViewModel _homeViewModel;
        
        private readonly EngineViewModel _engineViewModel;
        
        private readonly AccumulatorViewModel _accumulatorViewModel;
        
        private readonly DiskViewModel _diskViewModel;
        
        private readonly CoeffMoneyPerKilometerViewModel _coeffMoneyPerKilometerViewModel;
        
        private readonly GameViewModel _gameViewModel;
        
        private readonly ResultViewModel _resultViewModel;
        
        public MainWindowViewModel(ICarService carService, IDetailService detailService, HomeViewModel homeViewModel,
            EngineViewModel engineViewModel, AccumulatorViewModel accumulatorViewModel, DiskViewModel diskViewModel, 
            CoeffMoneyPerKilometerViewModel coeffMoneyPerKilometerViewModel, GameViewModel gameViewModel, 
            ResultViewModel resultViewModel) {
            
            _carService = carService;
            _detailService = detailService;
            _homeViewModel = homeViewModel;
            _engineViewModel = engineViewModel;
            _accumulatorViewModel = accumulatorViewModel;
            _diskViewModel = diskViewModel;
            _coeffMoneyPerKilometerViewModel = coeffMoneyPerKilometerViewModel;
            _gameViewModel = gameViewModel;
            _resultViewModel = resultViewModel;
            
            LoadHomeControl();
            LoadHomeControlCommand = new RelayCommand(o => LoadHomeControl());
            LoadEngineControlCommand = new RelayCommand(o => LoadEngineControl());
            CloseApplicationCommand = new RelayCommand(o => CloseApplication());
            LoadAccumulatorControlCommand = new RelayCommand(o => LoadAccumulatorControl());
            LoadDiskControlCommand = new RelayCommand(o => LoadDiskControl());
            LoadCoeffMoneyPerKilometerControlCommand = new RelayCommand(o => LoadCoeffMoneyPerKilometerControl());
            CreateCarCommand = new RelayCommand(o => CreateCar());
            LoadGameControlCommand = new RelayCommand(o => LoadGameControl());
            MoveCommand = new RelayCommand(o => Move());
            RepairDetailCommand = new RelayCommand(o => RepairDetail());
            LoadResultControlCommand = new RelayCommand(o => LoadResultControl());
            ReplaceDetailCommand = new RelayCommand(o => ReplaceDetail());
        }

        private BaseViewModel _currentViewModel;
        public ICommand LoadEngineControlCommand { get; }
        public ICommand LoadHomeControlCommand { get; }
        public ICommand LoadAccumulatorControlCommand { get; }
        public ICommand LoadDiskControlCommand { get; }
        public ICommand LoadCoeffMoneyPerKilometerControlCommand { get; }
        public ICommand CloseApplicationCommand { get; }
        public ICommand CreateCarCommand { get; }
        public ICommand LoadGameControlCommand { get; }
        public ICommand MoveCommand { get; }
        public ICommand LoadResultControlCommand { get; }
        public ICommand RepairDetailCommand { get; }
        public ICommand ReplaceDetailCommand { get; }
        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value; 
                RaisePropertyChanged("CurrentViewModel");
            }
        }
        
        private double _coins = 100;

        public double Coins
        {
            get
            {
                if (_coins > 0) return _coins;
                return 0;
            }
            set

            {
                _coins = value;
                RaisePropertyChanged("Coins");
            }
        }
        private void LoadHomeControl()
        {
            CurrentViewModel = _homeViewModel;
        }
        private void LoadEngineControl()
        {
            CurrentViewModel = _engineViewModel;
        }
        private void LoadAccumulatorControl()
        {
            CurrentViewModel = _accumulatorViewModel;
        }
        private void LoadDiskControl()
        {
            CurrentViewModel = _diskViewModel;
        }
        private void LoadCoeffMoneyPerKilometerControl()
        {
            CurrentViewModel = _coeffMoneyPerKilometerViewModel;
        }
        private void LoadGameControl()
        {
            CurrentViewModel = _gameViewModel;
        }
        private void LoadResultControl()
        {
            CurrentViewModel = _resultViewModel;
        }
        private void CloseApplication()
        {
            Application.Current.Shutdown();
        }

        private EngineModel _selectedEngine;
        public EngineModel SelectedEngine
        {
            get => _selectedEngine;
            set
            {
                _selectedEngine = value;
                RaisePropertyChanged("SelectedEngine");
            }
        }
        
        private AccumulatorModel _selectedAccumulator;
        public AccumulatorModel SelectedAccumulator
        {
            get => _selectedAccumulator;
            set
            {
                _selectedAccumulator = value;
                RaisePropertyChanged("SelectedAccumulator");
            }
        }
        private DiskModel _selectedDiskSet;
        public DiskModel SelectedDiskSet
        {
            get => _selectedDiskSet;
            set
            {
                _selectedDiskSet = value;
                RaisePropertyChanged("SelectedDiskSet");
            }
        }

        private CarModel _car;
        public CarModel Car
        {
            get => _car;
            set
            {
                _car = value;
                RaisePropertyChanged("Car");
            }
        }

        private CarModel _tempCar = new();
        public CarModel TempCar
        {
            get => _tempCar;
            set
            {
                _tempCar = value;
                RaisePropertyChanged("TempCar");
            }
        }
        private void CreateCar()
        {
            if (!(TempCar.CoeffMoneyPerKilometer > 0) || !(TempCar.CoeffMoneyPerKilometer <= 0.5)) return;
            (Coins, Car) = _carService.CreateCar(SelectedEngine, SelectedAccumulator, SelectedDiskSet,
                TempCar.CoeffMoneyPerKilometer, Coins);

            LoadGameControl();
        }
        
        private bool _allDetailsAreRepaired = true;
        public bool AllDetailsAreRepaired
        {
            get => _allDetailsAreRepaired;
            set
            {
                _allDetailsAreRepaired = value;
                RaisePropertyChanged("AllDetailsAreRepaired");
            }
        }

        private bool _isReplaced;
        public bool IsReplaced
        {
            get => _isReplaced;
            set
            {
                _isReplaced = value;
                RaisePropertyChanged("IsReplaced");
            }
        }

        private void Move()
        {
            while (true)
            {
                foreach (var detailModel in _car.Details)
                {
                    if (!detailModel.IsBroken) continue;
                    AllDetailsAreRepaired = false;
                    break;
                }

                if (_allDetailsAreRepaired)
                {
                    double initialMileage = _car.Mileage;
                    _carService.IncreaseMileage(Car);
                    double mileageAfterMoving = _car.Mileage;
                    Coins = _carService.RiseMoney(_car, mileageAfterMoving - initialMileage, _coins);
                    CheckDetails(_car, _coins);
                    continue;
                }

                break;
            }
        }

        private DetailModel _detailToReplace;
        private bool _isEngine;
        private bool _isAccumulator;
        private bool _isDisk;
        private void CheckDetails(CarModel car, double coins)
        {
            Coins = _detailService.CheckDetails(car, coins); 
            SelectedEngine.Detail = _car.Details.Single(d => d.Id == _selectedEngine.Detail.Id);
            SelectedAccumulator.Detail = _car.Details.Single(d => d.Id == _selectedAccumulator.Detail.Id);
            SelectedDiskSet.Detail = _car.Details.Single(d => d.Id == _selectedDiskSet.Detail.Id);
            
        }
        private void RepairDetail()
        {
            foreach (var detailModel in _car.Details)
            {
                if (!detailModel.IsBroken) continue;
                if (_coins < detailModel.RepairCost)
                {
                    LoadResultControl();
                    break;
                }

                if (detailModel.CanBeRepaired)
                {
                    _detailService.DecrStabilityAfterRepair(detailModel);
                    Coins -= _detailService.RepairDetail(detailModel, _coins);
                }
                else
                {
                    _isReplaced = true;
                    if (SelectedEngine.Detail.Id == detailModel.Id)
                    {
                        _isEngine = true;
                        _isAccumulator = _isDisk = false;
                            
                        _detailToReplace = SelectedEngine.Detail;
                        LoadEngineControl();
                    }
                    else if (SelectedAccumulator.Detail.Id == detailModel.Id)
                    {
                        _isAccumulator = true;
                        _isEngine = _isDisk = false;
                            
                        _detailToReplace = SelectedAccumulator.Detail;
                        LoadAccumulatorControl();
                    }
                    else
                    {
                        _isDisk = true;
                        _isEngine = _isAccumulator = false;
                            
                        _detailToReplace = SelectedDiskSet.Detail; 
                        LoadDiskControl();
                    }
                }
            }
            AllDetailsAreRepaired = true;
        }
        private void ReplaceDetail()
        {
            if (_coins < _detailService.GetMinDetailPurchaseCost()) LoadResultControl();
            else
            {
                if (_isEngine) Coins = _detailService.ReplaceDetail(_car, _selectedEngine.Detail, _detailToReplace, _coins);
                if (_isAccumulator) Coins = _detailService.ReplaceDetail(_car, _selectedAccumulator.Detail, _detailToReplace, _coins);
                if (_isDisk) Coins = _detailService.ReplaceDetail(_car, _selectedDiskSet.Detail, _detailToReplace, _coins);
                LoadGameControl();
            }
        }
    }
}