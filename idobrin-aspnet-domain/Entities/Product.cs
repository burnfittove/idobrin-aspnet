namespace aspnet_domain.Entities;

public class Product : Base
{
    public string Name { get; set; }
    public float Price { get; set; }
    public virtual ICollection<CategoryProducts> CategoryProducts { get; set; }
}