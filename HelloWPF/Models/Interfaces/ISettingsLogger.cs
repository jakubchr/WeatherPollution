using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WePo.Models
{
    interface ISettingsLogger
    {
        void SaveSettings(Dictionary<String, String> dictionary);
    }
}
