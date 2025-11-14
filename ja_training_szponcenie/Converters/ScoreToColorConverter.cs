using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace ja_training_szponcenie.Converters
{
    public class ScoreToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int score)
            {
                if (score >= 80)
                    return new SolidColorBrush(Color.FromRgb(76, 175, 80)); // Green
                else if (score >= 60)
                    return new SolidColorBrush(Color.FromRgb(255, 193, 7)); // Yellow
                else
                    return new SolidColorBrush(Color.FromRgb(244, 67, 54)); // Red
            }
            return new SolidColorBrush(Colors.Gray);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
