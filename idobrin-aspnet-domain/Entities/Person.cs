namespace aspnet_domain.Entities;

public class Person : Base
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public int? MunicipalityId { get; set; }
    public Municipality? Municipality { get; set; }
}