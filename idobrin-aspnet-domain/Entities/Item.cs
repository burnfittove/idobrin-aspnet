namespace aspnet_domain.Entities;

public class Item : Base
{
    public int Quantity { get; set; }
    public float TotalPrice { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public virtual ICollection<CartItem>? CartItems { get; set; }
}