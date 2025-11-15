using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ja_training_szponcenie.Views;

namespace ja_training_szponcenie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DashboardView dashboardView;
        private SettingsView settingsView;

        public MainWindow()
        {
            InitializeComponent();
            dashboardView = new DashboardView();

            // Initialize with Dashboard
            MainContent.Content = dashboardView;
        }

        public void NavigateToSettings()
        {
            if (settingsView == null)
            {
                settingsView = new SettingsView();
            }
            MainContent.Content = settingsView;
            Title = "JA Training - Ustawienia";
        }

        public void NavigateToDashboard()
        {
            MainContent.Content = dashboardView;
            Title = "JA Training - Dashboard";
        }

        private void OpenRecordsPowerCurveButton_Click(object sender, RoutedEventArgs e)
        {
            var recordsWindow = new RecordsPowerCurveView();
            recordsWindow.Show();
        }
    }
}