using aspnet_domain.Entities.Products;

namespace aspnet_domain.Entities;

public class Wishlist : Base
{
    public int UserId { get; set; }
    public virtual User User { get; set; } = new();
    public int ProductId { get; set; }
    public virtual Product Product { get; set; } = new();
}