namespace aspnet_domain.Entities.Products;

public class Subcategory : Base
{
    public string Name { get; set; } = "";
    public int CategoryId { get; set; } = 0;
    public virtual Category Category { get; set; } = new();
    public virtual IEnumerable<Product> Products { get; set; } = new List<Product>();
}