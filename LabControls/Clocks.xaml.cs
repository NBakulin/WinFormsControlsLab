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
        public Clocks()
        {
            this.InitializeComponent();
            CompositionTarget.Rendering += CompositionTarget_Rendering;
        }

        private void CompositionTarget_Rendering(object sender, object args)
        {
            DateTime dt = DateTime.Now;
            rotateSecond.Angle = 6 * (dt.Second + dt.Millisecond / 1000.0);
            rotateMinute.Angle = 6 * dt.Minute + rotateSecond.Angle / 60;
            rotateHour.Angle = 30 * (dt.Hour % 12) + rotateMinute.Angle / 12;
        }
    }
}
