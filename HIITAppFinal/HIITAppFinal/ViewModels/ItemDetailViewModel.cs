using HIITAppFinal.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HIITAppFinal.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string text;
        private int set;
        private int rest;
        private int timer;

        public string Id { get; set; }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public int Set
        {
            get => set;
            set => SetProperty(ref set, value);
        }
        public int Rest
        {
            get => rest;
            set => SetProperty(ref rest, value);
        }
        public int Timer
        {
            get => timer;
            set => SetProperty(ref timer, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Text = item.Text;
                Set = item.Set;
                Timer = item.Timer;
                Rest = item.Rest;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
