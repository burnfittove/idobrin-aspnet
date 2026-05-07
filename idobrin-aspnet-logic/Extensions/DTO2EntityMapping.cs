using aspnet_domain.Entities;
using idobrin_aspnet_logic.DTOs.Country;
using idobrin_aspnet_logic.DTOs.Municipality;

namespace idobrin_aspnet_logic.Extensions;

public static class DTO2EntityMapping
{
    public static CountryReturn Entity2Dto(this Country country)
    {
        return new CountryReturn(country.Id, country.Name, country.Municipalities.EntityList2DtoList());
    }

    public static IEnumerable<CountryReturn> EntityList2DtoList(this IEnumerable<Country> countries)
    {
        return countries.Select(country => country.Entity2Dto());
    }

    public static Country Dto2Entity(this CountryCreate country)
    {
        return new Country { Name = country.Name };
    }

    public static MunicipalityReturn Entity2Dto(this Municipality municipality)
    {
        return new MunicipalityReturn(municipality.Id, municipality.Name, municipality.CountryId);
    }

    public static IEnumerable<MunicipalityReturn> EntityList2DtoList(this IEnumerable<Municipality> municipalities)
    {
        return municipalities.Select(e => e.Entity2Dto());
    }

    public static Municipality Dto2Entity(this MunicipalityCreate municipality)
    {
        return new Municipality { Name = municipality.Name, CountryId = municipality.CountryId };
    }
}