using System.Windows;
using System.Windows.Controls;

namespace ja_training_szponcenie.Views
{
    /// <summary>
    /// Interaction logic for DashboardView.xaml
    /// </summary>
    public partial class DashboardView : UserControl
    {
        public DashboardView()
        {
            InitializeComponent();
            SettingsButton.Click += SettingsButton_Click;
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to Settings
            var mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow?.NavigateToSettings();
        }
    }
}
