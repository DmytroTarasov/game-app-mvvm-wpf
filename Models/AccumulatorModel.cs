namespace Models
{
    public class AccumulatorModel : BaseModel
    {
        private int _capacity;
        private DetailModel _detail;
        public int Capacity
        {
            get => _capacity;
            set
            {
                _capacity = value;
                RaisePropertyChanged("Capacity");
            }
        }
        public DetailModel Detail
        {
            get => _detail;
            set
            {
                _detail = value;
                RaisePropertyChanged("Detail");
            }
        }
    }
}