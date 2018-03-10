using SimpleRadio.Helper;
using System;
using System.Collections.ObjectModel;

namespace SimpleRadio.Model
{
    class Recorder : BaseModel, IDisposable
    {
        private bool _isActivated;

        public bool isActivated
        {
            get { return _isActivated; }
            set
            {
                _isActivated = value;
                OnPropertyChanged("isActivated");
            }
        }


        private DateTime _startTime;

        public DateTime startTime
        {
            get { return _startTime; }
            set
            {
                _startTime = value;
                OnPropertyChanged("startTime");
            }
        }

        private DateTime _endTime;

        public DateTime endTime
        {
            get { return _endTime; }
            set
            {
                _endTime = value;
                OnPropertyChanged("endTime");
            }
        }

        private ObservableCollection<Station> _favoriteStations;

        public ObservableCollection<Station> favoriteStations
        {
            get { return _favoriteStations; }
            set
            {
                _favoriteStations = value;
                OnPropertyChanged("favoriteStations");
            }
        }

        private Station _selectedStation;

        public Station selectedStation
        {
            get { return _selectedStation; }
            set
            {
                _selectedStation = value;
                OnPropertyChanged("selectedStation");
            }
        }

        private System.Timers.Timer _waitForStartTimer;
        private System.Timers.Timer _waitForEndTimer;

        public Recorder() : this(new ObservableCollection<Station>())
        {
        }

        public Recorder(ObservableCollection<Station> favoriteStations)
        {
            this.favoriteStations = favoriteStations;
            this._waitForStartTimer = new System.Timers.Timer();
            this._waitForStartTimer.Elapsed += startRecording;
            this._waitForEndTimer = new System.Timers.Timer();
            this._waitForEndTimer.Elapsed += stopRecording;
        }

        private void startRecording(Object s, System.Timers.ElapsedEventArgs e)
        {
            this._selectedStation.startRecording();
        }

        private void stopRecording(Object s, System.Timers.ElapsedEventArgs e)
        {
            this._selectedStation.stopRecording();
        }

        public void Dispose()
        {
            this._waitForStartTimer.Dispose();
            this._waitForStartTimer = null;
            this._waitForEndTimer.Dispose();
            this._waitForEndTimer = null;
        }
    }
}
