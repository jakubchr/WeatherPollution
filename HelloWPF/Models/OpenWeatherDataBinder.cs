using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HelloWPF.Models
{
    class OpenWeatherDataBinder : IDataSourceConverter
    {
        public IWeatherData WeatherData { get; private set; }
        public IWeatherData DeserializeJSON<T>(string json_data) where T : IWeatherData
        {
            if (json_data.Length != 0)
            {
                WeatherData = JsonConvert.DeserializeObject<T>(json_data);
            }
            else
            {
                throw new ApplicationException("json data is empty");
            }
            return WeatherData;
        }
    }
}
