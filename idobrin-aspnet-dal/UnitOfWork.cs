using aspnet_domain.Interfaces;

namespace idobrin_aspnet_dal;

public class UnitOfWork : IUnitOfWork
{
    public ICountryRepository CountryRepository { get; }
    public IMunicipalityRepository MunicipalityRepository { get; }
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}