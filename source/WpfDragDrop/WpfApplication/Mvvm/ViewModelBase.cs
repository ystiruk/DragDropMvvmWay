using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApplication.Mvvm
{
    public abstract class ViewModelBase: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public void SetProperty<T>(ref T member, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(member, value))
                return;

            member = value;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
