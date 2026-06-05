namespace idobrin_aspnet_logic.DTOs.Address;

public record AddressCreate(string AddressLine, string PostalCode, int MunicipalityId, int UserId);