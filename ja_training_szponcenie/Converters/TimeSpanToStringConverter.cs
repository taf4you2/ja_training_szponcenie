using System;
using System.Globalization;
using System.Windows.Data;

namespace ja_training_szponcenie.Converters
{
    public class TimeSpanToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TimeSpan timeSpan)
            {
                if (timeSpan.TotalHours >= 1)
                    return $"{(int)timeSpan.TotalHours}h {timeSpan.Minutes}min";
                else
                    return $"{timeSpan.Minutes}min";
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
