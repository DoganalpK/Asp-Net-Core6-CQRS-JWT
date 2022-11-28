namespace AspNetCore6.Back.Core.Domain
{
    public class AppUser : BaseEntity
    {
        public AppUser()
        {
            AppRole = new AppRole();
        }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int AppRoleId { get; set; }
        public AppRole AppRole { get; set; }
    }
}
