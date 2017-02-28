using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace HelloWPF.Models
{
    class OpenWeatherDownloader : IDataSource
    {
        public OpenWeatherDownloader(IURLBuilder urlBuilder)
        {
            URLBuilder = urlBuilder;
        }
        public IURLBuilder URLBuilder { get; set; }
        public string URL { get; private set; }
        private Dictionary<string, string> parametersDictionary = new Dictionary<string, string>();

        public void DownloadDataByCity(string cityName)
        {
            parametersDictionary.Add("q",cityName);
        }
        public void DownloadDataByLatitudeLongitude(double latitude, double longitude)
        {
            throw new NotImplementedException();
        }

        public string PushURL()
        {
            URL = URLBuilder.BuildURL(parametersDictionary);
            WebClient webClient = new WebClient();
            string json_data = String.Empty;

            try
            {
                json_data = webClient.DownloadString(URL);
            }
            catch (Exception ex)
            {
                throw new WebException(ex.Message);
            }
            return json_data;
        }
    }
}
