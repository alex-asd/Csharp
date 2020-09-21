using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNP2_WPF1_Ass5
{
    class Multimedia : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public enum MediaType
        {
            CD,
            DVD
        };

        private string _title;
        private string _artist;
        private string _genre;
        private MediaType _type;

        public string Title
        {
            get { return _title; }
            set
            {
                if (value != _title)
                {
                    _title = value;
                    OnPropertyChanged("Title");
                }
            }
        }
        public string Artist
        {
            get { return _artist; }
            set
            {
                if (value != _artist)
                {
                    _artist = value;
                    OnPropertyChanged("Artist");
                }
            }
        }
        public string Genre
        {
            get { return _genre; }
            set
            {
                if (value != _genre)
                {
                    _genre = value;
                    OnPropertyChanged("Genre");
                }
            }
        }
        public MediaType Type
        {
            get { return _type; }
            set
            {
                if (value != _type)
                {
                    _type = value;
                    OnPropertyChanged("Type");
                }
            }
        }


        public Multimedia(string title, string artist, string genre, MediaType type)
        {
            _title = title;
            _artist = artist;
            _genre = genre;
            _type = type;
        }
        
        override
        public string ToString()
        {
            return ($"{Artist} : {Title}");
        }
    }
}
