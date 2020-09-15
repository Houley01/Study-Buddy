using StudyBuddy.Models.Notes;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Study_Buddy.ViewModels
{
    public class NoteViewModel : BaseViewModel
    {
        protected Note _Note;
        public Note NoteObject { get => _Note; set => SetProperty(ref _Note, value); }

        public NoteViewModel()
        {
            Title = "View Note";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamain-quickstart"));
            this._Note = new Note();
        }

        public ICommand OpenWebCommand { get; }
    }
}