using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRadio.Model.Player
{
    interface IMediaPlayer : IDisposable
    {
        void playUrl(String urlAsString);
        void stop();
    }
}
