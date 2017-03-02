using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WePo.Models
{
    interface IDataSourceConverter<out T>
    {
        T Data { get; }
        T DeserializeJSON(string json_data);
    }
}
