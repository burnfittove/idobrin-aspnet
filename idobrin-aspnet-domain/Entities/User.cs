using aspnet_domain.Entities.Location;

namespace aspnet_domain.Entities;

public class User : Base
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string? PhoneNumber { get; set; }
    public string Email { get; set; } = "";
    public int AddressId { get; set; } = 0;
    public Address Address { get; set; } = new();
}