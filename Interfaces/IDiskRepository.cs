using System;
using System.Collections.Generic;
using Entities;

namespace Interfaces
{
    public interface IDiskRepository : IRepository<DiskEntity, Guid>
    {
        //IEnumerable<DiskEntity> GetDiskSet(DiskEntity disk);
        public IEnumerable<DiskEntity> GetAllWithDetails();
    }
}