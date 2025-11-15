using System;
using System.Collections.Generic;

namespace ja_training_szponcenie.Models
{
    public class Training
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime StartTime { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsIndoor { get; set; }
        public TimeSpan Duration { get; set; }
        public double Distance { get; set; } // km
        public int AveragePower { get; set; } // W
        public int NormalizedPower { get; set; } // W
        public int TSS { get; set; }
        public double IntensityFactor { get; set; }
        public int AverageHeartRate { get; set; } // bpm
        public int Work { get; set; } // kJ
        public int Elevation { get; set; } // m
        public Dictionary<TrainingZone, TimeSpan> ZoneTimes { get; set; } = new();
        public List<double> PowerData { get; set; } = new(); // For chart
        public bool IsExpanded { get; set; }
    }
}
