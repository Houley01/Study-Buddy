using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Collections.Generic;
using StudyBuddy.Models.Notes;
using System.Linq;
using System.Collections.ObjectModel;

namespace Study_Buddy.ViewModels
{
    public class NoteSharingViewModel : BaseViewModel
    {
        private StudyBuddy.Models.Notes.Subject[] subjects;
        private ObservableCollection<StudyBuddy.Models.Notes.Note> currentNotes;
        private List<StudyBuddy.Models.Notes.Note> allNotes;

        public NoteSharingViewModel() : base()
        {
            Title = "Note Sharing";
            // PLACEHOLDER SUBJECTS 
            StudyBuddy.Models.Notes.Subject sub_iab330 = new StudyBuddy.Models.Notes.Subject
            {
                Id = Guid.NewGuid(),
                Name = "Mobile Application Development",
                Code = "IAB330",
                Sections = new List<StudyBuddy.Models.Notes.Section>()
            };
            StudyBuddy.Models.Notes.Subject sub_cab303 = new StudyBuddy.Models.Notes.Subject
            {
                Id = Guid.NewGuid(),
                Name = "Networks",
                Code = "CAB303",
                Sections = new List<StudyBuddy.Models.Notes.Section>()
            };
            // PLACEHOLDER NOTES
            StudyBuddy.Models.Notes.Note note_iab330 = new StudyBuddy.Models.Notes.Note
            {
                Id = Guid.NewGuid(),
                Title = "Week 4 Lecture",
                Author = "John Smith",
                Content = "fjkdlsjfkldjsfklsdjklfjsdklfjsd",
                Tags = new string[5],
                Visibility = "",
                SectionName = "",
                SubjectName = "IAB330"

            };

            StudyBuddy.Models.Notes.Note note_cab303 = new StudyBuddy.Models.Notes.Note
            {
                Id = Guid.NewGuid(),
                Title = "Week 4 Lecture",
                Author = "John Smith",
                Content = "poponlfndslkfjsdklfjdkfjiewp",
                Tags = new string[5],
                Visibility = "",
                SectionName = "",
                SubjectName = "CAB330"
            };
            subjects = new StudyBuddy.Models.Notes.Subject[] { sub_iab330, sub_cab303 };
            this.allNotes = new List<Note>();
            allNotes.Add(note_iab330);
            allNotes.Add(note_cab303);
        }

        public StudyBuddy.Models.Notes.Subject[] SubjectList
        {
            get => subjects;
        }

        // Gets the list of subjects (currently from placeholder mock data)
        private StudyBuddy.Models.Notes.Subject selectedSubject;
        public StudyBuddy.Models.Notes.Subject SelectedSubject
        {
            get { return selectedSubject; }
            set
            {
                if (selectedSubject != value)
                {
                    if(selectedSubject.Code != value.Code)
                    {
                        GetNotesForSubjectCode(value.Code);
                    }
                    SetProperty(ref selectedSubject, value);
                }
            }
        }

        private void GetNotesForSubjectCode(string code)
        {
            this.currentNotes.Clear();
            foreach (Note x in this.allNotes.Where(x => x.SubjectName == code))
            {​​​​
                this.currentNotes.Add(x);
            }​​​​
        }

        public ObservableCollection<StudyBuddy.Models.Notes.Note> CurrentNotes
        {
            get
            {
                return currentNotes;
            }
            set
            {
                if (currentNotes != value)
                {
                    SetProperty(ref currentNotes, value);
                }
            }
        }

        public ICommand OpenWebCommand { get; }

    }
}
