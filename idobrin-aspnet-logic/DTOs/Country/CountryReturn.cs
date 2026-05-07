using idobrin_aspnet_logic.DTOs.Municipality;

namespace idobrin_aspnet_logic.DTOs.Country;

public record CountryReturn(int Id, string Name, IEnumerable<MunicipalityReturn> Municipalities);