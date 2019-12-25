using System.Collections.Generic;

namespace data.Entities
{
    public class Hobby : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<ApplicationUserHobbies> ApplicationUserHobbies { get; set; }
    }
}