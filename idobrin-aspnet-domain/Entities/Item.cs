using aspnet_domain.Entities.Products;

namespace aspnet_domain.Entities;

public class Item : Base
{
    public int Amount { get; set; }
    public float TotalPrice { get; set; }
    public int ProductId { get; set; }
    public virtual Product Product { get; set; } =  new();
}