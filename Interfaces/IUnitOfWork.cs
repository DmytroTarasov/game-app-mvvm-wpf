using System;

namespace Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICarRepository Cars { get; }
        IEngineRepository Engines { get; }
        IAccumulatorRepository Accumulators { get; }
        IDiskRepository Disks { get; }
        IDetailRepository Details { get; }
        void Complete();
    }
}