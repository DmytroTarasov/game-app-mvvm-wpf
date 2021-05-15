using System;

namespace Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICarRepository Cars { get; set; }
        IEngineRepository Engines { get; set;}
        IAccumulatorRepository Accumulators { get; set;}
        IDiskRepository Disks { get; set;}
        IDetailRepository Details { get; set;}
        void Complete();
    }
}