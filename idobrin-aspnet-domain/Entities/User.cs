using aspnet_domain.Entities.Location;
using aspnet_domain.Entities.Cart;
using aspnet_domain.Entities.Order;

namespace aspnet_domain.Entities;

public class User : Base
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string? PhoneNumber { get; set; }
    public string Email { get; set; } = "";
    public int AddressId { get; set; } = 0;
    public virtual Address Address { get; set; } = new();
    public virtual Wishlist? Wishlist { get; set; } = new();
    public virtual Cart.Cart Cart { get; set; } = new();
    public IEnumerable<UserOrder> UserOrders { get; set; } = new List<UserOrder>();
}