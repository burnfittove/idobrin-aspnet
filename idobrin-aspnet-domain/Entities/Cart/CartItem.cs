namespace aspnet_domain.Entities.Cart;

public class CartItem : Base
{
    public int CartId { get; set; }
    public virtual Cart Cart { get; set; } = new();
    public int ItemId { get; set; }
    public virtual Item Item { get; set; } = new();
}