using System;
using System.Collections.Generic;
using Models;

namespace Services
{
    public interface IDiskService
    {
        DiskModel Get(Guid detailId);
        IEnumerable<DiskModel> GetAll();
        IEnumerable<DiskModel> GetAllWithDetails();
        void Add(DiskModel disks);
        void Remove(DiskModel disks);
    }
}