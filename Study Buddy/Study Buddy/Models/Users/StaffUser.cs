namespace StudyBuddy.Models.Users
{
    public class StaffUser : User
    {
        public StaffUser() : base() { this.IsAdmin = true; }
    }
}
