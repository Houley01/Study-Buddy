using System;

namespace StudyBuddy.Models.Notes
{
    public class Note 
    {
        public Guid Id { get; set; } = new Guid();
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public string[] Tags { get; set; }
        public string Visibility { get; set; }
        public string SubjectName { get; set; }
        public string SectionName { get; set; }
    }
}
