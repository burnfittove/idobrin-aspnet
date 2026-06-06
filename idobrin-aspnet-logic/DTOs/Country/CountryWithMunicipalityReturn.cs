using idobrin_aspnet_logic.DTOs.Municipality;

namespace idobrin_aspnet_logic.DTOs.Country;

public record CountryWithMunicipalityReturn(int Id, string Name, IEnumerable<MunicipalityReturn> Municipalities);