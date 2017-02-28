using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WePo.Models
{
    class OpenWeatherAPIURLBuilder : IURLBuilder
    {
        public OpenWeatherAPIURLBuilder(string baseURL, string apiKey)
        {
            BaseURL = baseURL;
            ApiKey = apiKey.Trim();
        }

        private string _baseURL;
        public string BaseURL
        {
            get { return _baseURL; }
            set
            {
                if (value == null || value.Length == 0)
                {
                    throw new ArgumentException("Passed URL is NULL or empty");
                }
                if (Uri.IsWellFormedUriString(value, UriKind.Absolute))
                {
                    _baseURL = value;
                }
                else
                {
                    throw new ArgumentException("Provided URL is not valid. It should be like: https://www.google.com");
                }
            }
        }

        private string ApiKey { get; }
        public string BuildURL(Dictionary<string, string> parametersDictionary)
        {
            if (parametersDictionary == null || parametersDictionary.Count == 0)
            {
                throw new ArgumentException("You must provide at least one weather location parameter");
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(BaseURL);
            sb.Append("?");
            foreach (KeyValuePair<string, string> kvp in parametersDictionary)
            {
                sb.Append($"{kvp.Key}={kvp.Value}");
                sb.Append("&");
            }
            sb.Append($"ApiKey={ApiKey}");
            return sb.ToString();
        }
    }
}
