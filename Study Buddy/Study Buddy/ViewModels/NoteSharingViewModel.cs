using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Collections.Generic;

namespace Study_Buddy.ViewModels
{
    public class NoteSharingViewModel : BaseViewModel
    {
        public NoteSharingViewModel()
        {
            Title = "Note Sharing";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamain-quickstart"));
        }

        public ICommand OpenWebCommand { get; }

    }
}