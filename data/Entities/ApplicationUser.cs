using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public PasswordHashVersion HashVersion { get; set; }
        public ICollection<ApplicationUserHobbies> ApplicationUserHobbies { get; set; }
    }
}
