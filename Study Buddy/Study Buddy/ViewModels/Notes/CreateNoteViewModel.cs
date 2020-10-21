using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Study_Buddy.ViewModels;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;
using StudyBuddy.Models.Notes;
using StudyBuddy.Services;
using Study_Buddy.Services;
using System.Runtime.CompilerServices;
using Study_Buddy;

namespace StudyBuddy.ViewModels
{
    [QueryProperty("SubjectId", "_NoteSubjectId")]
    [QueryProperty("SectionId", "_NoteSectionId")]
    public class CreateNoteViewModel : BaseViewModel
    {
        private Guid _NoteSubjectId {get; set;}
        private Guid _NoteSectionId { get; set; }

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
            set => SetProperty(ref tags, value.Split(',', StringSplitOptions.None));
        }
        public string[] TagArray { get => tags; }

        private string visibility;
        public string NoteVisibility
        {
            get => visibility;
            set => SetProperty(ref visibility, value);
        }

        public ICommand SaveCommand { get; private set; }

        public CreateNoteViewModel() : base()
        {
            title = string.Empty;
            text = string.Empty;
            tags = new string[] { };
            NoteVisibility = "Everyone";
            SaveCommand = new Command(async () => await SaveNote());
        }

        private async Task SaveNote()
        {
            Note n = new Note()
            {
                Id = Guid.NewGuid(),
                Title = this.NoteTitle,
                Content = this.NoteContent,
                Tags = this.tags.Where(x=> x.Length > 0).ToArray(),
                Visibility = this.NoteVisibility
            };

            var subject = (await NoteStore.GetSubjects()).Where(x => x.Id == this._NoteSubjectId).FirstOrDefault();

            n.SubjectName = subject.Name;
            n.SectionName = subject.Sections.Where(x => x.Id == this._NoteSectionId).FirstOrDefault().Name;


            await NoteStore.AddNote(this._NoteSubjectId, this._NoteSectionId, n);
        }
    }
}