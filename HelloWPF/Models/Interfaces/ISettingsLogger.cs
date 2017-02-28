using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWPF.Models
{
    interface ISettingsLogger
    {
        void SaveSettings(Dictionary<String, String> dictionary);
    }
}
