namespace ja_training_szponcenie.Models
{
    /// <summary>
    /// Represents a detected training interval
    /// </summary>
    public class Interval
    {
        public int Number { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan Duration => EndTime - StartTime;
        public double AveragePower { get; set; }
        public double NormalizedPower { get; set; }
        public int? AverageHeartRate { get; set; }
        public int? AverageCadence { get; set; }
        public int PowerZone { get; set; }
        public string ZoneName { get; set; } = string.Empty;
        public string ZoneColor { get; set; } = string.Empty;
        public IntervalType Type { get; set; }
        public bool IsIgnored { get; set; }

        public double PercentageFTP { get; set; }
        public double? PercentageMaxHR { get; set; }
    }

    public enum IntervalType
    {
        Jump,      // Sudden power increase
        Gradual    // Gradual power increase
    }
}
