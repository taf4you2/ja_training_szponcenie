namespace ja_training_szponcenie.Models
{
    /// <summary>
    /// Main training session data
    /// </summary>
    public class TrainingData
    {
        public string FileName { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }
        public List<DataPoint> DataPoints { get; set; } = new();

        // Main metrics
        public TimeSpan Duration { get; set; }
        public double Distance { get; set; } // km
        public double AveragePower { get; set; } // W
        public double NormalizedPower { get; set; } // W
        public int TSS { get; set; }
        public double IntensityFactor { get; set; }
        public int? AverageHeartRate { get; set; }
        public int? MaxHeartRate { get; set; }
        public double Work { get; set; } // kJ

        // Additional metrics
        public double ElevationGain { get; set; } // m
        public double ElevationLoss { get; set; } // m
        public int? AverageCadence { get; set; }
        public double? MaxPower { get; set; }
        public double? AverageSpeed { get; set; } // km/h
        public double? MaxSpeed { get; set; } // km/h
        public double VariabilityIndex { get; set; }

        // User settings
        public double FTP { get; set; } = 285; // Functional Threshold Power
        public double Weight { get; set; } = 75; // kg
        public int MaxHR { get; set; } = 183;

        // Context
        public ContextData? Context { get; set; }

        // Detected intervals
        public List<Interval> Intervals { get; set; } = new();

        // Time in zones
        public List<TimeInZone> PowerZones { get; set; } = new();
        public List<TimeInZone> HeartRateZones { get; set; } = new();

        // Power curve
        public List<PowerCurvePoint> PowerCurve { get; set; } = new();

        // Notes
        public string Notes { get; set; } = string.Empty;
        public List<string> Tags { get; set; } = new();
        public int? Rating { get; set; } // 1-5 stars
        public int? RPE { get; set; } // 1-10
    }
}
