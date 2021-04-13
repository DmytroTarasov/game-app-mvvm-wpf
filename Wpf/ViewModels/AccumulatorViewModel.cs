using System.Collections.ObjectModel;
using System.Linq;
using Models;
using Services;

namespace Wpf.ViewModels
{
    public class AccumulatorViewModel : BaseViewModel
    {
        public ObservableCollection<AccumulatorModel> Accumulators { get; }
        public AccumulatorViewModel(IAccumulatorService accumulatorService)
        {
            Accumulators = new ObservableCollection<AccumulatorModel> 
            (
                accumulatorService.GetAllWithDetails().ToList()
            );
        }

    }
}