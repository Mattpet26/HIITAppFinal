using HIITAppFinal.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HIITAppFinal.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string text;
        private int set;
        private int timer;
        private int rest;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(text);
        }

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

        public int Timer
        {
            get => timer;
            set => SetProperty(ref timer, value);
        }

        public int Rest
        {
            get => rest;
            set => SetProperty(ref rest, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Text = Text,
                Set = Set,
                Timer = Timer,
                Rest = Rest
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
    
}
