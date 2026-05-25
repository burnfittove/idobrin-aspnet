namespace aspnet_domain.Entities;

public sealed class Product : Base
{
    public string Name { get; set; }
    public float Price { get; set; }
    public ICollection<CategoryProducts> CategoryProducts { get; set; }
    public IEnumerable<Item?> Items { get; set; }
}