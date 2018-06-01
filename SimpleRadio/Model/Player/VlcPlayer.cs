using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRadio.Model.Player
{
    class VlcPlayer : IMediaPlayer
    {
        private Vlc.DotNet.Core.VlcMediaPlayer _player;

        public VlcPlayer(int volume)
        {
            this._player = new Vlc.DotNet.Core.VlcMediaPlayer(new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, "lib_vlc")));
            this._player.Log += _player_Log;
            setVolume(volume);
        }
        public void Dispose()
        {
            if (this._player != null)
            {
                this._player.Stop();
                this._player.Dispose();
                this._player = null;
            }
        }

        public void playUrl(string urlAsString)
        {
            this._player.SetMedia(new Uri(urlAsString));
            this._player.Play();
        }
        public void stop()
        {
            this._player.Stop();
        }

        public void record(string urlAsString, String filename)
        {
                this._player.SetMedia(new Uri(urlAsString), ":sout=#std{access=file,mux=mp4, dst='" + filename + "'}"); //transcode{vcodec=h264,acodec=mpga,ab=128,channels=2,samplerate=44100}:
                this._player.Play();
        }

        public void setVolume(int volume)
        {
            this._player.Audio.Volume = volume;
        }

        private void _player_Log(object sender, Vlc.DotNet.Core.VlcMediaPlayerLogEventArgs e)
        {
            if (e.Level == Vlc.DotNet.Core.Interops.Signatures.VlcLogLevel.Error)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }
    }
}
