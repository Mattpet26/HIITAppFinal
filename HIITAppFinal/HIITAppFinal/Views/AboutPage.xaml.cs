using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HIITAppFinal.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }
        int count = 0;
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            count++;
            ((Button)sender).Text = $"You clicked {count} times.";
        }
        void Login_Button_Clicked(object sender, System.EventArgs e)
        {
            Application.Current.Properties["UserName"] = UserName.Text;
            Application.Current.Properties["Password"] = Password.Text;
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
    }
}