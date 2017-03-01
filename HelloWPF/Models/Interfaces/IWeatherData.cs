using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WePo.Models
{
    interface IWeatherData
    {
        Coord Coord { get; }
        Main Main { get; }
        Wind Wind { get; }
        Rain Rain { get; }
        Clouds Clouds { get; }
        int Id { get; }
        string Name { get; }
        int Cod { get; }
    }
}
