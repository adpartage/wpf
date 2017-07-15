using System.ComponentModel;

namespace StackOverflow
{
    public class ViewModelBase:INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
