using System.Windows;

namespace WpfApplication.Mvvm
{
    public class MainWindowViewModel : ViewModelBase
    {
        private IDataObject _dragData;
        public IDataObject DragData
        {
            get { return _dragData; }
            set { SetProperty(ref _dragData, value); }
        }
    }
}
