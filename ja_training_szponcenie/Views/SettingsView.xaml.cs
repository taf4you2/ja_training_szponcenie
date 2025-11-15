using System.Windows;
using System.Windows.Controls;

namespace ja_training_szponcenie.Views
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            InitializeComponent();
            InitializeEventHandlers();
        }

        private void InitializeEventHandlers()
        {
            // Category navigation buttons
            ProfileCategoryButton.Click += (s, e) => ShowCategory("Profile");
            TrainingZonesCategoryButton.Click += (s, e) => ShowCategory("TrainingZones");
            AdvancedCategoryButton.Click += (s, e) => ShowCategory("Advanced");
            AppearanceCategoryButton.Click += (s, e) => ShowCategory("Appearance");
            AboutCategoryButton.Click += (s, e) => ShowCategory("About");

            // Tab buttons for Training Zones
            PowerZonesTab.Click += (s, e) => ShowZonesTab("Power");
            HeartRateZonesTab.Click += (s, e) => ShowZonesTab("HeartRate");

            // Back button
            BackButton.Click += (s, e) => NavigateBack();

            // Save/Discard buttons
            SaveChangesButton.Click += (s, e) => SaveChanges();
            DiscardChangesButton.Click += (s, e) => DiscardChanges();
        }

        private void ShowCategory(string categoryName)
        {
            // Hide all categories
            ProfileCategory.Visibility = Visibility.Collapsed;
            TrainingZonesCategory.Visibility = Visibility.Collapsed;
            AdvancedCategory.Visibility = Visibility.Collapsed;
            AppearanceCategory.Visibility = Visibility.Collapsed;
            AboutCategory.Visibility = Visibility.Collapsed;

            // Reset all category buttons
            ResetCategoryButtonStyles();

            // Show selected category and highlight button
            switch (categoryName)
            {
                case "Profile":
                    ProfileCategory.Visibility = Visibility.Visible;
                    HighlightCategoryButton(ProfileCategoryButton);
                    break;
                case "TrainingZones":
                    TrainingZonesCategory.Visibility = Visibility.Visible;
                    HighlightCategoryButton(TrainingZonesCategoryButton);
                    break;
                case "Advanced":
                    AdvancedCategory.Visibility = Visibility.Visible;
                    HighlightCategoryButton(AdvancedCategoryButton);
                    break;
                case "Appearance":
                    AppearanceCategory.Visibility = Visibility.Visible;
                    HighlightCategoryButton(AppearanceCategoryButton);
                    break;
                case "About":
                    AboutCategory.Visibility = Visibility.Visible;
                    HighlightCategoryButton(AboutCategoryButton);
                    break;
            }
        }

        private void ShowZonesTab(string tabName)
        {
            if (tabName == "Power")
            {
                PowerZonesTabContent.Visibility = Visibility.Visible;
                HeartRateZonesTabContent.Visibility = Visibility.Collapsed;
                PowerZonesTab.BorderBrush = (System.Windows.Media.Brush)FindResource("PrimaryColor");
                HeartRateZonesTab.BorderBrush = System.Windows.Media.Brushes.Transparent;
            }
            else
            {
                PowerZonesTabContent.Visibility = Visibility.Collapsed;
                HeartRateZonesTabContent.Visibility = Visibility.Visible;
                PowerZonesTab.BorderBrush = System.Windows.Media.Brushes.Transparent;
                HeartRateZonesTab.BorderBrush = (System.Windows.Media.Brush)FindResource("PrimaryColor");
            }
        }

        private void ResetCategoryButtonStyles()
        {
            // Reset all buttons to default state
            var buttons = new[] {
                ProfileCategoryButton,
                TrainingZonesCategoryButton,
                AdvancedCategoryButton,
                AppearanceCategoryButton,
                AboutCategoryButton
            };

            foreach (var button in buttons)
            {
                button.Background = System.Windows.Media.Brushes.Transparent;
                button.BorderThickness = new Thickness(0);
            }
        }

        private void HighlightCategoryButton(Button button)
        {
            button.Background = System.Windows.Media.Brushes.White;
            button.BorderThickness = new Thickness(4, 0, 0, 0);
            button.BorderBrush = (System.Windows.Media.Brush)FindResource("PrimaryColor");
        }

        private void NavigateBack()
        {
            // Check for unsaved changes
            if (UnsavedChangesIndicator.Visibility == Visibility.Visible)
            {
                var result = MessageBox.Show("Masz niezapisane zmiany. Co chcesz zrobić?",
                    "Niezapisane zmiany", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    SaveChanges();
                }
                else if (result == MessageBoxResult.Cancel)
                {
                    return; // Stay in settings
                }
            }

            // Navigate back to Dashboard
            var mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow?.NavigateToDashboard();
        }

        private void SaveChanges()
        {
            // TODO: Save all changes to database
            MessageBox.Show("Zapisywanie zmian (do implementacji)", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

            // Hide unsaved changes indicator
            UnsavedChangesIndicator.Visibility = Visibility.Collapsed;
            DiscardChangesButton.Visibility = Visibility.Collapsed;
            SaveChangesButton.IsEnabled = false;
        }

        private void DiscardChanges()
        {
            // TODO: Revert all changes
            var result = MessageBox.Show("Czy na pewno chcesz odrzucić wszystkie zmiany?",
                "Potwierdź", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                // Hide unsaved changes indicator
                UnsavedChangesIndicator.Visibility = Visibility.Collapsed;
                DiscardChangesButton.Visibility = Visibility.Collapsed;
                SaveChangesButton.IsEnabled = false;
            }
        }

        // Helper method to show unsaved changes (can be called when user changes any field)
        public void MarkAsModified()
        {
            UnsavedChangesIndicator.Visibility = Visibility.Visible;
            DiscardChangesButton.Visibility = Visibility.Visible;
            SaveChangesButton.IsEnabled = true;
        }
    }
}
