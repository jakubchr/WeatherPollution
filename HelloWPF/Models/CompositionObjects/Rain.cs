using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace WePo.Models
{
    public class Rain : INotifyPropertyChanged
    {
        public Rain() { }
        [JsonConstructor]
        public Rain(float _3h)
        {
            this._3h = _3h;
        }
        public float _3h { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [HelloWPF.Annotations.NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}