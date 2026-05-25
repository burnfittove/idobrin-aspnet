namespace aspnet_domain.Entities;

public class Cart : Base
{
    public int? UserId { get; set; }
    public virtual User? User { get; set; } = new();
    public decimal TotalPrice { get; set; }
    public virtual ICollection<CartItem>? CartItems { get; set; }
}