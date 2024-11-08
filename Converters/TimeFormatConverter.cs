using System.Globalization;
using System.Windows.Data;

namespace WpfApp1.Converters
{
    public class TimeFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime dateTime)
            {
                // Gibt die Uhrzeit im 24-Stunden-Format zurück
                return dateTime.ToString("HH:mm");
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException(); // Nur eine Einweg-Konvertierung
        }
    }
}

