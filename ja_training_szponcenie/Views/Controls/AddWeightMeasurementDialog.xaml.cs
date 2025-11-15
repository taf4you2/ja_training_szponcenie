using System.Windows;

namespace ja_training_szponcenie.Views.Controls
{
    public partial class AddWeightMeasurementDialog : Window
    {
        public AddWeightMeasurementDialog()
        {
            InitializeComponent();

            // Event handlers - bez logiki, tylko struktura
            CloseButton.Click += CloseButton_Click;
            CancelButton.Click += CancelButton_Click;
            SaveButton.Click += SaveButton_Click;
            NoteTextBox.TextChanged += NoteTextBox_TextChanged;
            WeightValueTextBox.TextChanged += WeightValueTextBox_TextChanged;
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

        private void NoteTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            // Aktualizuj licznik znaków - do zaimplementowania
            CharCountTextBlock.Text = $"{NoteTextBox.Text.Length}/300";
        }

        private void WeightValueTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            // Oblicz BMI i W/kg - do zaimplementowania
        }
    }
}
