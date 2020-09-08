using StudyBuddy.Models.DataStore;
using StudyBuddy.Models.Users;
using System.Collections.Generic;

namespace StudyBuddy.Models.Notes
{
    public class Subject : DataStoreObject
    {
        public string Title { get; set; }
        public string InstitutionId { get; set; }

        public List<StudentUser> EnrolledStudents { get; set; }
        public List<StaffUser> Admins { get; set; }
        public List<Note> SubjectNotes { get; set; }
    }
}
