using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Mappers;
using Models;
using Services;

namespace ServicesImpl
{
    public class DiskService : IDiskService
    {
        private readonly IUnitOfWork _uof;

        public DiskService(IUnitOfWork uof)
        {
            _uof = uof;
        }
        public void Add(DiskModel disk)
        {
            _uof.Disks.Add(disk.ModelToEntity());
        }
        public DiskModel Get(Guid detailId)
        {
            return _uof.Disks.Get(detailId).EntityToModel();
        }
        public IEnumerable<DiskModel> GetAll()
        {
            return _uof.Disks.GetAll().Select(d => d.EntityToModel()).ToList();
        }
        public IEnumerable<DiskModel> GetAllWithDetails()
        {
            return _uof.Disks.GetAllWithDetails().Select(d => d.EntityToModel()).ToList();
        }
        public void Remove(DiskModel disk)
        {
            var diskEntity = _uof.Disks.Get(disk.Detail.Id);
            _uof.Disks.Remove(diskEntity);
        }
    }
}