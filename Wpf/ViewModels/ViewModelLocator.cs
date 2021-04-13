using System;
using Microsoft.Extensions.DependencyInjection;
using Wpf.UserControls;

namespace Wpf.ViewModels
{
    public class ViewModelLocator
    {
        public MainWindowViewModel MainViewModel => App.ServiceProvider.GetService<MainWindowViewModel>();
        public HomeViewModel HomeViewModel => App.ServiceProvider.GetService<HomeViewModel>();
        public EngineViewModel EngineViewModel => App.ServiceProvider.GetService<EngineViewModel>();
        public AccumulatorViewModel AccumulatorViewModel => App.ServiceProvider.GetService<AccumulatorViewModel>();
        public DiskViewModel DiskViewModel => App.ServiceProvider.GetService<DiskViewModel>();
        public CoeffMoneyPerKilometerViewModel CoeffMoneyPerKilometerViewModel => App.ServiceProvider.GetService<CoeffMoneyPerKilometerViewModel>();
        public GameViewModel GameViewModel => App.ServiceProvider.GetService<GameViewModel>();
        public ResultViewModel ResultViewModel => App.ServiceProvider.GetService<ResultViewModel>();

    }
}