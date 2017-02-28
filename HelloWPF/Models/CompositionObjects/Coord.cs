using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace WePo.Models
{
    public class Coord : INotifyPropertyChanged
    {
        public Coord() { }
        [JsonConstructor]
        public Coord(float lon, float lat)
        {
            Lon = lon;
            Lat = lat;
        }

        private float lon;
        public float Lon { get {return lon;} set { lon = value; OnPropertyChanged();
            }
        }
        private float lat;
        public float Lat { get { return lat; } set { lat = value; OnPropertyChanged();   }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        [HelloWPF.Annotations.NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}