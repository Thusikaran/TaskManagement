using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using TaskManagement.ViewModel;

namespace TaskManagement.View
{
    public partial  class Main : Window
    {
        public Main()
        { 
            InitializeComponent();
            MainViewModel mainViewModel= new MainViewModel();
            this.DataContext = mainViewModel;

            Storyboard outerRingAnimation = (Storyboard)FindResource("OuterRingAnimation");
            Storyboard middleRingAnimation = (Storyboard)FindResource("MiddleRingAnimation");
            Storyboard innerRingAnimation = (Storyboard)FindResource("InnerRingAnimation");

            outerRingAnimation.Begin();
            middleRingAnimation.Begin();
            innerRingAnimation.Begin();
        }

       

     
    }
}



       
    

