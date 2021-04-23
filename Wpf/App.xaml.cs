using System;
using System.Windows;
using Data;
using Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Services;
using ServicesImpl;
using Wpf.UserControls;
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

            DataContext context = ServiceProvider.GetRequiredService<DataContext>();
            
            foreach (var detailEntity in context.Details)
            {
                detailEntity.Stability = 0.9;
                detailEntity.IsBroken = false;
                detailEntity.CanBeRepaired = true;
            }
            context.SaveChanges();
            
            var window = ServiceProvider.GetRequiredService<MainWindow>();
            window.Show();
            base.OnStartup(e);
        }
        private void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>();

            services.AddSingleton(sp => sp);
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IAccumulatorService, AccumulatorService>();
            services.AddSingleton<IDiskService, DiskService>();
            services.AddSingleton<IEngineService, EngineService>();
            services.AddSingleton<ICarService, CarService>();
            services.AddSingleton<IDetailService, DetailService>();

            services.AddTransient(sp => new MainWindowViewModel(sp.GetRequiredService<ICarService>(),
                sp.GetRequiredService<IDetailService>(), sp.GetRequiredService<HomeViewModel>(),
                sp.GetRequiredService<EngineViewModel>(), sp.GetRequiredService<AccumulatorViewModel>(),
                sp.GetRequiredService<DiskViewModel>(), sp.GetRequiredService<CoeffMoneyPerKilometerViewModel>(),
                sp.GetRequiredService<GameViewModel>(), sp.GetRequiredService<ResultViewModel>()));
            services.AddTransient(sp => new HomeViewModel());
            services.AddTransient(sp => new EngineViewModel(sp.GetRequiredService<IEngineService>()));
            services.AddTransient(sp => new AccumulatorViewModel(sp.GetRequiredService<IAccumulatorService>()));
            services.AddTransient(sp => new DiskViewModel(sp.GetRequiredService<IDiskService>()));
            services.AddTransient(sp => new CoeffMoneyPerKilometerViewModel());
            services.AddTransient(sp => new GameViewModel());
            services.AddTransient(sp => new ResultViewModel());
            
            services.AddSingleton<MainWindow>();
            services.AddSingleton<HomeControl>();
            services.AddSingleton<EngineControl>();
            services.AddSingleton<AccumulatorControl>();
            services.AddSingleton<DiskControl>();
            services.AddSingleton<CoeffMoneyPerKilometerControl>();
            services.AddSingleton<GameControl>();
            services.AddSingleton<ResultControl>();
        }
    }
}