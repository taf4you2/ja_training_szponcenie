using System;

namespace ja_training_szponcenie.Models
{
    public class WeightMeasurement
    {
        public DateTime Date { get; set; }
        public double Weight { get; set; } // kg
        public double? ChangeFromPrevious { get; set; } // kg
        public double? ChangePercentage { get; set; } // %
        public double? BMI { get; set; }
        public double? WattsPerKg { get; set; } // z aktualnym FTP
        public string Note { get; set; }
        public bool IsCurrentWeight { get; set; }
        public bool IsLowestWeight { get; set; }
        public bool IsHighestWeight { get; set; }
    }
}
