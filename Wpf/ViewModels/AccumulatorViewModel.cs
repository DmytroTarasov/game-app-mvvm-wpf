using System.Collections.ObjectModel;
using System.Linq;
using Models;
using Services;

namespace Wpf.ViewModels
{
    public class AccumulatorViewModel : BaseViewModel
    {
        public ObservableCollection<AccumulatorModel> Accumulators { get; }

        private IAccumulatorService _accumulatorService;
        public AccumulatorViewModel(IAccumulatorService accumulatorService)
        {
            _accumulatorService = accumulatorService;
            Accumulators = new ObservableCollection<AccumulatorModel> 
            (
                _accumulatorService.GetAllWithDetails().ToList()
            );
        }

    }
}