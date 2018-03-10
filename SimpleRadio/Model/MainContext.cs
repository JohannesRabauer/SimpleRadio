using Newtonsoft.Json;
using SimpleRadio.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;

namespace SimpleRadio.Model
{
    class MainContext : BaseModel, IDisposable
    {
        private DirbleCommunicator _communicator;

        private String _searchString;

        public String searchString
        {
            get { return _searchString; }
            set
            {
                _searchString = value;
                OnPropertyChanged("searchString");
            }
        }

        private ObservableCollection<Station> _stationsToView;
        public ObservableCollection<Station> stationsToView
        {
            get { return _stationsToView; }
            set
            {
                _stationsToView = value;
                OnPropertyChanged("stationsToView");
            }
        }

        private ObservableCollection<Station> _favoriteStations;

        public ObservableCollection<Station> favoriteStations
        {
            get { return _favoriteStations; }
            set { _favoriteStations = value; }
        }

        private ObservableCollection<Recorder> _recorderList;

        public ObservableCollection<Recorder> recorderList
        {
            get { return _recorderList; }
            set { _recorderList = value;
                OnPropertyChanged("recorderList");
            }
        }



        public ICommand commandGetAllStations { get; set; }
        public ICommand commandSearchStations { get; set; }
        public ICommand commandAddRecorder { get; set; }
        public ICommand commandRemoveRecorder { get; set; }

        public MainContext()
        {
            this._communicator = new DirbleCommunicator();
            this.commandGetAllStations = new RelayCommand(param => getAllStations());
            this.commandSearchStations = new RelayCommand(param => searchStations());
            this.commandAddRecorder = new RelayCommand(param => addRecorder());
            this.favoriteStations = new ObservableCollection<Station>(loadFavoriteStations());
            this.recorderList = new ObservableCollection<Recorder>{ new Recorder(this.favoriteStations) };
        }

        public void addFavoriteStation(Station stationToAdd)
        {
            this.favoriteStations.Add(stationToAdd);
        }

        private void addRecorder()
        {
            this.recorderList.Add(new Recorder(this.favoriteStations));
        }

        private void removeRecorder(Recorder recorderToRemove)
        {

        }

        private List<Station> loadFavoriteStations()
        {
            try
            {
                List<Station> loadedStations = JsonConvert.DeserializeObject<List<Station>>(Properties.Settings.Default.FavoriteStations);
                loadedStations.ForEach(s => s.init(this));
                return loadedStations;
            }
            catch (Exception)
            {
                return new List<Station>();
            }
        }

        private void saveFavoriteStations(List<Station> stations)
        {
            try
            {
                Properties.Settings.Default.FavoriteStations = JsonConvert.SerializeObject(stations);
                Properties.Settings.Default.Save();
            }
            catch (Exception )
            {
            }

        }

        private void getAllStations()
        {
            setAsStationsToView(this._communicator.getStations());
        }

        private void searchStations()
        {
            setAsStationsToView(this._communicator.searchStations(this._searchString));
        }

        private void setAsStationsToView(IEnumerable<Station> stations)
        {
            if (this.stationsToView != null)
                foreach (Station station in this.stationsToView)
                    station.Dispose();
            if (stations == null) return;
            this.stationsToView = new ObservableCollection<Station>(stations);
            foreach (Station newStation in stations)
            {
                newStation.init(this);
            }
        }

        public void Dispose()
        {
            if (this._communicator != null)
            {
                this._communicator.Dispose();
                this._communicator = null;
            }
            saveFavoriteStations(this._favoriteStations.ToList());
        }
    }
}
