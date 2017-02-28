using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WePo.Models
{
    interface ISettingsReader
    {
        string SettingsSource { get; }
        void ReadSettings();
    }
}
