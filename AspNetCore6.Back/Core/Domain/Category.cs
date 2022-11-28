namespace AspNetCore6.Back.Core.Domain
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Products = new List<Product>();
        }
        public string? Definition { get; set; }
        public List<Product> Products { get; set; }
    }
}
