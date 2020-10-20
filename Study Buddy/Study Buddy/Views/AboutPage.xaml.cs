using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Study_Buddy.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private async void GoToNotes(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//NoteSharingPage");
        }

        private async void GoToTasks(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//TaskPage");
        }
    }
}