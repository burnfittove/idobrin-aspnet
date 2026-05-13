namespace aspnet_domain.Entities.Products;

public class Category : Base
{
    public string Name { get; set; } = "";
    public int? SupercategoryId { get; set; }
    public virtual Category? Supercategory { get; set; }
    public virtual IEnumerable<Category> Subcategories { get; set; } = new List<Category>();
}