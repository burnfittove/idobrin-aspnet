namespace aspnet_domain.Entities.Products;

public class Subcategory : Base
{
    public string Name { get; set; } = "";
    public int CategoryId { get; set; } = 0;
    public Category Category { get; set; } = new();
}