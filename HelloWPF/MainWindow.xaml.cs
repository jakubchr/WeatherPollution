using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HelloWPF.Models;

namespace HelloWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _baseURL;
        private string _apiKey = @"f7e2509b51e34ef70bc66b0a816fbb11";
        private string _aqicnToken = @"a4be2dbca8a043b96f8e7bf89a078a2a34e36420";
        private string _city;
        private IURLBuilder _urlBuilder;
        private IDataSource _weatherDownloader;
        private IWeatherData _weatherObject;
        private IDataSourceConverter _weatherDataBinder;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddCityButton_Click(object sender, RoutedEventArgs e)
        {
            if (AddCityToDropdownBox.Text.Length == 0 || AddCityToDropdownBox == null)
            {
                AddCityToDropdownBox.Text = "Enter city name please!";
                return;
            }
            string city = AddCityToDropdownBox.Text;
            CitiesComboBox.Items.Add(city);
        }

        private void ShowWeatherButton_Click(object sender, RoutedEventArgs e)
        {
            if (!AssignInitializeData())
            {
                return;
            }

            _weatherDownloader.DownloadDataByCity(_city);
            _weatherObject = (RootWeatherobject) _weatherDataBinder.DeserializeJSON<RootWeatherobject>(_weatherDownloader.PushURL());

            TemperatureBox.Text = _weatherObject.Main.Temp.ToString("0.0000");
        }

        private bool AssignInitializeData()
        {
            if (OpenWeatherServiceRadio.IsChecked == true)
            {
                _baseURL = @"http://api.openweathermap.org/data/2.5/weather";
                _urlBuilder = new OpenWeatherAPIURLBuilder(_baseURL, _apiKey);
                _weatherDownloader = new OpenWeatherDownloader(_urlBuilder);
                _weatherObject = new RootWeatherobject();
                _weatherDataBinder = new OpenWeatherDataBinder();
            }

            if (CitiesComboBox.SelectedItem == null || CitiesComboBox.SelectedItem.ToString().Length == 0)
            {
                MessageBox.Show("You have not selected city!");
                return false;
            }

            try
            {
                _city = ((ComboBoxItem) CitiesComboBox.SelectedItem).Content.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Message returned by application: {ex.Message} \n Probably city name is invalid.");
                return false;
            }
            return true;
        }

        private void TemperatureBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Regex.IsMatch(TemperatureBox.Text, @"\d"))
            {
                if (TemperatureUnitBox.Text == "K")
                {
                    TemperatureBox.Text = UnitConverter.ToCelsius(float.Parse(TemperatureBox.Text)).ToString("0.000");
                    TemperatureUnitBox.Text = "°C";
                }
                else
                {
                    TemperatureBox.Text = UnitConverter.ToKelvin(float.Parse(TemperatureBox.Text)).ToString("0.000");
                    TemperatureUnitBox.Text = "K";
                }
            }
            else
            {
                if (TemperatureBox.Text == "Fahrenheit")
                {
                    TemperatureBox.Text = "Celsius";
                    TemperatureUnitBox.Text = "°C";
                }
                else
                {
                    TemperatureBox.Text = "Fahrenheit";
                    TemperatureUnitBox.Text = "K";
                }
            }
        }

        private void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            TemperatureBox_PreviewMouseDown(sender, e);
        }

        private void TemperatureUnitBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            TemperatureBox_PreviewMouseDown(sender, e);
        }

        /*TEST
        private void ShowWeatherButton_Click(object sender, RoutedEventArgs e)
        {
            OpenWeatherAPIURLBuilder urlBuilder = new OpenWeatherAPIURLBuilder("http://api.openweathermap.org/data/2.5/weather", "f7e2509b51e34ef70bc66b0a816fbb11");
            OpenWeatherDownloader openWeatherDownloader = new OpenWeatherDownloader(urlBuilder);
            openWeatherDownloader.DownloadDataByCity("Siemiatycze");
            RootWeatherobject rootWeatherobject = new RootWeatherobject();
            OpenWeatherDataBinder openWeatherDataBinder = new OpenWeatherDataBinder();
            rootWeatherobject = (RootWeatherobject) openWeatherDataBinder.DeserializeJSON<RootWeatherobject>(openWeatherDownloader.PushURL());


            TemperatureBox.Text = rootWeatherobject.Main.Temp.ToString("0.0000");
        }
        */
    }
}
