using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Collections.Generic;
using StudyBuddy.Models.Notes;
using System.Linq;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using StudyBuddy.Views.Notes;

namespace Study_Buddy.ViewModels
{
    public class NoteSharingViewModel : BaseViewModel
    {
        private IEnumerable<Subject> subjects;
        private Section[] sections;
        private ObservableCollection<StudyBuddy.Models.Notes.Note> currentNotes;
        private List<StudyBuddy.Models.Notes.Note> allNotes;
        private StudyBuddy.Models.Notes.Subject selectedSubject;
        private StudyBuddy.Models.Notes.Section selectedSection;
        public ICommand SaveSection { get; private set; }
        public ICommand AddNewNotePage { get; private set; }


        public NoteSharingViewModel() : base()
        {
            Title = "Note Sharing";
            // PLACEHOLDER SUBJECTS 
            SaveSection = new Command(async () => await NewSection());
            AddNewNotePage = new Command(NewNotePage);
            subjects = NoteStore.GetSubjects().Result.ToList<Subject>();
            this.currentNotes = new ObservableCollection<Note>();
            this.currentSections = new ObservableCollection<Section>();
        }

        private async void NewNotePage(object obj)
        {
            await Shell.Current.GoToAsync(nameof(StudyBuddy.Views.Notes.CreateNotePage));
        }

        public IEnumerable<Subject> SubjectList
        {
            get => subjects;
        }


        private string newSectionName;
        public string NewSectionName
        {
            get 
            { 
                return newSectionName;
            }
            set
            {
                SetProperty(ref newSectionName, value);
            }

        }

        private async Task NewSection()
        {
            try
            {
                NoteStore.addSection(newSectionName, selectedSubject);
            }
            catch
            {
                return;
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
                    currentNotes.Clear();
                    currentSections.Clear();
                    updateCurrentSections();
                }
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
