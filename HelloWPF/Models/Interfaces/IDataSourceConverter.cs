using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HelloWPF.Models
{
    interface IDataSourceConverter
    {
        IWeatherData WeatherData { get; }
        IWeatherData DeserializeJSON<T>(string json_data) where T : IWeatherData;
    }
}
