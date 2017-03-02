using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWPF.Models.CompositionObjects
{
    public class City
    {
        public int geoname_id { get; set; }
        public string name { get; set; }
        public float lat { get; set; }
        public float lon { get; set; }
        public string country { get; set; }
        public string iso2 { get; set; }
        public string type { get; set; }
        public int population { get; set; }
    }
}
