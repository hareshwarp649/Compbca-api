namespace bca.api.Data.Entities
{
    using bca.api.Enums;
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {
        public int? EntityId { get; set; }
        public UserType UserType { get; set; }
        public bool IsDeleted { get; set; }
        public int? BankId { get; set; }
        public virtual Bank? Bank { get; set; }

       public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
