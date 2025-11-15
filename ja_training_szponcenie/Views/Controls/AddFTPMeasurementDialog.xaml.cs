using System.Windows;

namespace ja_training_szponcenie.Views.Controls
{
    public partial class AddFTPMeasurementDialog : Window
    {
        public AddFTPMeasurementDialog()
        {
            InitializeComponent();

            // Event handlers - bez logiki, tylko struktura
            CloseButton.Click += CloseButton_Click;
            CancelButton.Click += CancelButton_Click;
            SaveButton.Click += SaveButton_Click;
            UseCurrentWeightCheckBox.Checked += UseCurrentWeightCheckBox_CheckChanged;
            UseCurrentWeightCheckBox.Unchecked += UseCurrentWeightCheckBox_CheckChanged;
            NoteTextBox.TextChanged += NoteTextBox_TextChanged;
            FTPValueTextBox.TextChanged += FTPValueTextBox_TextChanged;
            WeightTextBox.TextChanged += WeightTextBox_TextChanged;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Walidacja i zapis - do zaimplementowania
            DialogResult = true;
            Close();
        }

        private void UseCurrentWeightCheckBox_CheckChanged(object sender, RoutedEventArgs e)
        {
            // Zablokuj/odblokuj pole wagi - do zaimplementowania
        }

        private void NoteTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            // Aktualizuj licznik znaków - do zaimplementowania
            CharCountTextBlock.Text = $"{NoteTextBox.Text.Length}/500";
        }

        private void FTPValueTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            // Oblicz W/kg - do zaimplementowania
        }

        private void WeightTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            // Oblicz W/kg - do zaimplementowania
        }
    }
}
