namespace StudyBuddy.Models.Users
{
    public class StudentUser : User
    {
        public StudentUser() : base() { this.IsAdmin = false; }
    }
}
