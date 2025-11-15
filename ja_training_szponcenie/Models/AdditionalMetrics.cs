using System;
using System.Collections.Generic;

namespace ja_training_szponcenie.Models
{
    public class AdditionalMetrics
    {
        public int Steps { get; set; }
        public int StepsGoal { get; set; }
        public TimeSpan NonTrainingActivityTime { get; set; }
        public int NonTrainingActivityCalories { get; set; }
        public int AverageStressLevel { get; set; }
        public List<int> StressData { get; set; } = new();
        public double AverageSpO2 { get; set; }
        public double MinSpO2 { get; set; }
        public double MaxSpO2 { get; set; }
        public double AverageTemperature { get; set; }
        public double MinTemperature { get; set; }
        public double MaxTemperature { get; set; }
    }
}
