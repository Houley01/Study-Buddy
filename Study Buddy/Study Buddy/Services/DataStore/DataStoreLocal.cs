using Microsoft.EntityFrameworkCore;
using System.IO;
using Xamarin.Essentials;

namespace StudyBuddy.Services.DataStore
{
    public class DataStoreLocal : DataStoreContext
    {
        public DataStoreLocal() : base()
        {
            SQLitePCL.Batteries_V2.Init();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "StudyBuddy.db3");

            optionsBuilder
                .UseSqlite($"Filename={dbPath}");
        }
    }
}
