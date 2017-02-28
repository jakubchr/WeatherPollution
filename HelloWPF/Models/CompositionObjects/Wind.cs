using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace WePo.Models
{
    public class Wind : INotifyPropertyChanged
    {
        public Wind() { }
        [JsonConstructor]
        public Wind(float speed, float deg)
        {
            Speed = speed;
            Deg = deg;
        }

        private float speed;

        public float Speed
        {
            get
            {
                return speed;
            }
            set { speed = value; OnPropertyChanged();
            }
        }

        private float deg;

        public float Deg
        {
            get
            {
                return deg;
            }
            set
            {
                deg = value;
                OnPropertyChanged();

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [HelloWPF.Annotations.NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}