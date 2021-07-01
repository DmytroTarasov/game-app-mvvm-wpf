using System;
using System.Windows;
using Data;
using Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Services;
using ServicesImpl;
using Wpf.ViewModels;

namespace Wpf
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        
        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var window = ServiceProvider.GetRequiredService<MainWindow>();
            window.Show();
            base.OnStartup(e);
        }
        private void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>();

            services.AddSingleton<ICarRepository, CarRepository>();
            services.AddSingleton<IDetailRepository, DetailRepository>();
            services.AddSingleton<IEngineRepository, EngineRepository>();
            services.AddSingleton<IDiskRepository, DiskRepository>();
            services.AddSingleton<IAccumulatorRepository, AccumulatorRepository>();
            
            services.AddSingleton(sp => sp);
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IAccumulatorService, AccumulatorService>();
            services.AddSingleton<IDiskService, DiskService>();
            services.AddSingleton<IEngineService, EngineService>();
            services.AddSingleton<ICarService, CarService>();
            services.AddSingleton<IDetailService, DetailService>();

            // services.AddTransient(sp => new MainWindowViewModel(sp.GetRequiredService<ICarService>(),
            //     sp.GetRequiredService<IDetailService>(), sp.GetRequiredService<HomeViewModel>(),
            //     sp.GetRequiredService<EngineViewModel>(), sp.GetRequiredService<AccumulatorViewModel>(),
            //     sp.GetRequiredService<DiskViewModel>(), sp.GetRequiredService<CoeffMoneyPerKilometerViewModel>(),
            //     sp.GetRequiredService<GameViewModel>(), sp.GetRequiredService<ResultViewModel>()));
            // services.AddTransient(sp => new HomeViewModel());
            // services.AddTransient(sp => new EngineViewModel(sp.GetRequiredService<IEngineService>()));
            // services.AddTransient(sp => new AccumulatorViewModel(sp.GetRequiredService<IAccumulatorService>()));
            // services.AddTransient(sp => new DiskViewModel(sp.GetRequiredService<IDiskService>()));
            // services.AddTransient(sp => new CoeffMoneyPerKilometerViewModel());
            // services.AddTransient(sp => new GameViewModel());
            // services.AddTransient(sp => new ResultViewModel());

            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<HomeViewModel>();
            services.AddTransient<EngineViewModel>();
            services.AddTransient<AccumulatorViewModel>();
            services.AddTransient<DiskViewModel>();
            services.AddTransient<CoeffMoneyPerKilometerViewModel>();
            services.AddTransient<GameViewModel>();
            services.AddTransient<ResultViewModel>();
            
            services.AddSingleton<MainWindow>();
        }
    }
}