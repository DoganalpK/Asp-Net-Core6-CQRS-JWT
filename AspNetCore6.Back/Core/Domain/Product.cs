namespace AspNetCore6.Back.Core.Domain
{
    public class Product : BaseEntity
    {
        public Product()
        {
            Category = new Category();
        }
        public string? Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
