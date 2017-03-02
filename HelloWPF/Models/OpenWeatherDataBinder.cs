using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WePo.Models
{
    class OpenWeatherDataBinder<T> : IDataSourceConverter<T> where T : IWeatherData
    {
    public T Data { get; private set; }

        public T DeserializeJSON(string json_data)
        {
            if (json_data.Length != 0)
            {
                Data = JsonConvert.DeserializeObject<T>(json_data);
            }
            else
            {
                throw new ApplicationException("json data is empty");
            }
            return Data;
        }

    }
}
