namespace aspnet_domain.Entities;

public class CartProducts
{
    public int CartId { get; set; }
    public virtual Cart Cart { get; set; } = new();
    public int ProductId { get; set; }
    public virtual Product Product { get; set; } = new();
    public int Quantity { get; set; }
    public float TotalPrice { get; set; }
}