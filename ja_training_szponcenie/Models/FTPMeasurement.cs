using System;

namespace ja_training_szponcenie.Models
{
    public class FTPMeasurement
    {
        public DateTime Date { get; set; }
        public int FTPValue { get; set; } // W
        public double? Weight { get; set; } // kg - opcjonalne
        public double? WattsPerKg => Weight.HasValue && Weight.Value > 0 ? FTPValue / Weight.Value : null;
        public int? ChangeFromPrevious { get; set; } // W
        public double? ChangePercentage { get; set; } // %
        public FTPSource Source { get; set; }
        public string Note { get; set; }
        public bool IsCurrentFTP { get; set; }
        public bool IsRecord { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastEditedAt { get; set; }
    }

    public enum FTPSource
    {
        Test20Min,
        RampTest,
        Test8Min,
        EstimatedFromTrainings,
        Manual,
        Other
    }
}
