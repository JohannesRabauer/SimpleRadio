using SimpleRadio.Helper;
using System;

namespace SimpleRadio.Model
{
    class Recorder : BaseModel
    {
        private bool _isActivated;

        public bool isActivated
        {
            get { return _isActivated; }
            set { _isActivated = value;
                OnPropertyChanged("isActivated");
            }
        }


        private DateTime _startTime;

        public DateTime startTime
        {
            get { return _startTime; }
            set { _startTime = value;
                OnPropertyChanged("startTime");
            }
        }

        private DateTime _endTime;

        public DateTime endTime
        {
            get { return _endTime; }
            set { _endTime = value;
                OnPropertyChanged("endTime");
            }
        }

        private Station _selectedStation;

        public Station selectedStation
        {
            get { return _selectedStation; }
            set { _selectedStation = value;
                OnPropertyChanged("selectedStation");
            }
        }

        public Recorder()
        {

        }
    }
}
