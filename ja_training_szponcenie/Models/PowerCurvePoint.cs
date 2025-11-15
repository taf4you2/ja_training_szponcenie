namespace ja_training_szponcenie.Models
{
    /// <summary>
    /// Mean maximal power for a specific duration
    /// </summary>
    public class PowerCurvePoint
    {
        public TimeSpan Duration { get; set; }
        public double Power { get; set; }
        public double WattsPerKg { get; set; }
        public double PercentageFTP { get; set; }
        public TimeSpan? TimeAchieved { get; set; }
        public bool IsPersonalRecord { get; set; }
        public double? PreviousRecord { get; set; }
        public DateTime? PreviousRecordDate { get; set; }
        public double? Improvement { get; set; }
        public double? ImprovementPercentage { get; set; }

        public string DurationText { get; set; } = string.Empty;
    }
}
