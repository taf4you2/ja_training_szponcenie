namespace ja_training_szponcenie.Models
{
    /// <summary>
    /// Time spent in a power or heart rate zone
    /// </summary>
    public class TimeInZone
    {
        public int ZoneNumber { get; set; }
        public string ZoneName { get; set; } = string.Empty;
        public string ZoneDescription { get; set; } = string.Empty;
        public string ZoneColor { get; set; } = string.Empty;
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public TimeSpan Time { get; set; }
        public double Percentage { get; set; }
        public double AverageValue { get; set; }

        public string RangeText { get; set; } = string.Empty;
        public string TimeText { get; set; } = string.Empty;
    }
}
