using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddy.Models.Users
{
    public class User : Models.DataStore.DataStoreObject
    {
        public User() : base() { }
        public string Name { get; set; }
        public string InstitutionId { get; set; } //eg: n9656588
        public bool IsAdmin { get; set; } = false; //Defaults to false

        public List<Models.Notes.Note> Notes { get; set; }

        

    }
}
