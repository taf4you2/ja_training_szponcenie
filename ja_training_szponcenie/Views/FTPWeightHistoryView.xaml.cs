using System.Windows;
using System.Windows.Controls;

namespace ja_training_szponcenie.Views
{
    public partial class FTPWeightHistoryView : UserControl
    {
        public FTPWeightHistoryView()
        {
            InitializeComponent();

            // Event handlers - bez logiki, tylko struktura
            BackButton.Click += BackButton_Click;
            AddMeasurementButton.Click += AddMeasurementButton_Click;
            ExportButton.Click += ExportButton_Click;
            FTPTab.Click += FTPTab_Click;
            WeightTab.Click += WeightTab_Click;
            AddFTPMeasurementButton.Click += AddFTPMeasurementButton_Click;
            AddWeightMeasurementButton.Click += AddWeightMeasurementButton_Click;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Logika powrotu do ustawień - do zaimplementowania
        }

        private void AddMeasurementButton_Click(object sender, RoutedEventArgs e)
        {
            // Pokaż dropdown z opcjami dodawania pomiaru - do zaimplementowania
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            // Eksport do CSV - do zaimplementowania
        }

        private void FTPTab_Click(object sender, RoutedEventArgs e)
        {
            // Przełącz na zakładkę FTP
            FTPTabContent.Visibility = Visibility.Visible;
            WeightTabContent.Visibility = Visibility.Collapsed;

            FTPTab.BorderBrush = (System.Windows.Media.Brush)FindResource("PrimaryColor");
            WeightTab.BorderBrush = System.Windows.Media.Brushes.Transparent;
            FTPTab.Background = (System.Windows.Media.Brush)FindResource("SurfaceColor");
            WeightTab.Background = System.Windows.Media.Brushes.Transparent;
        }

        private void WeightTab_Click(object sender, RoutedEventArgs e)
        {
            // Przełącz na zakładkę Waga
            FTPTabContent.Visibility = Visibility.Collapsed;
            WeightTabContent.Visibility = Visibility.Visible;

            FTPTab.BorderBrush = System.Windows.Media.Brushes.Transparent;
            WeightTab.BorderBrush = (System.Windows.Media.Brush)FindResource("PrimaryColor");
            FTPTab.Background = System.Windows.Media.Brushes.Transparent;
            WeightTab.Background = (System.Windows.Media.Brush)FindResource("SurfaceColor");
        }

        private void AddFTPMeasurementButton_Click(object sender, RoutedEventArgs e)
        {
            // Otwórz dialog dodawania pomiaru FTP - do zaimplementowania
        }

        private void AddWeightMeasurementButton_Click(object sender, RoutedEventArgs e)
        {
            // Otwórz dialog dodawania pomiaru wagi - do zaimplementowania
        }
    }
}
