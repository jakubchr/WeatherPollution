using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using WePo.Models;

namespace HelloWPF.Models.CompositionObjects
{
    public class OpenWeatherForecastWeatherObject
    {
        [JsonConstructor]
        public OpenWeatherForecastWeatherObject(string cod, int message, City city, int cnt, CitiesList[] list)
        {
            Cod = cod;
            Message = message;
            City = city;
            Cnt = cnt;
            List = list;
        }
        public string Cod { get; private set; }
        public int Message { get; private set; }
        public City City { get; private set; }
        public int Cnt { get; private set; }
        public CitiesList[] List { get; private set; }
    }

    public class CitiesList
    {
        public int dt { get; set; }
        public Temp temp { get; set; }
        public float pressure { get; set; }
        public int humidity { get; set; }
        public Weather[] weather { get; set; }
        public float speed { get; set; }
        public int deg { get; set; }
        public int clouds { get; set; }
        public float snow { get; set; }
    }

}