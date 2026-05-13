namespace aspnet_domain.Entities.Order;

public class OrderItem : Base
{
    public int OrderId { get; set; }
    public virtual Order Order { get; set; } = new();
    public int ItemId { get; set; } 
    public virtual Item Item { get; set; } = new();
}