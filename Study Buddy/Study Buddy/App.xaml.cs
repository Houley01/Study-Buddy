using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Study_Buddy.Services;
using Study_Buddy.Views;
using StudyBuddy.Services;
using StudyBuddy.Models.Notes;
using System.Security.Cryptography;
using LoremNET;

namespace Study_Buddy
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            AddDSEntities();

            MainPage = new AppShell();
        }

        private void AddDSEntities()
        {
            //Notes
            DependencyService.Register<NoteDataStore>();

            //Calendar
            //DependencyService.Register<CalDataStore>();

            //Tasks
            //DependencyService.Register<TaskDataStore>();

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
