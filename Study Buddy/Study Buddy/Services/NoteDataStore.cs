using LoremNET;
using Newtonsoft.Json;
using StudyBuddy.Models.Notes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
            //Populate_Subjects_Sections_Notes();
            ReadStore();
        }

        public async Task<IEnumerable<Subject>> GetSubjects()
        {
            return await Task.FromResult(this.Subjects);
        }

        public async Task<IEnumerable<Note>> GetNotes(int SubjectId, int SectionId)
        {
            return await Task.FromResult(this.Subjects.Where(x => x.Id == SubjectId).FirstOrDefault()?.Sections.Where(x => x.Id == SectionId).FirstOrDefault().Notes);
        }

        public async Task<bool> AddNote(int SubjectId, int SectionId, Note NewNote)
        {
            this.Subjects.Where(x => x.Id == SubjectId).FirstOrDefault().Sections.Where(x => x.Id == SectionId).FirstOrDefault().Notes.Add(NewNote);
            return await Task.FromResult(true);
        }

        public void addSection(string name, Subject subject)
        {
            subject.Sections.Add(new Section() { Name = name });
        }

        private void ReadFromLocal(string path)
        {
            if (!System.IO.File.Exists(path)) throw new FileNotFoundException();

            string contents = System.IO.File.ReadAllText(path);

            object[] x = (object[])JsonConvert.DeserializeObject(contents);
            Subject[] subjects = (Subject[])x[0];

            foreach (var item in subjects)
            {
                this.Subjects.Add(item);
            }


        }
        private void DumpFromBinary(string pathTo)
        {
            const string RESID = "StudyBuddy.NoteStore.json";

            var assembly = Assembly.GetExecutingAssembly();

            using (Stream stream = assembly.GetManifestResourceStream(RESID))
            using (StreamReader reader = new StreamReader(stream))
            {
                string jsonFile = reader.ReadToEnd();
                File.WriteAllText(pathTo, jsonFile);
            }
        }

        private void ReadStore()
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

        private void Populate_Subjects_Sections_Notes()
        {
            const string FILENAME = "NoteStore.json";

            string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),FILENAME);

            if (!System.IO.File.Exists(path))
            {
                DumpFromBinary(path);
            }

            ReadFromLocal(path);


        }
    }
}
