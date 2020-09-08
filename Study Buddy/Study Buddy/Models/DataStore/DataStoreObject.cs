using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyBuddy.Models.DataStore
{
    public class DataStoreObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Timestamp]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Created { get; set; }

        [Timestamp]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Modified { get; set; }

        public DataStoreObject() { this.Created = DateTime.Now; }
        protected DataStoreObject(Guid ExistingId) { this.Id = ExistingId; }
        protected DataStoreObject(Guid ExistingId, DateTime TimeCreated) { this.Id = ExistingId; this.Created = TimeCreated; }

    }
}
