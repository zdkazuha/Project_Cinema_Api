using Microsoft.AspNetCore.Identity;

namespace DataAccess.Data.Entities
{
    public class User : IdentityUser
    {
        public string? Country { get; set; }

        // navigation property

        public ICollection<Review>? Reviews { get; set; }

    }
}
