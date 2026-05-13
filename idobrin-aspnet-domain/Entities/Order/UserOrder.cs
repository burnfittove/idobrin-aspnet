namespace aspnet_domain.Entities.Order;

public class UserOrder : Base
{
    public int UserId { get; set; }
    public virtual User User { get; set; } = new();
    public int OrderId { get; set; }
    public virtual Order Order { get; set; } = new();
}