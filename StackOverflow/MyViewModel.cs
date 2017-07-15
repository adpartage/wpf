using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace StackOverflow
{
    public class MyViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public MyViewModel(string textBoxValue)
        {
            ChooseGameCommand = new RelayCommand<object>(_ => ChooseGameCommandHandler(), _ => !string.IsNullOrEmpty(TextBoxValue));
            TextBoxValue = textBoxValue;
        }

        public MyViewModel() : this(string.Empty) { }

        public string TextBoxValue { get; set; }

        private bool _isvisible = true;
        public bool IsVisible
        {
            get { return _isvisible; }
            set
            {
                if (_isvisible != value)
                {
                    _isvisible = value;
                    RaisePropertyChanged(nameof(IsVisible));
                }
            }
        }

        private void ChooseGameCommandHandler()
        {
            var window = new MainWindow();
            window.DataContext = new MyViewModel(TextBoxValue);
            window.Show();
            IsVisible = false;
        }

        public ICommand ChooseGameCommand { get; private set; }        
    }
}
