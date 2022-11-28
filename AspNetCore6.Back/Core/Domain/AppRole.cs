namespace AspNetCore6.Back.Core.Domain
{
    public class AppRole : BaseEntity
    {
        public AppRole()
        {
            AppUsers = new List<AppUser>();
        }
        public string? Definition { get; set; }
        public List<AppUser> AppUsers { get; set; }
    }
}
