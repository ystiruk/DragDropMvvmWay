using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WpfApplication
{
    [ValueConversion(typeof(IDataObject), typeof(string))]
    public class DataObjectToFileNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            IDataObject dataObject = value as IDataObject;

            if (dataObject == null) 
                return null;

            string[] fileNames = dataObject.GetData(DataFormats.FileDrop) as string[];
            if (fileNames == null)
                return null;

            return fileNames[0];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
