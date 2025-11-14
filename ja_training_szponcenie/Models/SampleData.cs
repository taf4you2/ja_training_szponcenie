using System;
using System.Collections.Generic;

namespace ja_training_szponcenie.Models
{
    /// <summary>
    /// Przykładowe dane dla widoku Records i Power Curve (tylko UI, bez logiki)
    /// </summary>
    public static class SampleData
    {
        public static List<PowerCurvePoint> GetPowerCurveData()
        {
            return new List<PowerCurvePoint>
            {
                new PowerCurvePoint { Duration = "5s", Seconds = 5, Power = 856, WattsPerKg = 11.4, PercentFTP = 300, Date = new DateTime(2025, 11, 9), TrainingName = "Evening intervals", IsNewRecord = true },
                new PowerCurvePoint { Duration = "10s", Seconds = 10, Power = 782, WattsPerKg = 10.4, PercentFTP = 274, Date = new DateTime(2025, 9, 22), TrainingName = "Sprint session" },
                new PowerCurvePoint { Duration = "15s", Seconds = 15, Power = 721, WattsPerKg = 9.6, PercentFTP = 253, Date = new DateTime(2025, 11, 9), TrainingName = "Evening intervals", IsNewRecord = true },
                new PowerCurvePoint { Duration = "20s", Seconds = 20, Power = 685, WattsPerKg = 9.1, PercentFTP = 240, Date = new DateTime(2025, 10, 15), TrainingName = "Race simulation" },
                new PowerCurvePoint { Duration = "30s", Seconds = 30, Power = 598, WattsPerKg = 7.9, PercentFTP = 210, Date = new DateTime(2025, 11, 9), TrainingName = "Evening intervals", IsNewRecord = true },
                new PowerCurvePoint { Duration = "45s", Seconds = 45, Power = 520, WattsPerKg = 6.9, PercentFTP = 182, Date = new DateTime(2025, 10, 28), TrainingName = "Threshold work" },
                new PowerCurvePoint { Duration = "1min", Seconds = 60, Power = 412, WattsPerKg = 5.5, PercentFTP = 145, Date = new DateTime(2025, 10, 28), TrainingName = "VO2max intervals" },
                new PowerCurvePoint { Duration = "2min", Seconds = 120, Power = 387, WattsPerKg = 5.1, PercentFTP = 136, Date = new DateTime(2025, 10, 12), TrainingName = "Climbing workout" },
                new PowerCurvePoint { Duration = "3min", Seconds = 180, Power = 356, WattsPerKg = 4.7, PercentFTP = 125, Date = new DateTime(2025, 10, 28), TrainingName = "VO2max intervals" },
                new PowerCurvePoint { Duration = "5min", Seconds = 300, Power = 324, WattsPerKg = 4.3, PercentFTP = 114, Date = new DateTime(2025, 11, 9), TrainingName = "Evening intervals", IsNewRecord = true },
                new PowerCurvePoint { Duration = "8min", Seconds = 480, Power = 312, WattsPerKg = 4.1, PercentFTP = 109, Date = new DateTime(2025, 10, 5), TrainingName = "Threshold test" },
                new PowerCurvePoint { Duration = "10min", Seconds = 600, Power = 305, WattsPerKg = 4.0, PercentFTP = 107, Date = new DateTime(2025, 9, 22), TrainingName = "Long intervals" },
                new PowerCurvePoint { Duration = "20min", Seconds = 1200, Power = 295, WattsPerKg = 3.9, PercentFTP = 104, Date = new DateTime(2025, 8, 15), TrainingName = "FTP test" },
                new PowerCurvePoint { Duration = "30min", Seconds = 1800, Power = 278, WattsPerKg = 3.7, PercentFTP = 98, Date = new DateTime(2025, 9, 8), TrainingName = "Endurance ride" },
                new PowerCurvePoint { Duration = "60min", Seconds = 3600, Power = 245, WattsPerKg = 3.3, PercentFTP = 86, Date = new DateTime(2025, 7, 10), TrainingName = "Long ride" },
            };
        }

        public static List<HeartRateRecord> GetHeartRateRecords()
        {
            return new List<HeartRateRecord>
            {
                new HeartRateRecord { Type = "Maksymalne tętno", Value = 189, Date = new DateTime(2025, 8, 22), TrainingName = "Sprint finish" },
                new HeartRateRecord { Type = "Najniższe RHR", Value = 44, Date = new DateTime(2025, 8, 5), TrainingName = "Szczyt formy" },
                new HeartRateRecord { Type = "Najwyższe HRV", Value = 78, Date = new DateTime(2025, 10, 15), TrainingName = "Doskonała regeneracja" },
            };
        }

        public static List<OtherRecord> GetOtherRecords()
        {
            return new List<OtherRecord>
            {
                new OtherRecord { Category = "Dystans", Type = "Najdłuższy trening", Value = "185.4 km", SecondaryValue = "6h 45min", Date = new DateTime(2025, 9, 12), TrainingName = "Gran fondo training" },
                new OtherRecord { Category = "Przewyższenie", Type = "Największe przewyższenie", Value = "2,340 m", SecondaryValue = "142 km", Date = new DateTime(2025, 8, 28), TrainingName = "Mountain training" },
                new OtherRecord { Category = "Prędkość", Type = "Maksymalna prędkość", Value = "67.4 km/h", Date = new DateTime(2025, 11, 9), TrainingName = "Evening ride (zjazd)" },
            };
        }
    }

    public class PowerCurvePoint
    {
        public string Duration { get; set; } = string.Empty;
        public int Seconds { get; set; }
        public int Power { get; set; }
        public double WattsPerKg { get; set; }
        public int PercentFTP { get; set; }
        public DateTime Date { get; set; }
        public string TrainingName { get; set; } = string.Empty;
        public bool IsNewRecord { get; set; }
        public string TimeInTraining { get; set; } = "06:15";
        public int HeartRate { get; set; } = 178;
        public int Cadence { get; set; } = 98;
    }

    public class HeartRateRecord
    {
        public string Type { get; set; } = string.Empty;
        public int Value { get; set; }
        public DateTime Date { get; set; }
        public string TrainingName { get; set; } = string.Empty;
    }

    public class OtherRecord
    {
        public string Category { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string SecondaryValue { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string TrainingName { get; set; } = string.Empty;
    }
}
