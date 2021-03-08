using HIITAppFinal.Models;
using HIITAppFinal.ViewModels;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HIITAppFinal.Views
{
    public partial class AboutPage : ContentPage
    {
        readonly AboutViewModel _vm;
        public AboutPage()
        {
            InitializeComponent();
            BindingContext = _vm = new AboutViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if(_vm.GetStarCount() > 0)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    StarCounter.SetValue(IsVisibleProperty, true);
                });
            }
            _vm.ToggleAccelerometer();
        }

        int count = 0;
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            count++;
            ((Button)sender).Text = $"You clicked {count} times.";

            if (count == 5)
            {
                DisplayAlert("Hidden Feature!!!", "You earned the clicky button star!!", "Ok");
                _vm.AddStarCount();

                Device.BeginInvokeOnMainThread(() =>
                {
                    Clicky.SetValue(IsVisibleProperty, false);
                });
            }
        }

        void Login_Button_Clicked(object sender, System.EventArgs e)
        {
            if (UserName.Text.ToLower() == "username")
            {
                DisplayAlert("Failure", "Very funny, select a username. It can be anything.", "Ok");
                UserName.Text = string.Empty;
                Password.Text = string.Empty;
            } else if (UserName.Text.ToLower() == "anything")
            {
                DisplayAlert("Really..?", "I'm getting sick of you.", "Sorry");
                UserName.Text = string.Empty;
                Password.Text = string.Empty;
            }
            else
            {
                Application.Current.Properties["UserName"] = UserName.Text;
                Application.Current.Properties["Password"] = Password.Text;

                User user = new User
                {
                    Username = UserName.Text,
                    Password = Password.Text
                };

                UserName.Text = string.Empty;
                Password.Text = string.Empty;
                DisplayAlert("Success", "Your information has been recorded!", "Ok");

                Device.BeginInvokeOnMainThread(() =>
                {
                    LoginSection.SetValue(IsVisibleProperty, false);
                    LogoutButton.SetValue(IsVisibleProperty, true);
                    Clicky.SetValue(IsVisibleProperty, true);
                });
                if (Application.Current.Properties.ContainsKey("UserName"))
                {
                    ViewUserName.Text = Application.Current.Properties["UserName"].ToString();
                    ViewPassword.Text = Application.Current.Properties["Password"].ToString();
                }
            }
        }

        void Logout_Clicked(object sender, System.EventArgs e)
        {
            if (Application.Current.Properties.ContainsKey("UserName"))
            {
                Application.Current.Properties.Remove("UserName");
                Application.Current.Properties.Remove("Password");
                ViewUserName.Text = "";
                ViewPassword.Text = "";
            }
            Device.BeginInvokeOnMainThread(() =>
            {
                LoginSection.SetValue(IsVisibleProperty, true);
                LogoutButton.SetValue(IsVisibleProperty, false);
                Clicky.SetValue(IsVisibleProperty, false);
            });
            DisplayAlert("Success", "You have been logged out", "Ok");
        }

        void Accelerate_Button(object sender, System.EventArgs e)
        {
            DisplayAlert("Hidden feature!!!", "You have unlocked the accelerate star!", "Ok");
            _vm.AddStarCount();

            Device.BeginInvokeOnMainThread(() =>
            {
                Accelerate.SetValue(IsVisibleProperty, false);
            });
        }
        void Hidden_Button(object sender, System.EventArgs e)
        {
            DisplayAlert("Hidden feature!!!", "You have unlocked the hidden star!", "Ok");
            _vm.AddStarCount();
        }
    }
}