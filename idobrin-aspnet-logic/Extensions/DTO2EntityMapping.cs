using aspnet_domain.Entities;
using idobrin_aspnet_logic.DTOs.Country;
using idobrin_aspnet_logic.DTOs.Municipality;

namespace idobrin_aspnet_logic.Extensions;

public static class DTO2EntityMapping
{
    #region Country

    public static CountryReturn Entity2Dto(this Country country)
    {
        return new CountryReturn(country.Id, country.Name);
    }

    public static IEnumerable<CountryReturn> EntityList2DtoList(this IEnumerable<Country> countries)
    {
        return countries.Select(country => country.Entity2Dto());
    }

    public static Country Dto2Entity(this CountryCreate country)
    {
        return new Country { Name = country.Name };
    }

    public static CountryReturnIncludeMunicipality Entity2DtoWithMunicipalities(this Country country)
    {
        return new CountryReturnIncludeMunicipality(country.Id, country.Name, country.Municipalities.EntityList2DtoList());
    }

    #endregion
    

    #region Municipality
    
    public static MunicipalityReturn Entity2Dto(this Municipality municipality)
    {
        return new MunicipalityReturn(municipality.Id, municipality.Name);
    }

    public static IEnumerable<MunicipalityReturn> EntityList2DtoList(this IEnumerable<Municipality> municipalities)
    {
        return municipalities.Select(e => e.Entity2Dto());
    }

    public static Municipality Dto2Entity(this MunicipalityCreate municipality)
    {
        return new Municipality { Name = municipality.Name, CountryId = municipality.CountryId };
    }

    public static MunicipalityReturnIncludeCountry Dto2EntityWithCountry(this Municipality municipality)
    {
        return new MunicipalityReturnIncludeCountry(municipality.Id, municipality.Name, municipality.Country?.Entity2Dto());
    }
    
    #endregion
}