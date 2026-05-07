namespace aspnet_domain.Entities;

public class Municipality : Base
{
    public string? Name { get; set; }
    public int CountryId { get; set; }
    public Country? Country { get; set; }
    public IEnumerable<Person>? Persons { get; set; }
}