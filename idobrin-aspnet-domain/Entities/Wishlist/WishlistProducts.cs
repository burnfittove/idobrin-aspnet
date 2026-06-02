namespace aspnet_domain.Entities;

public class WishlistProducts
{
    public int WishlistId { get; set; }
    public virtual Wishlist Wishlist { get; set; }
    public int ProductId { get; set; }
    public virtual Product Product { get; set; }
}