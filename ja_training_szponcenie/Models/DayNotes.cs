using System;
using System.Collections.Generic;

namespace ja_training_szponcenie.Models
{
    public class DayNotes
    {
        public string Notes { get; set; } = string.Empty;
        public Mood DayMood { get; set; }
        public List<string> Tags { get; set; } = new();
    }

    public enum Mood
    {
        VeryHappy,
        Happy,
        Neutral,
        Sad,
        VerySad,
        None
    }
}
