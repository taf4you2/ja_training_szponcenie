namespace ja_training_szponcenie.Models
{
    /// <summary>
    /// Context information about the athlete's state before/during training
    /// </summary>
    public class ContextData
    {
        // Sleep data from previous night
        public TimeSpan? SleepDuration { get; set; }
        public int? SleepScore { get; set; } // 0-100
        public string SleepQuality { get; set; } = string.Empty;

        // HRV (Heart Rate Variability) from morning
        public int? HRV { get; set; } // ms
        public int? HRVBaseline { get; set; } // ms
        public int? HRVDifference => HRV.HasValue && HRVBaseline.HasValue ? HRV.Value - HRVBaseline.Value : null;
        public string RecoveryStatus { get; set; } = string.Empty;

        // Nutrition
        public int? CaloriesBeforeTraining { get; set; }

        // Training load
        public int? TSB { get; set; } // Training Stress Balance (Form)
        public string FormStatus { get; set; } = string.Empty;

        // Overall assessment
        public ContextAssessment Assessment { get; set; }
        public string AssessmentText { get; set; } = string.Empty;
    }

    public enum ContextAssessment
    {
        Optimal,
        Good,
        Fair,
        Poor,
        Fatigue
    }
}
