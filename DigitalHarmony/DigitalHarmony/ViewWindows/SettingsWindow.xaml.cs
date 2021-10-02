using DigitalHarmony.Globals;
using DigitalHarmony.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace DigitalHarmony.ViewWindows
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        private static SettingsWindow _inst = null;

        private SettingsWindow()
        {
            InitializeComponent();

            this.getAudioDevices();
        }

        public static SettingsWindow Instance
        {
            get
            {
                if (_inst == null)
                {
                    _inst = new SettingsWindow();
                }

                return _inst;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            e.Cancel = true;
        }

        private void getAudioDevices()
        {
            this.inputCB.Items.Clear();
            this.outputCB.Items.Clear();

            AudioDevicesModel audioDevices = AudioDevices.getDevices();

            foreach (var inputSource in audioDevices.inputSources.Select((value, index) => (value, index)))
            {
                this.inputCB.Items.Add(new AudioDeviceInputModel(inputSource.value, inputSource.index));
            }

            foreach (var outputSource in audioDevices.outputSources.Select((value, index) => (value, index)))
            {
                this.outputCB.Items.Add(new AudioDeviceOutputModel(outputSource.value, outputSource.index));
            }

            this.inputCB.SelectedIndex = AudioDevices.Instance.Input.DeviceNumber;
            this.outputCB.SelectedIndex = AudioDevices.Instance.Output.DeviceNumber;
        }

        private void saveSettingsBtn_Click(object sender, RoutedEventArgs e)
        {
            AudioDevices.Instance.Play();
        }

        private void inputCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.inputCB.Items.Count == 0)
                return;
            AudioDeviceInputModel aux = this.inputCB.SelectedItem as AudioDeviceInputModel;
            if (aux == null)
                return;
            AudioDevices.Instance.Input = aux;
        }

        private void outputCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.outputCB.Items.Count == 0)
                return;
            AudioDeviceOutputModel aux = this.outputCB.SelectedItem as AudioDeviceOutputModel;
            if (aux == null)
                return;
            AudioDevices.Instance.Output = aux;
        }
    }
}
