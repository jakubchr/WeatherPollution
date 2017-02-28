using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents.DocumentStructures;
using Newtonsoft.Json;
using WePo.Annotations;

namespace WePo.Models
{
    public class OpenWeatherObject : IWeatherData, INotifyPropertyChanged
    {
        public OpenWeatherObject() { }
        [JsonConstructor]
        public OpenWeatherObject(Coord coord, Weather[] weather, string baseBase, Main main, Wind wind, Rain rain,
            Clouds clouds, int dt, Sys sys,
            int id, string name, int cod)
        {
            Coord = new Coord();
            Coord = coord;
            Weather = weather;
            Base = baseBase;
            Main = main;
            Wind = wind;
            Rain = rain;
            Clouds = clouds;
            Dt = dt;
            Sys = sys;
            Id = id;
            Name = name;
            Cod = cod;
        }

        private Coord coord;

        public Coord Coord
        {
            get { return coord; }
            set
            {
                coord = value;
                OnPropertyChanged();
            }
        }

        private Weather[] weather;

        public Weather[] Weather
        {
            get
            {
                return weather;
            }
            set
            {
                weather = value; OnPropertyChanged();

            }
        }
        private string baseString;

        public string Base
        {
            get
            {
                return baseString;
            }
            set
            {
                baseString = value; OnPropertyChanged();

            }
        }

        private Main main;

        public Main Main
        {
            get { return main; }
            set
            {
                main = value; OnPropertyChanged();

            }
        }

        private Wind wind;

        public Wind Wind
        {
            get { return wind; }
            set
            {
                wind = value; OnPropertyChanged();

            }
        }

        private Rain rain;

        public Rain Rain
        {
            get { return rain; }
            set
            {
                rain = value; OnPropertyChanged();

            }
        }

        private Clouds clouds;

        public Clouds Clouds
        {
            get { return clouds; }
            set
            {
                clouds = value; OnPropertyChanged();

            }
        }

        private int dt;

        public int Dt
        {
            get { return dt; }
            set
            {
                dt = value; OnPropertyChanged();

            }
        }

        private Sys sys;

        public Sys Sys
        {
            get { return sys; }
            set { sys = value; OnPropertyChanged();
            }
        }

        private int id;

        public int Id
        {
            get
            {
                return id;
            }
            set { id = value; OnPropertyChanged();
            }
        }

        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            set { name = value; OnPropertyChanged();}
        }

        private int cod;

        public int Cod
        {
            get { return cod; }
            set
            {
                cod = value; OnPropertyChanged();

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [HelloWPF.Annotations.NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
