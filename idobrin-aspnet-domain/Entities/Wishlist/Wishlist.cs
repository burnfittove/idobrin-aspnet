namespace aspnet_domain.Entities;

public class Wishlist
{
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public virtual IEnumerable<Product> Products { get; set; }
}