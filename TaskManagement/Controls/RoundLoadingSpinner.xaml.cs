using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media;
namespace TaskManagement.Controls
{
    public partial class RoundLoadingSpinner : UserControl
    {
        public RoundLoadingSpinner()
        {
            InitializeComponent();

            this.Loaded += RoundLoadingSpinner_Loaded;
        }

        private void RoundLoadingSpinner_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {

            var rotateAnimation = new DoubleAnimation
            {
                From = 0,
                To = 360,
                Duration = new System.Windows.Duration(System.TimeSpan.FromSeconds(2)),
                RepeatBehavior = RepeatBehavior.Forever
            };

  
            RotateTransform.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation);
        }
    }
}
