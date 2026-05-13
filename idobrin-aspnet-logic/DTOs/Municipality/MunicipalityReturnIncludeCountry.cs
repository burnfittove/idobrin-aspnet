using idobrin_aspnet_logic.DTOs.Country;

namespace idobrin_aspnet_logic.DTOs.Municipality;

public record MunicipalityReturnIncludeCountry(int Id, string Name, CountryReturn Country);