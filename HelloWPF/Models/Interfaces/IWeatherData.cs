using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWPF.Models
{
    interface IWeatherData
    {
        Coord Coord { get; }
        Weather[] Weather { get; }
        string Base { get; }
        Main Main { get; }
        Wind Wind { get; }
        Rain Rain { get; }
        Clouds Clouds { get; }
        int Dt { get; }
        Sys Sys { get; }
        int Id { get; }
        string Name { get; }
        int Cod { get; }
    }
}
