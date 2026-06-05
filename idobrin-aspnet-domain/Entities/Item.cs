namespace aspnet_domain.Entities;

public class Item : Base
{
    public int Quantity { get; set; }
    public float TotalPrice { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; } = new();
    public virtual ICollection<Cart>? Carts { get; set; }
}