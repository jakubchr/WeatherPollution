using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWPF.Models
{
    public static class UnitConverter
    {
        public static float ToCelsius(float kelvin)
        {
            float celsius = kelvin - (float)273.15;
            return celsius;
        }
        public static float ToKelvin(float celsius)
        {
            float kelvin = celsius + (float)273.15;
            return kelvin;
        }
    }
}
