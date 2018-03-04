using SimpleRadio.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRadio.Model
{
    class StationStream : BaseModel
    {
        private Uri _stream;

        public Uri stream
        {
            get { return _stream; }
            set { _stream = value; }
        }

        private int _bitrate;

        public int bitrate
        {
            get { return _bitrate; }
            set { _bitrate = value; }
        }


        private String _content_type;

        public String content_type
        {
            get { return _content_type; }
            set { _content_type = value; }
        }

        private int _status;

        public int status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
}
