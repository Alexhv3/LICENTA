using DigitalHarmony.Models;
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

namespace DigitalHarmony.ViewControls.AudioProcessors
{
    /// <summary>
    /// Interaction logic for DistortionControl.xaml
    /// </summary>
    public partial class DistortionControl : ProcessorModel
    {
        public DistortionControl()
        {
            base.Title = "Distortion";
            InitializeComponent();
        }
    }
}
