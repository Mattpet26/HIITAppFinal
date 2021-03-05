using HIITAppFinal.Models;
using HIITAppFinal.Services;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HIITAppFinal.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public IDataStore<User> DataStore = DependencyService.Get <IDataStore<User>>();
        public AboutViewModel()
        {
            Title = "Home";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
        }
        public ICommand OpenWebCommand { get; }
        private string username;
        private string password;
        private int starcount;
        public int StarCount
        {
            get => starcount;
            set => SetProperty(ref starcount, value);
        }
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }
        public string Username
        {
            get => username;
            set => SetProperty(ref username, value);
        }
        public string user => $"{Username}";
        public string pass => $"{Password}";

        public async void SaveUser()
        {
            User newUser = new User()
            {
                Username = Username,
                Password = Password,
                HiddenStars = StarCount
            };

            await DataStore.AddItemAsync(newUser);
        }

        private float x;
        private float y;
        private float z;
        private bool trigger;

        public float X
        {
            get => x;
            set => SetProperty(ref x, value);
        }
        public float Y
        {
            get => y;
            set => SetProperty(ref y, value);
        }
        public float Z
        {
            get => z;
            set => SetProperty(ref z, value);
        }
        public bool Trigger
        {
            get => trigger;
            set => SetProperty(ref trigger, value);
        }

        // Set speed delay for monitoring changes.
        SensorSpeed speed = SensorSpeed.UI;

        void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            var data = e.Reading;
            X = data.Acceleration.X;
            Y = data.Acceleration.Y;
            if (Y > 1.3)
            {
                Trigger = true;
            }
            Z = data.Acceleration.Z;
            Console.WriteLine($"Reading: X: {data.Acceleration.X}, Y: {data.Acceleration.Y}, Z: {data.Acceleration.Z}");
            // Process Acceleration X, Y, and Z
        }

        public void ToggleAccelerometer()
        {
            try
            {
                if (Accelerometer.IsMonitoring)
                    Accelerometer.Stop();
                else
                    Accelerometer.Start(speed);
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature not supported on device
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }
        public int GetStarCount()
        {
            try
            {
                return StarCount;
            }
            catch
            {
                return 0;
            }
        }

        public void AddStarCount()
        {
            StarCount++;
        }
    }
}