using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace LabControls
{
    public partial class Clocks : UserControl
    {

        DispatcherTimer dispatcherTimer;
        private int degrees = 0;
        public Clocks()
        {
            InitializeComponent();
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            degrees += 5;
            if (degrees > 360)
            {
                degrees = 0;
            }
            RotateTransform transform = new RotateTransform(degrees, StickImg.Width / 2, StickImg.Height / 2);
            //StickImg.RenderTransformOrigin = new System.Windows.Point(0, 0); 
            StickImg.RenderTransform = transform;
        }

        private void Window_ContentRendered_1(object sender, EventArgs e)
        {
            dispatcherTimer.Start();
        }
    }
}
