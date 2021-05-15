using Data;
using Interfaces;

namespace Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public DataContext Context { get; }
        public ICarRepository Cars { get; set; }
        public IEngineRepository Engines { get; set; }
        public IAccumulatorRepository Accumulators { get; set; }
        public IDiskRepository Disks { get; set; }
        public IDetailRepository Details { get; set; }
        public UnitOfWork(DataContext context, ICarRepository carRepository, IEngineRepository engineRepository,
            IAccumulatorRepository accumulatorRepository, IDiskRepository diskRepository,
            IDetailRepository detailRepository)
        {
            Context = context;
            Cars = carRepository;
            Engines = engineRepository;
            Accumulators = accumulatorRepository;
            Disks = diskRepository;
            Details = detailRepository;
        }
        public void Complete()
        {
            Context.SaveChanges();
        }
        public void Dispose()
        {
            Context.Dispose();
        }
        
    }
}