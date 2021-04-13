namespace Models
{
    public class DiskModel : BaseModel
    {
        private int _diameter;
        private DetailModel _detail;
        
        public int Diameter
        {
            get => _diameter;
            set
            {
                _diameter = value;
                RaisePropertyChanged("Diameter");
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