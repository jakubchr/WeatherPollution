using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents.DocumentStructures;
using HelloWPF.Annotations;
using Newtonsoft.Json;

namespace HelloWPF.Models
{
    public class RootWeatherobject : IWeatherData, INotifyPropertyChanged
    {
        public RootWeatherobject() { }
        [JsonConstructor]
        public RootWeatherobject(Coord coord, Weather[] weather, string baseBase, Main main, Wind wind, Rain rain, Clouds clouds, int dt, Sys sys,
            int id, string name, int cod)
        {
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
        public Coord Coord { get; private set; }
        public Weather[] Weather { get; private set; }
        public string Base { get; private set; }
        public Main Main { get; private set; }
        public Wind Wind { get; private set; }
        public Rain Rain { get; private set; }
        public Clouds Clouds { get; private set; }
        public int Dt { get; private set; }
        public Sys Sys { get; private set; }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Cod { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Coord
    {
        [JsonConstructor]
        public Coord(float lon, float lat)
        {
            Lon = lon;
            Lat = lat;
        }
        public float Lon { get; private set; }
        public float Lat { get; private set; }
    }

    public class Main
    {
        [JsonConstructor]
        public Main(float temp, float pressure, int humidity, float temp_min, float temp_max, float sea_level,
            float grnd_level)
        {
            Temp = temp;
            Pressure = pressure;
            Humidity = humidity;
            TempMin = temp_min;
            Temp_max = temp_max;
            Sea_level = sea_level;
            Grnd_level = grnd_level;
        }
        public float Temp { get; private set; }
        public float Pressure { get; private set; }
        public int Humidity { get; private set; }
        public float TempMin { get; private set; }
        public float Temp_max { get; private set; }
        public float Sea_level { get; private set; }
        public float Grnd_level { get; private set; }
    }

    public class Wind
    {
        [JsonConstructor]
        public Wind(float speed, float deg)
        {
            Speed = speed;
            Deg = deg;
        }
        public float Speed { get; private set; }
        public float Deg { get; private set; }
    }

    public class Rain
    {
        [JsonConstructor]
        public Rain(float _3h)
        {
            this._3h = _3h;
        }
        public float _3h { get; set; }
    }

    public class Clouds
    {
        [JsonConstructor]
        public Clouds(int all)
        {
            All = all;
        }
        public int All { get; private set; }
    }

    public class Sys
    {
        [JsonConstructor]
        public Sys(float message, string country, int sunrise, int sunset)
        {
            Message = message;
            Country = country;
            Sunrise = sunrise;
            Sunset = sunset;
        }
        public float Message { get; private set; }
        public string Country { get; private set; }
        public int Sunrise { get; private set; }
        public int Sunset { get; private set; }
    }

    public class Weather
    {
        [JsonConstructor]
        public Weather(int id, string main, string description, string icon)
        {
            Id = id;
            Main = main;
            Description = description;
            Icon = icon;
        }
        public int Id { get; private set; }
        public string Main { get; private set; }
        public string Description { get; private set; }
        public string Icon { get; private set; }
    }

}
