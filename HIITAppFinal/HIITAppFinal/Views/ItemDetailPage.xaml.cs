using HIITAppFinal.ViewModels;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HIITAppFinal.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        Stopwatch stopwatch;
        readonly ItemDetailViewModel _vm;

        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = _vm = new ItemDetailViewModel();

            stopwatch = new Stopwatch();
            lblStopwatch.Text = "00:00:00";
        }

        private void Start_Clicked(object sender, System.EventArgs e)
        {
            if (!stopwatch.IsRunning)
            {
                stopwatch.Start();
                Device.StartTimer(TimeSpan.FromMilliseconds(10), () =>
                {
                    lblStopwatch.Text = stopwatch.Elapsed.ToString();
                    if (!stopwatch.IsRunning)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                });
            }
        }

        private void Stop_Clicked(object sender, System.EventArgs e)
        {
            Start.Text = "Resume";
            stopwatch.Stop();
        }

        private void Reset_Clicked(object sender, System.EventArgs e)
        {
            lblStopwatch.Text = "00:00:00";
            Start.Text = "Start";
            stopwatch.Reset();
        }

        private async Task SetTime_Clicked(object sender, System.EventArgs e)
        {
            if (!stopwatch.IsRunning)
            {
                stopwatch.Start();
                Device.StartTimer(TimeSpan.FromMilliseconds(10), () =>
                {
                    lblStopwatch.Text = stopwatch.Elapsed.ToString();
                    if (!stopwatch.IsRunning)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                });
            }

            while (stopwatch.Elapsed.Seconds < _vm.Timer)
            {
                stopwatch.Stop();
                stopwatch.Reset();
            }

        }
    }
}