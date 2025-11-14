using System;
using System.Globalization;
using System.Windows.Data;
using ja_training_szponcenie.Models;

namespace ja_training_szponcenie.Converters
{
    public class DayTypeToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DayType dayType)
            {
                return dayType switch
                {
                    DayType.TrainingDay => "🏋️ Dzień treningowy",
                    DayType.RestDay => "😴 Dzień odpoczynku",
                    DayType.RaceDay => "🏆 Wyścig",
                    DayType.WarningDay => "⚠️ Uwaga",
                    _ => ""
                };
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
