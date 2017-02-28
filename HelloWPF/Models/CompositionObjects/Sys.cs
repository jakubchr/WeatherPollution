using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace WePo.Models
{
    public class Sys : INotifyPropertyChanged
    {
        public Sys() { }
        [JsonConstructor]
        public Sys(float message, string country, int sunrise, int sunset)
        {
            Message = message;
            Country = country;
            Sunrise = sunrise;
            Sunset = sunset;
        }
        public float Message { get; private set; }
        public string Country { get; private set; }
        public int Sunrise { get; private set; }
        public int Sunset { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [HelloWPF.Annotations.NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}