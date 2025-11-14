using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace ja_training_szponcenie.Controls
{
    public partial class ZoneBarChart : UserControl
    {
        public static readonly DependencyProperty ZonesProperty =
            DependencyProperty.Register(
                nameof(Zones),
                typeof(IEnumerable),
                typeof(ZoneBarChart),
                new PropertyMetadata(null));

        public IEnumerable Zones
        {
            get => (IEnumerable)GetValue(ZonesProperty);
            set => SetValue(ZonesProperty, value);
        }

        public ZoneBarChart()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
