using System;
using System.ComponentModel.DataAnnotations;

namespace data.Entities
{
    public abstract class BaseEntity
    {
        private DateTime _addedDate;
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public DateTime AddedDate
        {
            get { return DateTime.SpecifyKind(_addedDate, DateTimeKind.Utc); }
            private set { _addedDate = value; }
        }
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            AddedDate = DateTime.UtcNow;
        }
    }
}
