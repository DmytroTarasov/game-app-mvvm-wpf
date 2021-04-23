using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
using Models;
using Services;
using ServicesImpl;

namespace Wpf.ViewModels
{
    public class EngineViewModel : BaseViewModel
    {
        public ObservableCollection<EngineModel> Engines { get; }
        
        private IEngineService _engineService;
        public EngineViewModel(IEngineService engineService)
        {
            _engineService = engineService;
            Engines = new ObservableCollection<EngineModel> 
            (
                _engineService.GetAllWithDetails().ToList()
            );
        }
    }
}