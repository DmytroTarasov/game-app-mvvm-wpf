using Data;
using Interfaces;

namespace Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private CarRepository _carRepository;
        private EngineRepository _engineRepository;
        private AccumulatorRepository _accumulatorRepository;
        private DiskRepository _diskRepository;
        private DetailRepository _detailRepository;
        
        public UnitOfWork(DataContext context)
        {
            _context = context;
        }
        
        public ICarRepository Cars
        {
            get
            {
                if (_carRepository == null)
                    _carRepository = new CarRepository(_context);
                return _carRepository;
            }
        }
        
        public IEngineRepository Engines
        {
            get
            {
                if (_engineRepository == null)
                    _engineRepository = new EngineRepository(_context);
                return _engineRepository;
            }
        }

        public IAccumulatorRepository Accumulators 
        {
            get
            {
                if (_accumulatorRepository == null)
                    _accumulatorRepository = new AccumulatorRepository(_context);
                return _accumulatorRepository;
            }
        }
        public IDiskRepository Disks 
        {
            get
            {
                if (_diskRepository == null)
                    _diskRepository = new DiskRepository(_context);
                return _diskRepository;
            }
        }
        public IDetailRepository Details 
        {
            get
            {
                if (_detailRepository == null)
                    _detailRepository = new DetailRepository(_context);
                return _detailRepository;
            }
        }
        public void Complete()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}