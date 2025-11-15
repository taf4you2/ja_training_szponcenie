using System.Windows;
using System.Windows.Controls;

namespace ja_training_szponcenie.Controls
{
    public partial class ZoneBarChart : UserControl
    {
        public static readonly DependencyProperty ZonesProperty =
            DependencyProperty.Register("Zones", typeof(object), typeof(ZoneBarChart), new PropertyMetadata(null));

        public object Zones
        {
            get { return GetValue(ZonesProperty); }
            set { SetValue(ZonesProperty, value); }
        }

        public ZoneBarChart()
        {
            InitializeComponent();
        }
    }
}
