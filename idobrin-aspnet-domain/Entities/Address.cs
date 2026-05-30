namespace aspnet_domain.Entities;

public class Address : Base
{
    public string AddressLine { get; set; }
    public string PostalCode { get; set; }
    public int MunicipalityId { get; set; }
    public virtual Municipality Municipality { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; }
}