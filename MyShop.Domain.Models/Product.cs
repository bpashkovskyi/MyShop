namespace MyShop.Domain.Models;

public class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public Category Category { get; set; }

    public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
}