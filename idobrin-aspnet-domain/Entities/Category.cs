namespace aspnet_domain.Entities;

public class Category : Base
{
    public string Name { get; set; }
    public int? SupercategoryId { get; set; }
    public Category? Supercategory { get; set; }
    public virtual IEnumerable<Category?> Categories { get; set; } = new List<Category?>();
    public virtual IEnumerable<Product?> Products { get; set; } = new List<Product?>();
}