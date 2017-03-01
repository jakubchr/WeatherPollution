using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace WePo.Models
{
    public class Weather : INotifyPropertyChanged
    {
        public Weather() { }
        [JsonConstructor]
        public Weather(int id, string main, string description, string icon)
        {
            Id = id;
            Main = main;
            Description = description;
            Icon = icon;
        }
        public int Id { get; private set; }
        public string Main { get; private set; }
        public string Description { get; private set; }
        public string Icon { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [HelloWPF.Annotations.NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}