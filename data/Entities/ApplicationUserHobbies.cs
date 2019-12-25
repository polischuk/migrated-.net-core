using System;

namespace data.Entities
{
    public  class ApplicationUserHobbies
    {
        public string ApplicationUserId { get; set; }
        public Guid HobbyId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Hobby Hobby { get; set; }
    }
}
