using Microsoft.AspNetCore.Identity;

namespace DataAccess.Data.Entities
{
    public class User : IdentityUser, BaseEntity
    {
        public string? Country { get; set; }

        // navigation property

        public ICollection<Review>? Reviews { get; set; }

        public ICollection<RefreshToken?> RefreshTokens { get; set; } = new List<RefreshToken>();

    }
}
