using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace WePo.Models
{
    public class Main : INotifyPropertyChanged
    {
        public Main() { }
        [JsonConstructor]
        public Main(float temp, float pressure, int humidity, float temp_min, float temp_max, float sea_level,
            float grnd_level)
        {
            Temp = temp;
            Pressure = pressure;
            Humidity = humidity;
            TempMin = temp_min;
            Temp_max = temp_max;
            Sea_level = sea_level;
            Grnd_level = grnd_level;
        }

        private float temp;
        public float Temp
        {
            get { return temp; }
            set { temp = value; OnPropertyChanged();
            }
        }

        private float pressure;
        public float Pressure {
            get { return pressure; }
            set
            {
                pressure = value; OnPropertyChanged();

            }
        }

        private int humidity;

        public int Humidity
        {
            get
            {
                return humidity;
            }
            set
            {
                humidity = value; OnPropertyChanged();

            }
        }

        private float tempMin;

        public float TempMin
        {
            get
            {
                return tempMin;
            }
            set
            {
                tempMin = value; OnPropertyChanged();

            }
        }

        private float temp_max;

        public float Temp_max
        {
            get
            {
                return temp_max;
            }
            set
            {
                temp_max = value; OnPropertyChanged();

            }
        }

        private float sea_Level;

        public float Sea_level
        {
            get { return sea_Level; }
            set
            {
                sea_Level = value; OnPropertyChanged();

            }
        }

        private float grnd_Level;

        public float Grnd_level
        {
            get
            {
                return grnd_Level;
            }
            set { grnd_Level = value; OnPropertyChanged();

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