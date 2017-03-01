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
using WePo.Models;

namespace WePo
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
        private IWeatherData _weatherData;
        private IDataSourceConverter<IWeatherData> _DataBinder;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _weatherData;
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
            if (!AssignInitializeWeatherData())
            {
                return;
            }

            _weatherData = _DataBinder.DeserializeJSON(_weatherDownloader.PushURL());

            DetermineWeatherDataToShow();
        }

        public void DetermineWeatherDataToShow()
        {
            if (WeatherCheckBox.IsChecked == true)
            {
                TemperatureBox.Text = _weatherData.Main.Temp.ToString("0.0000");
                PressureBox.Text = _weatherData.Main.Pressure.ToString("0.00");
            }
            if (AdvancedCheckBox.IsChecked == true)
            {
                WindSpeedBox.Text = _weatherData.Wind.Speed.ToString("0.000");
            }
        }


        private bool AssignInitializeWeatherData()
        {
            try
            {
                if (CitiesComboBox.SelectedItem.GetType().Equals((new ComboBoxItem()).GetType()))
                {
                    _city = ((ComboBoxItem)CitiesComboBox.SelectedItem).Content.ToString();
                }
                else
                {
                    _city = CitiesComboBox.SelectedItem.ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Message returned by application: {ex.Message} \n Probably city name is invalid. \n Selected item is {CitiesComboBox.SelectedItem.GetType()}");
                return false;
            }

            if (OpenWeatherServiceRadio.IsChecked == true)
            {
                _baseURL = @"http://api.openweathermap.org/data/2.5/weather";
                _urlBuilder = new OpenWeatherAPIURLBuilder(_baseURL, _apiKey);
                _weatherDownloader = new OpenWeatherDownloader(_urlBuilder);
                _weatherData = new OpenWeatherObject();
                _DataBinder = new OpenWeatherDataBinder<OpenWeatherObject>();
                _weatherDownloader.DownloadDataByCity(_city);
            }

            if (CitiesComboBox.SelectedItem == null || CitiesComboBox.SelectedItem.ToString().Length == 0)
            {
                MessageBox.Show("You have not selected city!");
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

        private void WeatherCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            BasicWeatherGroupBox.Visibility = Visibility.Visible;
        }

        private void WeatherCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            BasicWeatherGroupBox.Visibility = Visibility.Hidden;
        }

        private void AdvancedCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            AdvancedWeatherGroupBox.Visibility = Visibility.Visible;
        }

        private void AdvancedCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            AdvancedWeatherGroupBox.Visibility = Visibility.Hidden;
        }

        /*TEST
        private void ShowWeatherButton_Click(object sender, RoutedEventArgs e)
        {
            OpenWeatherAPIURLBuilder urlBuilder = new OpenWeatherAPIURLBuilder("http://api.openweathermap.org/data/2.5/weather", "f7e2509b51e34ef70bc66b0a816fbb11");
            OpenWeatherDownloader openWeatherDownloader = new OpenWeatherDownloader(urlBuilder);
            openWeatherDownloader.DownloadDataByCity("Siemiatycze");
            OpenWeatherObject rootWeatherobject = new OpenWeatherObject();
            OpenWeatherDataBinder openWeatherDataBinder = new OpenWeatherDataBinder();
            rootWeatherobject = (OpenWeatherObject) openWeatherDataBinder.DeserializeJSON<OpenWeatherObject>(openWeatherDownloader.PushURL());


            TemperatureBox.Text = rootWeatherobject.Main.Temp.ToString("0.0000");
        }
        */
    }
}
