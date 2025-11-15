using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using ja_training_szponcenie.Models;

namespace ja_training_szponcenie.Converters
{
    public class DayTypeToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DayType dayType)
            {
                return dayType switch
                {
                    DayType.TrainingDay => Application.Current.FindResource("TrainingDayBrush"),
                    DayType.RestDay => Application.Current.FindResource("RestDayBrush"),
                    DayType.RaceDay => Application.Current.FindResource("RaceDayBrush"),
                    DayType.WarningDay => Application.Current.FindResource("WarningDayBrush"),
                    _ => new SolidColorBrush(Colors.Gray)
                };
            }
            return new SolidColorBrush(Colors.Gray);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
