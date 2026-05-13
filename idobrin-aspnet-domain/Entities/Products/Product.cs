namespace aspnet_domain.Entities.Products;

public class Product : Base
{
    public string Name { get; set; } = "";
    public float Price { get; set; }
    public int AmountInStock { get; set; }
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; } = new();
}