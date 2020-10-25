using System;
using System.Collections.Generic;

namespace StudyBuddy.Models.Notes
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public List<Section> Sections { get; set; }

        public Subject()
        {
            Sections = new List<Section>();
        }
    }
}
