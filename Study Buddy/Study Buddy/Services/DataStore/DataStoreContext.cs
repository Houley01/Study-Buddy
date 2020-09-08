using Microsoft.EntityFrameworkCore;
using StudyBuddy.Models.Notes;
using StudyBuddy.Models.Users;

namespace StudyBuddy.Services.DataStore
{
    public class DataStoreContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
        public DbSet<StudentUser> Students { get; set; }
        public DbSet<StaffUser> Staff { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        /*
         Add more DbSets here for each database table we need to work with 
        */

        public DataStoreContext()
        {
            this.Database.EnsureCreated();
        }
    }
}
