using System;
using System.Collections.Generic;

namespace ja_training_szponcenie.Models
{
    public class DayData
    {
        public DateTime Date { get; set; }
        public DayOverview Overview { get; set; } = new();
        public List<Training> Trainings { get; set; } = new();
        public Sleep? Sleep { get; set; }
        public Nutrition? Nutrition { get; set; }
        public HeartRate? HeartRate { get; set; }
        public AdditionalMetrics? AdditionalMetrics { get; set; }
        public DayNotes Notes { get; set; } = new();
    }
}
