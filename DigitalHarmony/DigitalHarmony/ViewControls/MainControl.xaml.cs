using DigitalHarmony.Models;
using DigitalHarmony.ViewControls.AudioProcessors;
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

namespace DigitalHarmony.ViewControls
{
    /// <summary>
    /// Interaction logic for MainControl.xaml
    /// </summary>
    public partial class MainControl : UserControl
    {
        public MainControl()
        {
            InitializeComponent();

            ProcessorControl distortionControl = new ProcessorControl(new DistortionControl());
            ProcessorControl delayControl = new ProcessorControl(new DelayControl());
            ProcessorControl reverbControl = new ProcessorControl(new ReverbControl());
            ProcessorControl ampControl = new ProcessorControl(new AmpControl());

            this.processorsGrid.Children.Add(distortionControl);
            this.processorsGrid.Children.Add(delayControl);
            this.processorsGrid.Children.Add(reverbControl);
            this.processorsGrid.Children.Add(ampControl);

            Grid.SetColumn(distortionControl, 0);
            Grid.SetRow(distortionControl, 0);

            Grid.SetColumn(delayControl, 0);
            Grid.SetRow(delayControl, 1);

            Grid.SetColumn(reverbControl, 1);
            Grid.SetRow(reverbControl, 0);

            Grid.SetColumn(ampControl, 1);
            Grid.SetRow(ampControl, 1);

        }
    }
}
