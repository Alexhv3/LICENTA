using NAudio.Wave;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalHarmony.Models
{
    class AudioDevicesModel
    {
        public List<WaveInCapabilities> inputSources;
        public List<WaveOutCapabilities> outputSources;
    }

    class AudioDeviceSingletonModel
    {
        private AudioDevice<WaveInCapabilities> input;
        private AudioDevice<WaveOutCapabilities> output;

        public AudioDeviceSingletonModel(AudioDevice<WaveInCapabilities> input, AudioDevice<WaveOutCapabilities> output)
        {
            this.input = input;
            this.output = output;
        }

        public AudioDevice<WaveInCapabilities> Input
        {
            get
            {
                return this.input;
            }
        }

        public AudioDevice<WaveOutCapabilities> Output
        {
            get
            {
                return this.output;
            }
        }
    }

    public abstract class AudioDevice<T>
    {
        [JsonIgnore]
        private T device;
        [JsonIgnore]
        private int deviceNumber;

        public T Device
        {
            get
            {
                return this.device;
            }

            set
            {
                this.device = value;
            }
        }

        public int DeviceNumber
        {
            get
            {
                return this.deviceNumber;
            }

            set
            {
                this.deviceNumber = value;
            }
        }

        public abstract override string ToString();
    }

    public class AudioDeviceInputModel : AudioDevice<WaveInCapabilities>
    {
        public AudioDeviceInputModel(WaveInCapabilities device, int deviceNumber)
        {
            base.Device = device;
            base.DeviceNumber = deviceNumber;
        }

        public override string ToString()
        {
            return base.Device.ProductName;
        }
    }

    public class AudioDeviceOutputModel : AudioDevice<WaveOutCapabilities>
    {
        public AudioDeviceOutputModel(WaveOutCapabilities device, int deviceNumber)
        {
            base.Device = device;
            base.DeviceNumber = deviceNumber;
        }

        public override string ToString()
        {
            return base.Device.ProductName;
        }
    }
}
