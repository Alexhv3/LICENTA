How to process input audio signal with NAudio and play it in real time? (C# WPF.NET)

I am developing a synthesizer for my electric guitar in WPF. For now I can only amplify my guitar with clean sound and I have done that using the NAudio library in .NET, which was very useful to me. So far I have implemented: input / output device selection, volume changer for both input and output, and playback while playing the guitar. The thing is, I want to process the input signal into various effects, like distortion, delay, reverb, custom amplification and so on and so forth. NAudio has no methods for this purpose as far as I know.

So my question is: how can I take the input signal, edit it and then output it in real time?

This is my code for playing the guitar:
```
public void Play()
{
    if (this.inputDevice == null || this.outputDevice == null)
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
    WaveInProvider waveInProvider = new WaveInProvider(waveIn);

    this.waveOut = new WaveOut();
    this.waveOut.DeviceNumber = this.outputDevice != null ? this.outputDevice.DeviceNumber : -1;
    this.waveOut.NumberOfBuffers = NUMBER_OF_BUFFERS;
    this.waveOut.DesiredLatency = LATENCY;
    this.waveOut.Volume = this.volumeOutInit;
    this.waveOut.Init(waveInProvider);

    this.waveIn.StartRecording();
    this.waveOut.Play();
}
```

inputDevice and outputDevice are not important to explain.

waveIn_DataAvailable does nothing atm.

Stop() is for making sure that there is always only one player active.

As you can see, I am setting waveIn and waveOut and then simply start recording and playing.It is pretty simple.

The only thing left then is to set, let's say an 'intermediary method' that takes the input signal, edits it according to my preferences and then sends it to the waveOut.

Has anyone ever implemented something like this ? Thank you!

C# .net wpf naudio signal-processing