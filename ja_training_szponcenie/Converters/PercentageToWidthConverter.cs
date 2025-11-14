using System.Globalization;
using System.Windows.Data;

namespace ja_training_szponcenie.Converters
{
    public class PercentageToWidthConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length != 2)
                return 0.0;

            if (values[0] is double percentage && values[1] is double totalWidth)
            {
                return (percentage / 100.0) * totalWidth;
            }

            return 0.0;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
