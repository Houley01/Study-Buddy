using System;
using System.Collections.Generic;
using Study_Buddy.ViewModels;
using Study_Buddy.Views;
using Xamarin.Forms;

namespace Study_Buddy
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(TaskPlanPage), typeof(TaskPlanPage));
            Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
           /* await Shell.Current.GoToAsync("//AboutPage");*/


        }
    }
}
