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
    public class RootWeatherobject : IWeatherData
    {
        public RootWeatherobject()
        {
            coord = new Coord();
            weather = new Weather[1];
            weather[0] = new Weather();
            baseString = String.Empty;
            main  = new Main();
            wind =  new Wind();
            rain = new Rain();
            clouds = new Clouds();
            dt = Int32.MinValue;
            sys = new Sys();
            id = Int32.MinValue;
            name = String.Empty;
            cod = Int32.MinValue;
        }

        [JsonConstructor]
        public RootWeatherobject(Coord coord, Weather[] weather, string baseBase, Main main, Wind wind, Rain rain,
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
                weather = value;
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
                baseString = value;
            }
        }

        private Main main;

        public Main Main
        {
            get { return main; }
            set
            {
                main = value;
            }
        }

        private Wind wind;

        public Wind Wind
        {
            get { return wind; }
            set
            {
                wind = value;
            }
        }

        private Rain rain;

        public Rain Rain
        {
            get { return rain; }
            set
            {
                rain = value;
            }
        }

        private Clouds clouds;

        public Clouds Clouds
        {
            get { return clouds; }
            set
            {
                clouds = value;
            }
        }

        private int dt;

        public int Dt
        {
            get { return dt; }
            set
            {
                dt = value;
            }
        }

        private Sys sys;

        public Sys Sys
        {
            get { return sys; }
            set { sys = value; }
        }

        private int id;

        public int Id
        {
            get
            {
                return id;
            }
            set { id = value; }
        }

        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            set { name = value; }
        }

        private int cod;

        public int Cod
        {
            get { return cod; }
            set
            {
                cod = value;
            }
        }
    }

    public class Coord
    {
        public Coord() { }
        [JsonConstructor]
        public Coord(float lon, float lat)
        {
            Lon = lon;
            Lat = lat;
        }

        private float lon;
        public float Lon { get {return lon;} set { lon = value; } }
        private float lat;
        public float Lat { get { return lat; } set { lat = value; } }
    }

    public class Main
    {
        public Main() { }
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

        private float temp;
        public float Temp
        {
            get { return temp; }
            set { temp = value; }
        }

        private float pressure;
        public float Pressure {
            get { return pressure; }
            set
            {
                pressure = value;
            }
        }

        private int humidity;

        public int Humidity
        {
            get
            {
                return humidity;
            }
            set
            {
                humidity = value;
            }
        }

        private float tempMin;

        public float TempMin
        {
            get
            {
                return tempMin;
            }
            set
            {
                tempMin = value;
            }
        }

        private float temp_max;

        public float Temp_max
        {
            get
            {
                return temp_max;
            }
            set
            {
                temp_max = value;
            }
        }

        private float sea_Level;

        public float Sea_level
        {
            get { return sea_Level; }
            set
            {
                sea_Level = value;
            }
        }

        private float grnd_Level;

        public float Grnd_level
        {
            get
            {
                return grnd_Level;
            }
            set { grnd_Level = value;
            }
        }
    }

    public class Wind
    {
        public Wind() { }
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
        public Rain() { }
        [JsonConstructor]
        public Rain(float _3h)
        {
            this._3h = _3h;
        }
        public float _3h { get; set; }
    }

    public class Clouds
    {
        public Clouds() { }
        [JsonConstructor]
        public Clouds(int all)
        {
            All = all;
        }
        public int All { get; private set; }
    }

    public class Sys
    {
        public Sys() { }
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
        public Weather() { }
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
