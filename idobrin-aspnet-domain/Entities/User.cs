namespace aspnet_domain.Entities;

public class User : Base
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string? PhoneNumber { get; set; }
    public string Email { get; set; } = "";
    public virtual Cart? Cart { get; } = new Cart();
    public virtual Address? Address { get; } = new Address();
}