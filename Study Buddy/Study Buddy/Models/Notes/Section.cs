using System;
using System.Collections.Generic;

namespace StudyBuddy.Models.Notes
{
    public class Section
    {
        public Guid Id { get; set; } = new Guid();
        public string Name { get; set; }
        public List<Note> Notes { get; set; }
    }
}
