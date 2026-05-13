namespace aspnet_domain.Entities.Location;

public class Address : Base
{
    public string StreetName { get; set; } = "";
    public int HouseNumber { get; set; }
    public int MunicipalityId { get; set; }
    public virtual Municipality Municipality { get; set; } = new();
}