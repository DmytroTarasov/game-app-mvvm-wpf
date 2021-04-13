using System.ComponentModel;

namespace Models
{
    public class BaseModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            // var handler = PropertyChanged; 
            //
            // if (handler != null)
            // {
            //     handler(this, new PropertyChangedEventArgs(propertyName));
            // }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}