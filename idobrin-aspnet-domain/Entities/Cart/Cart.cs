namespace aspnet_domain.Entities.Cart;

public class Cart : Base
{
    public float TotalPrice { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; } = new(); // Navigational property
    public virtual IEnumerable<CartItem> CartItems { get; set; } = new List<CartItem>();    // Navigational property
}