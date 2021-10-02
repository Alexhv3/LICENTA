using DigitalHarmony.Globals;
using DigitalHarmony.Models;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
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

namespace DigitalHarmony
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeAppLogic();
            InitializeComponent();
        }

        private void InitializeAppLogic()
        {
            AudioDevice<WaveInCapabilities> inputDevice = JSONs.Deserialize<AudioDeviceInputModel>(Properties.Settings.Default.InputDevice);
            inputDevice.Device = WaveIn.GetCapabilities(inputDevice.DeviceNumber);

            AudioDevice<WaveOutCapabilities> outputDevice = JSONs.Deserialize<AudioDeviceOutputModel>(Properties.Settings.Default.OutputDevice);
            outputDevice.Device = WaveOut.GetCapabilities(outputDevice.DeviceNumber);

            AudioDevices.InstanceInit = new AudioDeviceSingletonModel(inputDevice, outputDevice);
        }
    }
}
