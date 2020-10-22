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
        private Subject[] subjects;
        private Section[] sections;
        private ObservableCollection<StudyBuddy.Models.Notes.Note> currentNotes;
        private List<StudyBuddy.Models.Notes.Note> allNotes;
        private StudyBuddy.Models.Notes.Subject selectedSubject;
        private StudyBuddy.Models.Notes.Section selectedSection;



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
            // generate cab303 placeholder sections
            StudyBuddy.Models.Notes.Section cab303_week1 = new StudyBuddy.Models.Notes.Section
            {
                Id = Guid.NewGuid(),
                Name = "CAB303 Week 1",
                Notes = new List<Note>()
            };
            sub_cab303.Sections.Add(cab303_week1);

            // PLACEHOLDER NOTES
            StudyBuddy.Models.Notes.Note note_iab330 = new StudyBuddy.Models.Notes.Note
            {
                Id = Guid.NewGuid(),
                Title = "Week 4 Lecture",
                Author = "John Smith",
                Content = "fjkdlsjfkldjsfklsdjklfjsdklfjsd",
                Tags = new string[5],
                Visibility = "",
                SectionName = "IAB330 Week 1",
                SubjectName = "IAB330"

            };

            // generate sections for iab330
            StudyBuddy.Models.Notes.Section iab330_week1 = new StudyBuddy.Models.Notes.Section
            {
                Id = Guid.NewGuid(),
                Name = "IAB330 Week 1",
                Notes = new List<Note>()
            };
            sub_iab330.Sections.Add(iab330_week1);

            StudyBuddy.Models.Notes.Note note_cab303 = new StudyBuddy.Models.Notes.Note
            {
                Id = Guid.NewGuid(),
                Title = "Week 4 Lecture",
                Author = "John Smith",
                Content = "pwoerpewjfdskl",
                Tags = new string[5],
                Visibility = "",
                SectionName = "CAB303 Week 1",
                SubjectName = "CAB303"
            };

            subjects = new Subject[] { sub_iab330, sub_cab303 };
            sections = new Section[] { cab303_week1, iab330_week1 };

            cab303_week1.Notes.Add(note_cab303);
            iab330_week1.Notes.Add(note_iab330);

            this.allNotes = new List<Note>();
            allNotes.Add(note_iab330);
            allNotes.Add(note_cab303);
            this.currentNotes = new ObservableCollection<Note>();
            this.currentSections = new ObservableCollection<Section>();
        }

        public Subject[] SubjectList
        {
            get => subjects;
        }

        private string newSection;

        public string NewSection
        {
            get { return newSection; }
            set
            {
                SetProperty(ref newSection, value);
            }
        }

        // Gets the list of subjects (currently from placeholder mock data)
        public Subject SelectedSubject
        {
            get { return selectedSubject; }
            set
            {
                if (selectedSubject == null || selectedSubject != value)
                {
                    SetProperty(ref selectedSubject, value);
                    currentSections.Clear();
                    updateCurrentSections();
                    if (selectedSubject == null || selectedSubject.Code != value.Code)
                    { 
                        GetNotesForSubjectCode(value.Code);
                    }
                }
            }
        }

        private void GetNotesForSubjectCode(string code)
        {
            currentNotes.Clear();
            foreach (Note x in allNotes.Where(x => x.SubjectName == code))
            {
                currentNotes.Add(x);
            }
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

        // Section stuff
        private ObservableCollection<StudyBuddy.Models.Notes.Section> currentSections;

        public ObservableCollection<StudyBuddy.Models.Notes.Section> CurrentSections
        {
            get
            {
                return currentSections;
            }
            set
            {
                if (currentSections != value || currentSections == null)
                {
                    SetProperty(ref currentSections, value);
                }
            }
        }

        private void GetNotesForSection()
        {
            currentNotes.Clear();
            
            foreach(Note note in selectedSection.Notes) 
            {
                currentNotes.Add(note);
            }
        }


        private void updateCurrentSections()
        {
            ObservableCollection<Section> subjectSections = new ObservableCollection<Section>(selectedSubject.Sections);
            currentSections.Clear();
            foreach(Section sec in subjectSections)
            {
                currentSections.Add(sec);
            }
        }

        public StudyBuddy.Models.Notes.Section SelectedSection
        {
            get { return selectedSection; }
            set
            {
                if (selectedSection == null || selectedSection != value)
                {
                    selectedSection = null;
                    SetProperty(ref selectedSection, value);
                    if(selectedSection != null)
                    {
                        currentNotes.Clear();
                        GetNotesForSection();
                    }
                }
            }
        }

        public ICommand OpenWebCommand { get; }

    }
}
