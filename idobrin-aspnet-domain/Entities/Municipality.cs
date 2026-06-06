namespace aspnet_domain.Entities;

public class Municipality : Base
{
    public string? Name { get; set; }
    public int CountryId { get; set; }
    public virtual Country? Country { get; set; }
    public virtual ICollection<Address?> Addresses { get; set; }
}