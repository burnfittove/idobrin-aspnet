namespace aspnet_domain.Entities;

public class CartItem
{
    public int? CartId { get; set; }
    public virtual Cart? Cart { get; set; }
    public int? ItemId { get; set; }
    public virtual Item? Item { get; set; }
}