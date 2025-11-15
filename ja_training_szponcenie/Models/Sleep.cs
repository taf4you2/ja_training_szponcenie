using System;
using System.Collections.Generic;

namespace ja_training_szponcenie.Models
{
    public class Sleep
    {
        public int SleepScore { get; set; }
        public TimeSpan TotalSleepTime { get; set; }
        public DateTime BedTime { get; set; }
        public DateTime WakeTime { get; set; }
        public double SleepEfficiency { get; set; } // %
        public string QualityText { get; set; } = string.Empty;

        // Sleep phases
        public TimeSpan DeepSleepTime { get; set; }
        public double DeepSleepPercent { get; set; }
        public TimeSpan REMSleepTime { get; set; }
        public double REMSleepPercent { get; set; }
        public TimeSpan LightSleepTime { get; set; }
        public double LightSleepPercent { get; set; }
        public TimeSpan AwakeTime { get; set; }
        public double AwakePercent { get; set; }

        // Physiological metrics
        public int RestingHeartRate { get; set; } // bpm
        public int MorningHRV { get; set; } // ms
        public double TemperatureVariation { get; set; } // °C
        public int RespirationRate { get; set; } // breaths/min

        // Sleep phases data for chart
        public List<SleepPhaseData> PhaseData { get; set; } = new();

        public string AlgorithmAssessment { get; set; } = string.Empty;
    }

    public class SleepPhaseData
    {
        public DateTime Time { get; set; }
        public SleepPhase Phase { get; set; }
    }
}
