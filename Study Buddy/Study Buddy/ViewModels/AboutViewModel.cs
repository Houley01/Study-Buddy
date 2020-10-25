using Study_Buddy.Views;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Study_Buddy.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public Command GoToNotes { get; }
        public Command GoToTasks { get; }
        public AboutViewModel()
        {
            Title = "About";
            HeadingText = "Welcome to Studdy Buddy!";
            NotesButtonText = "Notes";
            TasksButtonText = "Tasks";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamain-quickstart"));
            GoToNotes = new Command(GoToNotePage);
            GoToTasks = new Command(GoToTasksPage);
        }

        public ICommand OpenWebCommand { get; }

        private async void GoToNotePage(object obj)
        {
            await Shell.Current.GoToAsync("NoteSharingPage");
        }

        private async void GoToTasksPage(object obj)
        {
            await Shell.Current.GoToAsync("//TaskPage");
        }
    }
}