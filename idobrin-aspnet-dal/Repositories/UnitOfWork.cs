using aspnet_domain.Interfaces;
using idobrin_aspnet_dal.Configs;

namespace idobrin_aspnet_dal.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly DatabaseContext _context;
    private ICountryRepository? _countryRepo;
    private IMunicipalityRepository? _municipalityRepo;
    // private IPersonRepository? _personRepo;
    private bool disposed = false;
    
    public ICountryRepository CountryRepository => _countryRepo ??= new CountryRepository(_context);
    public IMunicipalityRepository MunicipalityRepository => _municipalityRepo ??= new MunicipalityRepository(_context);

    private UnitOfWork(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        InvokeDispose();
        GC.SuppressFinalize(this);
    }

    protected virtual void InvokeDispose()
    {
        // Return if dispose has already been called
        if (disposed) return;
        
        // Dispose DbContext
        _context.Dispose();

        // Note that Dispose has been completed
        disposed = true;
    }
}