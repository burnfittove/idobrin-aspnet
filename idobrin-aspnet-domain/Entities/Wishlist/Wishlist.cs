namespace aspnet_domain.Entities;

public class Wishlist : Base
{
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public virtual IEnumerable<WishlistProducts?> WishlistProducts { get; set; }
}