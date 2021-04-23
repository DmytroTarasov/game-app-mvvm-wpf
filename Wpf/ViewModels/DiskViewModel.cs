using System.Collections.ObjectModel;
using System.Linq;
using Models;
using Services;

namespace Wpf.ViewModels
{
    public class DiskViewModel : BaseViewModel
    {
        public ObservableCollection<DiskModel> Disks { get; }
        
        private IDiskService _diskService;
        public DiskViewModel(IDiskService diskService)
        {
            _diskService = diskService;
            Disks = new ObservableCollection<DiskModel> 
            (
                _diskService.GetAllWithDetails().ToList()
            );
        }

    }
}