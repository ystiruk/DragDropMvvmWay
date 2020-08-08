using System.Windows;

namespace WpfApplication.Mvvm
{
    public class MainWindowViewModel : ViewModelBase
    {
        private IDataObject _dropData;
        public IDataObject DropData
        {
            get { return _dropData; }
            set { SetProperty(ref _dropData, value); }
        }
    }
}
