using System.Collections.ObjectModel;
using System.Linq;
using Models;
using Services;

namespace Wpf.ViewModels
{
    public class DiskViewModel : BaseViewModel
    {
        public ObservableCollection<DiskModel> Disks { get; }
        public DiskViewModel(IDiskService diskService)
        {
            Disks = new ObservableCollection<DiskModel> 
            (
                diskService.GetAllWithDetails().ToList()
            );
        }

    }
}