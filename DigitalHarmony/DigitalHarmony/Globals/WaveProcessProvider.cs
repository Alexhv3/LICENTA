using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalHarmony.Globals
{
    class WaveProcessProvider : IWaveProvider
    {
        private readonly IWaveProvider sourceWaveProvider;

        public WaveProcessProvider(IWaveIn waveIn, IWaveProvider bufferedWaveProvider)
        {
            WaveFormat = waveIn.WaveFormat;
            this.sourceWaveProvider = bufferedWaveProvider;
        }

        public WaveFormat WaveFormat { get; }

        public int Read(byte[] buffer, int offset, int count)
        {
            byte[] editedBuffer = new byte[count];

            for(int i = 0; i < count; i++)
            {
                editedBuffer[i] = buffer[i];
                buffer[i] = (byte)((int)buffer[i] / 10);
            }

            var read = this.sourceWaveProvider.Read(buffer, offset, count);

            /*var sampleRate = 16000;
            var frequency = 500;
            var amplitude = 0.2;
            var seconds = 5;

            var raw = new byte[sampleRate * seconds * 2];

            var multiple = 2.0 * frequency / sampleRate;
            for (int n = 0; n < sampleRate * seconds; n++)
            {
                var sampleSaw = ((n * multiple) % 2) - 1;
                var sampleValue = sampleSaw > 0 ? amplitude : -amplitude;
                var sample = (short)(sampleValue * Int16.MaxValue);
                var bytes = BitConverter.GetBytes(sample);
                raw[n * 2] = bytes[0];
                raw[n * 2 + 1] = bytes[1];
            }
            var ms = new MemoryStream(raw);
            var rs = new RawSourceWaveStream(ms, new WaveFormat(sampleRate, 16, 1));*/

            return read;
        }
    }
}
