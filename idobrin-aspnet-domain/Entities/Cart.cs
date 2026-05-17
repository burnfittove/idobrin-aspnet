namespace aspnet_domain.Entities;

public class Cart : Base
{
    public int? UserId { get; set; }
    public decimal TotalPrice { get; set; }
    public virtual User? User { get; set; } = new();
    public virtual ICollection<CartItem>? CartItem { get; set; }
}