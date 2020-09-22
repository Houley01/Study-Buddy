using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddy.Models
{
    class Tasks
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string TaskGroup { get; set; }
        public string BackgroundColor { get; set; }
        public string TextColor { get; set; }
        public bool Complete { get; set; }

    }
}
