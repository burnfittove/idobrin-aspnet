namespace aspnet_domain.Entities;

public class Country : Base
{
    public string? Name { get; set; }
    public IEnumerable<Municipality> Municipalities { get; } = new List<Municipality>();
}