using System;
using System.Collections.Generic;
using StudyBuddy.Models.Users;

namespace StudyBuddy.Models.Notes
{
    public class Note : Models.DataStore.DataStoreObject
    {
        public Note() : base() { }

        public Guid AuthorId { get; set; }
        public User Author { get; set; }
        public string Title { get; set; }
        public string[] Tags { get; set; }
        public string Content { get; set; }
        public NoteVisibility Visibility { get; set; } = NoteVisibility.Everyone; //Defaults to evreyone
        public List<Guid> VisibleToUsers { get; set; } //May be null if Visibility is set to anything other than SpecificPeople

        public enum NoteVisibility
        {
            Private,
            Everyone,
            SpecificPeoplle
        }
    }
}
