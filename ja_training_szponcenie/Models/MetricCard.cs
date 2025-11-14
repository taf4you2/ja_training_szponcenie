namespace ja_training_szponcenie.Models
{
    /// <summary>
    /// Represents a metric card/tile in the UI
    /// </summary>
    public class MetricCard
    {
        public string Title { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string? SubValue { get; set; }
        public string Icon { get; set; } = string.Empty;
        public string BackgroundColor { get; set; } = string.Empty;
        public string ForegroundColor { get; set; } = "#000000";
    }
}
