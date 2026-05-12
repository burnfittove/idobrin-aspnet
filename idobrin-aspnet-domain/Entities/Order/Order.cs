namespace aspnet_domain.Entities.Order;

public class Order : Base
{
    public float TotalPrice { get; set; }
    public bool ReadyToDispatch { get; set; }
    public DateTime? DispatchedAt { get; set; }
    public DateTime? ArrivedAt { get; set; }
    public DateTime? ReturnedAt { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; } = new();
}