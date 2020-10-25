using LoremNET;
using StudyBuddy.Models.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace StudyBuddy.Services
{
    public class NoteDataStore
    {
        readonly List<Subject> Subjects;

        public NoteDataStore()
        {
            this.Subjects = new List<Subject>();
            Populate_Subjects_Sections_Notes();
        }

        public async Task<IEnumerable<Subject>> GetSubjects()
        {
            return await Task.FromResult(this.Subjects);
        }

        public async Task<IEnumerable<Note>> GetNotes(Guid SubjectId, Guid SectionId)
        {
            return await Task.FromResult(this.Subjects.Where(x => x.Id == SubjectId).FirstOrDefault()?.Sections.Where(x => x.Id == SectionId).FirstOrDefault().Notes);
        }

        public async Task<bool> AddNote(Guid SubjectId, Guid SectionId, Note NewNote)
        {
            this.Subjects.Where(x => x.Id == SubjectId).FirstOrDefault().Sections.Where(x => x.Id == SectionId).FirstOrDefault().Notes.Add(NewNote);
            return await Task.FromResult(true);
        }

        public void addSection(string name, Subject subject)
        {
            subject.Sections.Add(new Section() { Name = name });
        }


        private void Populate_Subjects_Sections_Notes()
        {
            Section GenerateRandomSection()
            {
                return new Section() { Name = Lorem.Words(1, 3) };
            }
            Note GenerateRandomNote(string SubjectName, string SectionName, int i)
            {
                return new Note() { Author = $"Author {i}", Title = Lorem.Sentence(5, 10), Content = Lorem.Paragraph(5, 10, 3, 6), Tags = Lorem.Words(1, 5).Split(' '), SubjectName = SubjectName, SectionName = SectionName };
            }

            //populate subjects
            Subject sMobile = new Subject() { Code = "IAB330", Name = "Mobile Application Development" };
            Subject sNetworks = new Subject() { Code = "CAB303", Name = "Networks" };
            Subject sSoftDev = new Subject() { Code = "CAB302", Name = "Software Development" };

            //populate subject sections
            for (int i = 0; i < RandomNumberGenerator.GetInt32(5); i++)
            {
                sMobile.Sections.Add(GenerateRandomSection());
                sNetworks.Sections.Add(GenerateRandomSection());
                sSoftDev.Sections.Add(GenerateRandomSection());
            }

            //populate section ontes
            for (int i = 0; i < RandomNumberGenerator.GetInt32(15); i++)
            {
                foreach (Section section in sMobile.Sections)
                {
                    section.Notes.Add(GenerateRandomNote(sMobile.Name, section.Name, i));
                }
                foreach (Section section in sNetworks.Sections)
                {
                    section.Notes.Add(GenerateRandomNote(sNetworks.Name, section.Name, i));
                }
                foreach (Section section in sSoftDev.Sections)
                {
                    section.Notes.Add(GenerateRandomNote(sSoftDev.Name, section.Name, i));
                }
            }

            this.Subjects.Add(sMobile);
            this.Subjects.Add(sNetworks);
            this.Subjects.Add(sSoftDev);
        }
    }
}
