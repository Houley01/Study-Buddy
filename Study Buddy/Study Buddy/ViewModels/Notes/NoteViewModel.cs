using Microsoft.EntityFrameworkCore.Internal;
using StudyBuddy.Models.Notes;
using System;
using System.Linq;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Study_Buddy.ViewModels
{
    [QueryProperty("NoteId", "_NoteId")]
    [QueryProperty("SectionId", "_SectionId")]
    [QueryProperty("SubjectId", "_SubjectId")]
    public class NoteViewModel : BaseViewModel
    {
        private Guid _NoteId { get; set; }
        private Guid _SectionId { get; set; }
        private Guid _SubjectId { get; set; }

        private Note SelectedNote { get; }

        public string NoteTitle { get => SelectedNote.Title; }
        public string NoteContent { get => SelectedNote.Content; }
        public string NoteTags { get => string.Join(',', SelectedNote.Tags); }

        public NoteViewModel()
        {
            Title = "Note";
            this.SelectedNote = this.NoteStore.GetNotes(this._SubjectId, this._SectionId).Result.Where(x => x.Id == this._NoteId).FirstOrDefault();
        }

        public ICommand OpenWebCommand { get; }
    }
}