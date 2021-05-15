using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Entities;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class DiskRepository : Repository<DiskEntity, Guid>, IDiskRepository
    {
        public DiskRepository(DataContext context) : base(context) { }
        
        // public IEnumerable<DiskEntity> GetDiskSet(DiskEntity disk)
        // {
        //     return Context.Disks.Where(d => d.Diameter == disk.Diameter && d.DetailId != disk.DetailId).Take(3)
        //         .ToList();
        // }
        public IEnumerable<DiskEntity> GetAllWithDetails()
        {
            return Context.Disks
                .Include(e => e.Detail)
                .Where(d => d.Detail.Stability - d.Detail.CoeffDecrStability > 0.1)
                .ToList();
        }
    }
}