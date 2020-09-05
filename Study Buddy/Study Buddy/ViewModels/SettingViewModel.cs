using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Study_Buddy.ViewModels
{
    public class SettingViewModel : BaseViewModel
    {
        public SettingViewModel()
        {
            Title = "Setting";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamain-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}