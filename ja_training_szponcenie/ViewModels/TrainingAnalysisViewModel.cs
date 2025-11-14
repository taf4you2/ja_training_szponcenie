using ja_training_szponcenie.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ja_training_szponcenie.ViewModels
{
    public class TrainingAnalysisViewModel : ViewModelBase
    {
        private TrainingData _trainingData;
        private bool _showMoreMetrics;
        private bool _showRestPeriods = true;

        public TrainingAnalysisViewModel()
        {
            _trainingData = GenerateSampleData();
            InitializeMetricCards();

            // Commands
            GoBackCommand = new RelayCommand(GoBack);
            ExportCommand = new RelayCommand(Export);
            SettingsCommand = new RelayCommand(ShowSettings);
            DeleteCommand = new RelayCommand(Delete);
        }

        #region Properties

        public TrainingData TrainingData
        {
            get => _trainingData;
            set => SetProperty(ref _trainingData, value);
        }

        public ObservableCollection<MetricCard> MainMetrics { get; } = new();
        public ObservableCollection<MetricCard> AdditionalMetrics { get; } = new();

        public bool ShowMoreMetrics
        {
            get => _showMoreMetrics;
            set => SetProperty(ref _showMoreMetrics, value);
        }

        public bool ShowRestPeriods
        {
            get => _showRestPeriods;
            set => SetProperty(ref _showRestPeriods, value);
        }

        public string HeaderTitle => "Analiza treningu";
        public string FileName => TrainingData.FileName;
        public string DateTimeText => TrainingData.DateTime.ToString("d MMMM yyyy, HH:mm", new System.Globalization.CultureInfo("pl-PL"));

        #endregion

        #region Commands

        public ICommand GoBackCommand { get; }
        public ICommand ExportCommand { get; }
        public ICommand SettingsCommand { get; }
        public ICommand DeleteCommand { get; }

        private void GoBack() { /* Navigate back */ }
        private void Export() { /* Export training */ }
        private void ShowSettings() { /* Show settings dialog */ }
        private void Delete() { /* Delete training */ }

        #endregion

        #region Private Methods

        private void InitializeMetricCards()
        {
            // Main 8 metrics
            MainMetrics.Clear();

            MainMetrics.Add(new MetricCard
            {
                Title = "Czas trwania",
                Value = FormatDuration(TrainingData.Duration),
                Icon = "⏱️",
                BackgroundColor = "#F5F5F5"
            });

            MainMetrics.Add(new MetricCard
            {
                Title = "Dystans",
                Value = $"{TrainingData.Distance:F1} km",
                Icon = "📏",
                BackgroundColor = "#E3F2FD"
            });

            MainMetrics.Add(new MetricCard
            {
                Title = "Średnia moc",
                Value = $"{TrainingData.AveragePower:F0} W",
                SubValue = $"{TrainingData.AveragePower / TrainingData.Weight:F1} W/kg",
                Icon = "⚡",
                BackgroundColor = "#FFF9C4"
            });

            MainMetrics.Add(new MetricCard
            {
                Title = "Normalized Power",
                Value = $"{TrainingData.NormalizedPower:F0} W",
                SubValue = $"{TrainingData.NormalizedPower / TrainingData.Weight:F1} W/kg",
                Icon = "⚡⚡",
                BackgroundColor = "#FFE0B2"
            });

            var tssColor = TrainingData.TSS < 100 ? "#C8E6C9" :
                          TrainingData.TSS < 200 ? "#FFF9C4" :
                          TrainingData.TSS < 300 ? "#FFE0B2" : "#FFCDD2";

            MainMetrics.Add(new MetricCard
            {
                Title = "TSS",
                Value = TrainingData.TSS.ToString(),
                Icon = "💪",
                BackgroundColor = tssColor
            });

            MainMetrics.Add(new MetricCard
            {
                Title = "Intensity Factor",
                Value = $"{TrainingData.IntensityFactor:F2}",
                SubValue = $"{TrainingData.IntensityFactor * 100:F0}% FTP",
                Icon = "🎯",
                BackgroundColor = "#E1BEE7"
            });

            if (TrainingData.AverageHeartRate.HasValue)
            {
                MainMetrics.Add(new MetricCard
                {
                    Title = "Średnie tętno",
                    Value = $"{TrainingData.AverageHeartRate} bpm",
                    SubValue = $"{(TrainingData.AverageHeartRate.Value * 100.0 / TrainingData.MaxHR):F0}% Max HR",
                    Icon = "❤️",
                    BackgroundColor = "#FFCDD2"
                });
            }

            var calories = (int)(TrainingData.Work * 0.239); // kJ to kcal approximation
            MainMetrics.Add(new MetricCard
            {
                Title = "Work",
                Value = $"{TrainingData.Work:F0} kJ",
                SubValue = $"{calories} kcal",
                Icon = "🔥",
                BackgroundColor = "#FFE0B2"
            });

            // Additional metrics
            AdditionalMetrics.Clear();

            AdditionalMetrics.Add(new MetricCard
            {
                Title = "Przewyższenie",
                Value = $"⬆ {TrainingData.ElevationGain:F0} m / ⬇ {TrainingData.ElevationLoss:F0} m",
                BackgroundColor = "#F5F5F5"
            });

            if (TrainingData.AverageCadence.HasValue)
            {
                AdditionalMetrics.Add(new MetricCard
                {
                    Title = "Średnia kadencja",
                    Value = $"{TrainingData.AverageCadence} rpm",
                    BackgroundColor = "#F5F5F5"
                });
            }

            if (TrainingData.MaxPower.HasValue)
            {
                AdditionalMetrics.Add(new MetricCard
                {
                    Title = "Maksymalna moc",
                    Value = $"{TrainingData.MaxPower:F0} W",
                    BackgroundColor = "#F5F5F5"
                });
            }

            if (TrainingData.MaxHeartRate.HasValue)
            {
                AdditionalMetrics.Add(new MetricCard
                {
                    Title = "Maksymalne tętno",
                    Value = $"{TrainingData.MaxHeartRate} bpm",
                    BackgroundColor = "#F5F5F5"
                });
            }

            if (TrainingData.AverageSpeed.HasValue)
            {
                AdditionalMetrics.Add(new MetricCard
                {
                    Title = "Średnia prędkość",
                    Value = $"{TrainingData.AverageSpeed:F1} km/h",
                    BackgroundColor = "#F5F5F5"
                });
            }

            AdditionalMetrics.Add(new MetricCard
            {
                Title = "Variability Index",
                Value = $"{TrainingData.VariabilityIndex:F2}",
                BackgroundColor = "#F5F5F5"
            });
        }

        private static string FormatDuration(TimeSpan duration)
        {
            if (duration.TotalHours >= 1)
                return $"{(int)duration.TotalHours}:{duration.Minutes:D2}:{duration.Seconds:D2}";
            else
                return $"{duration.Minutes}:{duration.Seconds:D2}";
        }

        private static TrainingData GenerateSampleData()
        {
            var data = new TrainingData
            {
                FileName = "2025-11-09_evening_ride.fit",
                DateTime = new DateTime(2025, 11, 9, 17, 30, 0),
                Duration = TimeSpan.FromSeconds(6332), // 1:45:32
                Distance = 45.2,
                AveragePower = 245,
                NormalizedPower = 268,
                TSS = 124,
                IntensityFactor = 0.94,
                AverageHeartRate = 152,
                MaxHeartRate = 182,
                Work = 1547,
                ElevationGain = 340,
                ElevationLoss = 335,
                AverageCadence = 88,
                MaxPower = 856,
                AverageSpeed = 25.8,
                MaxSpeed = 67.4,
                VariabilityIndex = 1.09,
                FTP = 285,
                Weight = 75,
                MaxHR = 183
            };

            // Context data
            data.Context = new ContextData
            {
                SleepDuration = TimeSpan.FromHours(7.5),
                SleepScore = 88,
                SleepQuality = "Dobry sen",
                HRV = 68,
                HRVBaseline = 62,
                RecoveryStatus = "Świetna regeneracja",
                CaloriesBeforeTraining = 1850,
                TSB = 14,
                FormStatus = "Optymalny",
                Assessment = ContextAssessment.Optimal,
                AssessmentText = "✅ Trening w optymalnej formie"
            };

            // Intervals
            data.Intervals = new List<Interval>
            {
                new Interval
                {
                    Number = 1,
                    StartTime = TimeSpan.FromSeconds(323),
                    EndTime = TimeSpan.FromSeconds(645),
                    AveragePower = 312,
                    NormalizedPower = 325,
                    AverageHeartRate = 172,
                    AverageCadence = 94,
                    PowerZone = 5,
                    ZoneName = "Z5: VO2max",
                    ZoneColor = "#FF9800",
                    Type = IntervalType.Jump,
                    PercentageFTP = 109,
                    PercentageMaxHR = 94
                },
                new Interval
                {
                    Number = 2,
                    StartTime = TimeSpan.FromSeconds(930),
                    EndTime = TimeSpan.FromSeconds(1275),
                    AveragePower = 288,
                    NormalizedPower = 295,
                    AverageHeartRate = 165,
                    AverageCadence = 90,
                    PowerZone = 4,
                    ZoneName = "Z4: Threshold",
                    ZoneColor = "#FFEB3B",
                    Type = IntervalType.Gradual,
                    PercentageFTP = 101,
                    PercentageMaxHR = 90
                },
                new Interval
                {
                    Number = 3,
                    StartTime = TimeSpan.FromSeconds(1930),
                    EndTime = TimeSpan.FromSeconds(2065),
                    AveragePower = 368,
                    NormalizedPower = 382,
                    AverageHeartRate = 178,
                    AverageCadence = 98,
                    PowerZone = 6,
                    ZoneName = "Z6: Anaerobic",
                    ZoneColor = "#F44336",
                    Type = IntervalType.Jump,
                    PercentageFTP = 129,
                    PercentageMaxHR = 97
                }
            };

            // Power zones
            data.PowerZones = new List<TimeInZone>
            {
                new TimeInZone { ZoneNumber = 1, ZoneName = "Z1", ZoneDescription = "Active Recovery", ZoneColor = "#9E9E9E", MinValue = 0, MaxValue = 142, Time = TimeSpan.FromMinutes(15.38), Percentage = 14, AverageValue = 120, RangeText = "0-142 W (0-50% FTP)", TimeText = "15:23" },
                new TimeInZone { ZoneNumber = 2, ZoneName = "Z2", ZoneDescription = "Endurance", ZoneColor = "#2196F3", MinValue = 143, MaxValue = 199, Time = TimeSpan.FromMinutes(45.2), Percentage = 43, AverageValue = 180, RangeText = "143-199 W (50-70% FTP)", TimeText = "45:12" },
                new TimeInZone { ZoneNumber = 3, ZoneName = "Z3", ZoneDescription = "Tempo", ZoneColor = "#4CAF50", MinValue = 200, MaxValue = 242, Time = TimeSpan.FromMinutes(25.57), Percentage = 24, AverageValue = 240, RangeText = "200-242 W (70-85% FTP)", TimeText = "25:34" },
                new TimeInZone { ZoneNumber = 4, ZoneName = "Z4", ZoneDescription = "Lactate Threshold", ZoneColor = "#FFEB3B", MinValue = 243, MaxValue = 285, Time = TimeSpan.FromMinutes(12.75), Percentage = 12, AverageValue = 285, RangeText = "243-285 W (85-100% FTP)", TimeText = "12:45" },
                new TimeInZone { ZoneNumber = 5, ZoneName = "Z5", ZoneDescription = "VO2max", ZoneColor = "#FF9800", MinValue = 286, MaxValue = 342, Time = TimeSpan.FromMinutes(6.3), Percentage = 6, AverageValue = 320, RangeText = "286-342 W (100-120% FTP)", TimeText = "6:18" },
                new TimeInZone { ZoneNumber = 6, ZoneName = "Z6", ZoneDescription = "Anaerobic Capacity", ZoneColor = "#F44336", MinValue = 343, MaxValue = 456, Time = TimeSpan.FromSeconds(20), Percentage = 0.3, AverageValue = 380, RangeText = "343-456 W (120-160% FTP)", TimeText = "0:20" },
                new TimeInZone { ZoneNumber = 7, ZoneName = "Z7", ZoneDescription = "Neuromuscular Power", ZoneColor = "#B71C1C", MinValue = 457, MaxValue = 999, Time = TimeSpan.Zero, Percentage = 0, AverageValue = 0, RangeText = ">456 W (>160% FTP)", TimeText = "0:00" }
            };

            // Power curve
            var powerCurveDurations = new[] { 5, 10, 15, 30, 60, 120, 180, 300, 480, 600, 1200, 1800, 3600 };
            data.PowerCurve = powerCurveDurations.Select(seconds => new PowerCurvePoint
            {
                Duration = TimeSpan.FromSeconds(seconds),
                Power = CalculatePowerForDuration(seconds),
                WattsPerKg = CalculatePowerForDuration(seconds) / 75.0,
                PercentageFTP = CalculatePowerForDuration(seconds) / 285.0 * 100,
                DurationText = FormatDurationShort(TimeSpan.FromSeconds(seconds)),
                IsPersonalRecord = seconds == 5 || seconds == 30 || seconds == 300,
                PreviousRecord = seconds == 5 ? 842 : seconds == 30 ? 585 : seconds == 300 ? 318 : null,
                PreviousRecordDate = seconds == 5 || seconds == 30 || seconds == 300 ? new DateTime(2025, 9, 15) : null
            }).ToList();

            // Calculate improvements for PRs
            foreach (var point in data.PowerCurve.Where(p => p.IsPersonalRecord && p.PreviousRecord.HasValue))
            {
                point.Improvement = point.Power - point.PreviousRecord.Value;
                point.ImprovementPercentage = (point.Improvement.Value / point.PreviousRecord.Value) * 100;
            }

            return data;
        }

        private static double CalculatePowerForDuration(int seconds)
        {
            // Simplified power duration curve
            return seconds switch
            {
                5 => 856,
                10 => 782,
                15 => 698,
                30 => 598,
                60 => 412,
                120 => 365,
                180 => 342,
                300 => 324,
                480 => 308,
                600 => 302,
                1200 => 295,
                1800 => 278,
                3600 => 245,
                _ => 245
            };
        }

        private static string FormatDurationShort(TimeSpan duration)
        {
            if (duration.TotalHours >= 1)
                return $"{(int)duration.TotalHours}h";
            else if (duration.TotalMinutes >= 1)
                return $"{(int)duration.TotalMinutes}min";
            else
                return $"{duration.Seconds}s";
        }

        #endregion
    }
}
