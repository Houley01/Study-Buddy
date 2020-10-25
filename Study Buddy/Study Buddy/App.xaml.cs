using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Study_Buddy.Services;
using Study_Buddy.Views;
using StudyBuddy.Services;

namespace Study_Buddy
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            DependencyService.Register<TaskDataStore>();
            DependencyService.Register<NoteDataStore>();
            Device.SetFlags(new string[] { "Expander_Experimental" });
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
