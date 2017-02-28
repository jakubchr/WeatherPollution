using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WePo.Models
{
    interface IURLBuilder
    {
        string BaseURL { get; set; }
        string BuildURL(Dictionary<string, string> parametersDictionary);
    }
}
