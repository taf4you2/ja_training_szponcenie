using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ja_training_szponcenie.Models;

namespace ja_training_szponcenie.ViewModels
{
    public class DayViewModel : ViewModelBase
    {
        private DateTime _selectedDate;
        private DayData _dayData;
        private bool _isAdditionalMetricsExpanded;

        public DayViewModel()
        {
            _selectedDate = DateTime.Today;
            _dayData = new DayData { Date = _selectedDate };

            // Initialize commands
            PreviousDayCommand = new RelayCommand(_ => NavigateToPreviousDay());
            NextDayCommand = new RelayCommand(_ => NavigateToNextDay());
            GoBackCommand = new RelayCommand(_ => GoBack());
            EditNotesCommand = new RelayCommand(_ => EditNotes());
            ToggleAdditionalMetricsCommand = new RelayCommand(_ => ToggleAdditionalMetrics());
            AddTrainingCommand = new RelayCommand(_ => AddTraining());
            ExportDayCommand = new RelayCommand(_ => ExportDay());
            CompareDayCommand = new RelayCommand(_ => CompareDay());

            // Load sample data for demonstration
            LoadSampleData();
        }

        #region Properties

        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                if (SetProperty(ref _selectedDate, value))
                {
                    LoadDayData(value);
                }
            }
        }

        public DayData DayData
        {
            get => _dayData;
            set => SetProperty(ref _dayData, value);
        }

        public string FormattedDate => SelectedDate.ToString("dddd, dd MMMM yyyy", new System.Globalization.CultureInfo("pl-PL"));

        public bool IsAdditionalMetricsExpanded
        {
            get => _isAdditionalMetricsExpanded;
            set => SetProperty(ref _isAdditionalMetricsExpanded, value);
        }

        #endregion

        #region Commands

        public ICommand PreviousDayCommand { get; }
        public ICommand NextDayCommand { get; }
        public ICommand GoBackCommand { get; }
        public ICommand EditNotesCommand { get; }
        public ICommand ToggleAdditionalMetricsCommand { get; }
        public ICommand AddTrainingCommand { get; }
        public ICommand ExportDayCommand { get; }
        public ICommand CompareDayCommand { get; }

        #endregion

        #region Methods

        private void NavigateToPreviousDay()
        {
            SelectedDate = SelectedDate.AddDays(-1);
        }

        private void NavigateToNextDay()
        {
            SelectedDate = SelectedDate.AddDays(1);
        }

        private void GoBack()
        {
            // TODO: Implement navigation back to dashboard/calendar
        }

        private void EditNotes()
        {
            // TODO: Implement notes editing
        }

        private void ToggleAdditionalMetrics()
        {
            IsAdditionalMetricsExpanded = !IsAdditionalMetricsExpanded;
        }

        private void AddTraining()
        {
            // TODO: Implement add training
        }

        private void ExportDay()
        {
            // TODO: Implement export functionality
        }

        private void CompareDay()
        {
            // TODO: Implement day comparison
        }

        private void LoadDayData(DateTime date)
        {
            // TODO: Load actual data from database/service
            // For now, load sample data
            LoadSampleData();
        }

        private void LoadSampleData()
        {
            DayData = new DayData
            {
                Date = SelectedDate,
                Overview = new DayOverview
                {
                    Date = SelectedDate,
                    DayType = DayType.TrainingDay,
                    OverallScore = 82,
                    OverallScoreText = "Dobry dzień treningowy",
                    TSS = 124,
                    TrainingTime = TimeSpan.FromMinutes(105),
                    Calories = 2680,
                    SleepTime = TimeSpan.FromHours(7.5),
                    SleepScore = 88,
                    HRV = 68,
                    ReadinessScore = 85,
                    ReadinessText = "Możesz wykonać ciężki trening"
                },
                Trainings = new List<Training>
                {
                    new Training
                    {
                        StartTime = SelectedDate.AddHours(17.5),
                        Name = "Evening ride",
                        IsIndoor = false,
                        Duration = TimeSpan.FromMinutes(105).Add(TimeSpan.FromSeconds(32)),
                        Distance = 45.2,
                        AveragePower = 245,
                        NormalizedPower = 268,
                        TSS = 124,
                        IntensityFactor = 0.94,
                        AverageHeartRate = 152,
                        Work = 1547,
                        Elevation = 340,
                        ZoneTimes = new Dictionary<TrainingZone, TimeSpan>
                        {
                            { TrainingZone.Z1, TimeSpan.FromMinutes(10) },
                            { TrainingZone.Z2, TimeSpan.FromMinutes(30) },
                            { TrainingZone.Z3, TimeSpan.FromMinutes(40) },
                            { TrainingZone.Z4, TimeSpan.FromMinutes(20) },
                            { TrainingZone.Z5, TimeSpan.FromMinutes(5) }
                        }
                    }
                },
                Sleep = new Sleep
                {
                    SleepScore = 88,
                    TotalSleepTime = TimeSpan.FromHours(7.5),
                    BedTime = SelectedDate.AddHours(-1.25).AddDays(-1), // 22:45 previous day
                    WakeTime = SelectedDate.AddHours(6.25), // 6:15
                    SleepEfficiency = 94,
                    QualityText = "Doskonała regeneracja",
                    DeepSleepTime = TimeSpan.FromMinutes(112),
                    DeepSleepPercent = 25,
                    REMSleepTime = TimeSpan.FromMinutes(101),
                    REMSleepPercent = 22,
                    LightSleepTime = TimeSpan.FromMinutes(225),
                    LightSleepPercent = 50,
                    AwakeTime = TimeSpan.FromMinutes(12),
                    AwakePercent = 3,
                    RestingHeartRate = 47,
                    MorningHRV = 68,
                    TemperatureVariation = -0.6,
                    RespirationRate = 14,
                    AlgorithmAssessment = "Twój organizm jest w pełni zregenerowany. Idealny dzień na intensywny trening."
                },
                Nutrition = new Nutrition
                {
                    TotalCalories = 2680,
                    CalorieGoal = 3000,
                    CalorieBalance = -320,
                    Protein = new MacroNutrient { Name = "Białko", Current = 145, Goal = 160 },
                    Carbohydrates = new MacroNutrient { Name = "Węglowodany", Current = 312, Goal = 350 },
                    Fats = new MacroNutrient { Name = "Tłuszcze", Current = 78, Goal = 90 },
                    BMR = 1850,
                    TrainingCalories = 370,
                    ActivityCalories = 280,
                    TotalExpenditure = 2500,
                    Meals = new List<Meal>
                    {
                        new Meal { Name = "Śniadanie", Time = SelectedDate.AddHours(7.5), Calories = 640 },
                        new Meal { Name = "Lunch", Time = SelectedDate.AddHours(12), Calories = 520 },
                        new Meal { Name = "Obiad", Time = SelectedDate.AddHours(18.5), Calories = 980 },
                        new Meal { Name = "Przekąski", Time = SelectedDate, Calories = 540 }
                    }
                },
                HeartRate = new HeartRate
                {
                    RestingHeartRate = 47,
                    RHRBaselineChange = -4,
                    AverageDailyHR = 72,
                    MaxHeartRate = 182,
                    MaxHRTime = SelectedDate.AddHours(17.75),
                    MorningHRV = 68,
                    HRVBaselineChange = 6,
                    ZoneTimes = new Dictionary<TrainingZone, TimeSpan>
                    {
                        { TrainingZone.Z1, TimeSpan.FromHours(18).Add(TimeSpan.FromMinutes(20)) },
                        { TrainingZone.Z2, TimeSpan.FromHours(3).Add(TimeSpan.FromMinutes(15)) },
                        { TrainingZone.Z3, TimeSpan.FromMinutes(90) },
                        { TrainingZone.Z4, TimeSpan.FromMinutes(45) },
                        { TrainingZone.Z5, TimeSpan.FromMinutes(10) }
                    }
                },
                AdditionalMetrics = new AdditionalMetrics
                {
                    Steps = 8450,
                    StepsGoal = 10000,
                    NonTrainingActivityTime = TimeSpan.FromHours(2).Add(TimeSpan.FromMinutes(15)),
                    NonTrainingActivityCalories = 280,
                    AverageStressLevel = 35,
                    AverageSpO2 = 97,
                    MinSpO2 = 95,
                    MaxSpO2 = 99,
                    AverageTemperature = 36.6,
                    MinTemperature = 35.8,
                    MaxTemperature = 37.1
                },
                Notes = new DayNotes
                {
                    Notes = "",
                    DayMood = Mood.None,
                    Tags = new List<string>()
                }
            };
        }

        #endregion
    }
}
