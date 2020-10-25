using System;

namespace StudyBuddy.Models.Notes
{
    public class Note 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public string[] Tags { get; set; }
        public string Visibility { get; set; }
    }
}
