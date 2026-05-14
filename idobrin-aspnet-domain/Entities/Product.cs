namespace aspnet_domain.Entities;

public class Product : Base
{
    public string Name { get; set; }
    public float Price { get; set; }
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
}