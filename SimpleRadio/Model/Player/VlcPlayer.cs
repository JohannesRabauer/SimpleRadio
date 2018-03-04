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

        public VlcPlayer()
        {
            this._player = new Vlc.DotNet.Core.VlcMediaPlayer(new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, "lib_vlc")));
        }
        public void Dispose()
        {
            if(this._player != null)
            {
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
    }
}
