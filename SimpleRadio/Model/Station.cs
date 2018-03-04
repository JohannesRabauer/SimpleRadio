﻿using SimpleRadio.Helper;
using SimpleRadio.Model.Player;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleRadio.Model
{
    class Station : BaseModel, IDisposable
    {
        private int _id;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }


        private String _name;

        public String name
        {
            get { return _name; }
            set { _name = value; }
        }

        private String _description;

        public String description
        {
            get { return _description; }
            set { _description = value; }
        }

        private String _country;

        public String country
        {
            get { return _country; }
            set { _country = value; }
        }

        private Uri _website;

        public Uri website
        {
            get { return _website; }
            set { _website = value; }
        }

        private DateTime _created_at;

        public DateTime created_at
                    {
            get { return _created_at; }
            set { _created_at = value; }
        }

        private DateTime _updated_at;

        public DateTime updated_at
        {
            get { return _updated_at; }
            set { _updated_at = value; }
        }

        private StationImage _image;

        public StationImage image
        {
            get { return _image; }
            set { _image = value; }
        }


        private String _slug;

        public String slug
        {
            get { return _slug; }
            set { _slug = value; }
        }

        private Uri _twitter;

        public Uri twitter
        {
            get { return _twitter; }
            set { _twitter = value; }
        }


        private Uri _facebook;

        public Uri facebook
        {
            get { return _facebook; }
            set { _facebook = value; }
        }

        private List<Category> _categories;

        public List<Category> categories
        {
            get { return _categories; }
            set { _categories = value; }
        }

        private List<StationStream> _streams;

        public List<StationStream> streams
        {
            get { return _streams; }
            set { _streams = value; }
        }

        private bool _isPlaying;
        public bool isPlaying
        {
            get { return _isPlaying; }
            set { _isPlaying = value;
                OnPropertyChanged("isPlaying");
            }
        }
        
        public ICommand commandPlayToggle { get; set; }
        public ICommand commandAddFavoriteStation { get; set; }

        private IMediaPlayer _player;
        private MainContext _parent;

        public Station()
        {
            this.commandPlayToggle = new RelayCommand(param => playToggle());
            this.commandAddFavoriteStation = new RelayCommand(param => addFavoriteStation());
            this.isPlaying = false;
        }

        public void init(MainContext parent)
        {
            this._parent = parent;
        }

        private void addFavoriteStation()
        {
            this._parent.addFavoriteStation(this);
        }

        private void playToggle()
        {
            if(this._isPlaying)
            {
                this._player.stop();
                this.isPlaying = false;
            }
            else
            {
                if(this._player == null)
                {
                    this._player = new VlcPlayer();
                }
                this._player.playUrl(this._streams.First().stream.AbsoluteUri);
                this.isPlaying = true;
            }

        }

        public void Dispose()
        {
            if(this._player != null)
            {
                this._player.Dispose();
                this._player = null;
            }
        }
    }
}