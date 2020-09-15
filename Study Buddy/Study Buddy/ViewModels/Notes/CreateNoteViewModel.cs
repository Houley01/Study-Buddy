using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Study_Buddy.ViewModels;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;

namespace StudyBuddy.ViewModels
{
    public class CreateNoteViewModel : BaseViewModel
    {
        private string title;
        public string NoteTitle      
        {
            get => title;
            set => SetProperty(ref title, value);
        }
        private string text;
        public string NoteContent
        {
            get => text;
            set => SetProperty(ref text, value);
        }
        private string[] tags;
        public string NoteTags
        {
            get => string.Join(',', tags);
            set => SetProperty(ref tags, value.Split(','));
        }

        private string visibility;
        public string NoteVisibility
        {
            get => visibility;
            set => SetProperty(ref visibility, value);
        }

        public ICommand SaveCommand { get; private set; }
        public ICommand SelectPeopleCMD { get; private set; }

        public CreateNoteViewModel() : base()
        {
            title = string.Empty;
            text = string.Empty;
            tags = new string[] { };
            NoteVisibility = "Everyone";
            //SaveCommand = new Command(async () => await SaveNote());
        }

        private async Task SaveNote()
        {
            throw new NotImplementedException();
        }
    }
}