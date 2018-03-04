using SimpleRadio.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRadio.Model
{
    class StationImageThumb : BaseModel
    {
        private Uri _url;

        public Uri url
        {
            get { return _url; }
            set { _url = value; }
        }

    }
}
