using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRadio.Model.Player
{
    class WMPlayer : IMediaPlayer
    {
        private WMPLib.WindowsMediaPlayer _player;

        public WMPlayer()
        {
            this._player = new WMPLib.WindowsMediaPlayer();
        }
        public void Dispose()
        {
            if(this._player != null)
            {
                this._player.controls.stop();
                this._player = null;
            }
        }

        public void playUrl(string urlAsString)
        {
            this._player.URL = urlAsString;
            this._player.settings.volume = 100;
            this._player.controls.play();
        }

        public void stop()
        {
            this._player.controls.stop();
        }
    }
}
