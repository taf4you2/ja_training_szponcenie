using System;
using System.Collections.Generic;

namespace ja_training_szponcenie.Models
{
    public class HeartRate
    {
        // Daily metrics
        public int RestingHeartRate { get; set; }
        public int RHRBaselineChange { get; set; }
        public int AverageDailyHR { get; set; }
        public int MaxHeartRate { get; set; }
        public DateTime MaxHRTime { get; set; }
        public int MorningHRV { get; set; }
        public int HRVBaselineChange { get; set; }

        // 24h HR data
        public List<HeartRateDataPoint> HRData { get; set; } = new();

        // Time in HR zones (full day)
        public Dictionary<TrainingZone, TimeSpan> ZoneTimes { get; set; } = new();
    }

    public class HeartRateDataPoint
    {
        public DateTime Time { get; set; }
        public int HeartRate { get; set; }
        public bool IsDuringTraining { get; set; }
    }
}
