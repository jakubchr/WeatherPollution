using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WePo.Models
{
    interface IWeatherLogger
    {
        void SaveData(Dictionary<String, String> dataDictionary);
    }
}
