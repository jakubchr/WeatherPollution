using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WePo.Models
{
    interface IDataSource
    {
        IURLBuilder URLBuilder { get; set; }
        void DownloadDataByCity(string cityName);
        void DownloadDataByLatitudeLongitude(double latitude, double longitude);
        string PushURL();
    }
}
