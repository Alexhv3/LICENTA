using DigitalHarmony.Globals;
using NAudio.Mixer;
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
    /// Interaction logic for VolumeControl.xaml
    /// </summary>
    public partial class VolumeControl : UserControl
    {
        private AudioDevices audioDevices;
        private UnsignedMixerControl InputVolumeControl;

        public VolumeControl()
        {
            InitializeComponent();
            DataContext = this;
            this.audioDevices = AudioDevices.Instance;
            this.SetVolumes();
        }

        private void SetVolumes()
        {
            var mixerLine = new MixerLine((IntPtr)/*this.audioDevices.Input.DeviceNumber*/0,
                                           0, MixerFlags.WaveIn);
            foreach (var control in mixerLine.Controls)
            {
                if (control.ControlType == MixerControlType.Volume)
                {
                    this.InputVolumeControl = control as UnsignedMixerControl;
                    break;
                }
            }

            this.InputVolume = PropertiesSection.GetParamterValue<double>("InputVolume");
            this.outputVolumeSlider.Value = this.audioDevices.WaveOutVolume;
        }

        public double InputVolume
        {
            get
            {
                return this.InputVolumeControl.Percent;
            }

            set
            {
                PropertiesSection.SetParamterValue<double>("InputVolume", value);
                PropertiesSection.Save();
                this.InputVolumeControl.Percent = value;
            }
        }

        public double OutputVolume
        {
            set
            {
                PropertiesSection.SetParamterValue<double>("OutputVolume", value);
                PropertiesSection.Save();
                this.audioDevices.WaveOutVolume = value;
            }
        }
    }
}
