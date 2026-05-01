namespace aspnet_domain.Interfaces;

public interface IUnitOfWork
{
    /// <summary>
    /// Country repository.
    /// </summary>
    ICountryRepository CountryRepository { get; }
    
    /// <summary>
    /// Municipality repository.
    /// </summary>
    IMunicipalityRepository MunicipalityRepository { get; }
    
    /// <summary>
    /// Saves all changes in the database. If one change fail, all others fail as well.
    /// </summary>
    /// <returns>int &#8212; The number of saved changes.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}