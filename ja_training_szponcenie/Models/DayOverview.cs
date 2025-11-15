using System;

namespace ja_training_szponcenie.Models
{
    public class DayOverview
    {
        public DateTime Date { get; set; }
        public DayType DayType { get; set; }
        public int OverallScore { get; set; }
        public string OverallScoreText { get; set; } = string.Empty;
        public int TSS { get; set; }
        public TimeSpan TrainingTime { get; set; }
        public int Calories { get; set; }
        public TimeSpan SleepTime { get; set; }
        public int SleepScore { get; set; }
        public int HRV { get; set; }
        public int ReadinessScore { get; set; }
        public string ReadinessText { get; set; } = string.Empty;
    }
}
