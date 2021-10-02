using DigitalHarmony.Models;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalHarmony.Globals
{
    class AudioDevices
    {
        private static AudioDevices _inst = null;

        private AudioDevice<WaveInCapabilities> inputDevice = null;
        private AudioDevice<WaveOutCapabilities> outputDevice = null;

        private BufferedWaveProvider bufferedWaveProvider;
        private WaveProcessProvider waveProcessProvider;

        private WaveIn waveIn = null;
        private WaveOut waveOut = null;

        private int sampleRate = 44100;
        private int channels = 1;
        private float volumeOutInit = 0;

        private static readonly short NUMBER_OF_BUFFERS = 32;
        private static readonly int BUFFER_SIZE = (int)Math.Pow(2, 11);
        private static readonly short BUFFER_MILLISECONDS = 1;
        private static readonly short LATENCY = 5;

        private AudioDevices(AudioDeviceSingletonModel adsm)
        {
            int okToPlay = 0;

            if (adsm != null)
            {

                if(adsm.Input != null)
                {
                    this.inputDevice = adsm.Input;
                    okToPlay++;
                }

                if (adsm.Output != null)
                {
                    this.outputDevice = adsm.Output;
                    okToPlay++;
                }
            }

            this.sampleRate = Properties.Settings.Default.SampleRate;
            this.channels = Properties.Settings.Default.Channels;
            this.volumeOutInit = (float)Properties.Settings.Default.OutputVolume / 100f;

            if (okToPlay == 2)
            {
                //this.Play();
            }
        }

        public void Play()
        {
            if(this.inputDevice == null || this.outputDevice == null)
            {
                return;
            }

            this.Stop();

            this.waveIn = new WaveIn();
            this.waveIn.DeviceNumber = this.inputDevice != null ? this.inputDevice.DeviceNumber : -1;
            this.waveIn.NumberOfBuffers = NUMBER_OF_BUFFERS;
            this.waveIn.BufferMilliseconds = BUFFER_MILLISECONDS;
            this.waveIn.WaveFormat = new WaveFormat(this.sampleRate, this.channels);
            this.waveIn.DataAvailable += waveIn_DataAvailable;

            this.bufferedWaveProvider = new BufferedWaveProvider(this.waveIn.WaveFormat);
            this.bufferedWaveProvider.BufferLength = BUFFER_SIZE * 2;
            this.bufferedWaveProvider.DiscardOnBufferOverflow = true;
            this.waveProcessProvider = new WaveProcessProvider(waveIn, this.bufferedWaveProvider);

            this.waveOut = new WaveOut();
            this.waveOut.DeviceNumber = this.outputDevice != null ? this.outputDevice.DeviceNumber : -1;
            this.waveOut.NumberOfBuffers = NUMBER_OF_BUFFERS;
            this.waveOut.DesiredLatency = LATENCY;
            this.waveOut.Volume = this.volumeOutInit;
            this.waveOut.Init(this.waveProcessProvider);

            this.waveIn.StartRecording();
            this.waveOut.Play();

            PropertiesSection.SetParamterValue<string>("InputDevice", JSONs.Serialize<AudioDevice<WaveInCapabilities>>(this.inputDevice));
            PropertiesSection.SetParamterValue<string>("OutputDevice", JSONs.Serialize<AudioDevice<WaveOutCapabilities>>(this.outputDevice));
            PropertiesSection.Save();
        }

        public void Stop()
        {
            if(this.waveIn != null)
            {
                this.waveIn.StopRecording();
                this.waveIn.Dispose();
                this.waveIn = null;
            }

            if(this.waveOut != null)
            {
                this.waveOut.Stop();
                this.waveOut.Dispose();
                this.waveOut = null;
            }
        }

        private void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            this.bufferedWaveProvider.AddSamples(e.Buffer, 0, e.BytesRecorded);
        }

        public static AudioDevices Instance
        {
            get
            {
                if (_inst != null)
                {
                    return _inst;
                }
                return null;
            }
        }

        public static AudioDeviceSingletonModel InstanceInit
        {
            set
            {
                if (_inst == null)
                {
                    _inst = new AudioDevices(value);
                }
            }
        }

        public static AudioDevicesModel getDevices()
        {
            List<WaveInCapabilities> inputSources = new List<WaveInCapabilities>();
            List<WaveOutCapabilities> outputSources = new List<WaveOutCapabilities>();

            int i_n = WaveIn.DeviceCount;
            int o_n = WaveOut.DeviceCount;

            for (int i = 0; i < i_n; i++)
            {
                inputSources.Add(WaveIn.GetCapabilities(i));
            }

            for (int i = 0; i < o_n; i++)
            {
                outputSources.Add(WaveOut.GetCapabilities(i));
            }

            return new AudioDevicesModel
            {
                inputSources = inputSources,
                outputSources = outputSources
            };
        }

        public AudioDevice<WaveInCapabilities> Input
        {
            get
            {
                return this.inputDevice;
            }

            set
            {
                this.inputDevice = value;
            }
        }

        public AudioDevice<WaveOutCapabilities> Output
        {
            get
            {
                return this.outputDevice;
            }

            set
            {
                this.outputDevice = value;
            }
        }

        public int SampleRate
        {
            get
            {
                return this.sampleRate;
            }

            set
            {
                this.sampleRate = value;
            }
        }

        public int Channels
        {
            get
            {
                return this.channels;
            }

            set
            {
                this.channels = value;
            }
        }

        public double WaveOutVolume
        {
            get
            {
                return (double)(this.volumeOutInit) * 100d;
            }

            set
            {
                this.volumeOutInit = (float)(value) / 100f;
                if (waveOut == null)
                {
                    return;
                }
                this.waveOut.Volume = volumeOutInit;
            }
        }
    }
}
