using System;

namespace Models
{
    public class EngineModel : BaseModel
    {
        private string _type;
        private DetailModel _detail;
        public string Type
        {
            get => _type;
            set
            {
                _type = value;
                RaisePropertyChanged("Type");
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