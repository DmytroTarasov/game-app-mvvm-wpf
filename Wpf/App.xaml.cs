using System;
using System.Windows;
using Data;
using Entities;
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
                detailEntity.IsBroken = false;
                detailEntity.CanBeRepaired = true;
            }
            context.SaveChanges();
            
            var window = ServiceProvider.GetRequiredService<MainWindow>();
            window.Show();
            base.OnStartup(e);

                //
            // DetailEntity de1 = new DetailEntity
            // {
            //     Stability = 0.5,
            //     PurchaseCost = 12,
            //     RepairCost = 9,
            //     CoeffDecrStability = 0.2,
            //     CanBeRepaired = true,System.Linq.IQueryable.Expression (DbSet<DetailEntity>) = {Expression} Exception of type 'System.NotSupportedException' was thrown 
            //     IsBroken = false
            // };
            // AccumulatorEntity ae1 = new AccumulatorEntity()
            // {
            //     DetailId = de1.Id,
            //     Capacity = 28
            // };
            //
            //
            // DetailEntity de2 = new DetailEntity
            // {
            //     Stability = 0.4,
            //     PurchaseCost = 10,
            //     RepairCost = 6,
            //     CoeffDecrStability = 0.2,
            //     CanBeRepaired = true,
            //     IsBroken = false
            // };
            //
            // DiskEntity dd1 = new DiskEntity()
            // {
            //     Diameter = 30,
            //     DetailId = de2.Id
            // };
            // context.Details.Add(de1);
            // context.Details.Add(de2);
            // context.Accumulators.Add(ae1);
            // context.Disks.Add(dd1);
            // context.SaveChanges();
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