using HIITAppFinal.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace HIITAppFinal.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}