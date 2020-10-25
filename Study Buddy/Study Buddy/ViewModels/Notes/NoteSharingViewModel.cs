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
        private StudyBuddy.Models.Notes.Note selectedNote;
        public ICommand SaveSection { get; private set; }
        public ICommand AddNewNotePage { get; private set; }
        public ICommand NoteTapped { get; private set; }

        public NoteSharingViewModel() : base()
        {
            Title = "Note Sharing";
            // PLACEHOLDER SUBJECTS 
            SaveSection = new Command(async () => await NewSection());
            AddNewNotePage = new Command(NewNotePage);
            NoteTapped = new Command(async (x) => await NavToNote((Note)x));
            subjects = NoteStore.GetSubjects().Result.ToList<Subject>();
            this.currentNotes = new ObservableCollection<Note>();
            this.currentSections = new ObservableCollection<Section>();
        }

        private async Task NavToNote(Note TappedNote)
        {
            await Shell.Current.GoToAsync($"{nameof(NoteDetailPage)}?NoteId={TappedNote.Id}&SectionId={SelectedSection.Id}&SubjectId={SelectedSubject.Id}");
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
                updateCurrentSections();
                this.SelectedSection = this.SelectedSubject.Sections.Where(x => x.Name == newSectionName).FirstOrDefault();
                this.NewSectionName = string.Empty;
            }
            catch
            {
                return;
            }
        }

        public Note SelectedNote
        {
            get { return selectedNote; }
            set
            {
                SetProperty(ref selectedNote, value);
                this.NavToNote(value);
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
            CurrentSections.Clear();
            foreach(Section sec in subjectSections)
            {
                CurrentSections.Add(sec);
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
