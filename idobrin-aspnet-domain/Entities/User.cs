namespace aspnet_domain.Entities;

public class User : Base
{
    public string Username { get; set; }
    public string PwdHash { get; set; }
    public string PwdSalt { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; } = "";
    public int? RoleId { get; set; }
    public virtual Cart? Cart { get; set; }
    public virtual Wishlist? Wishlist { get; set; }
    public virtual Address? Address { get; set; }
    public virtual Role? Role { get; set; }
}