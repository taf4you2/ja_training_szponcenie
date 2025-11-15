namespace ja_training_szponcenie.Models
{
    /// <summary>
    /// Represents a single data point in the training session
    /// </summary>
    public class DataPoint
    {
        public TimeSpan Time { get; set; }
        public double Power { get; set; }
        public int? HeartRate { get; set; }
        public int? Cadence { get; set; }
        public double? Speed { get; set; }
        public double? Altitude { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public double? Temperature { get; set; }
        public int? PowerZone { get; set; }
        public int? HeartRateZone { get; set; }
    }
}
