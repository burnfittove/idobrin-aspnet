using aspnet_domain.Interfaces;
using idobrin_aspnet_dal.Configs;

namespace idobrin_aspnet_dal.Repositories;

public class UnitOfWork(DatabaseContext context) : IUnitOfWork
{
    private ICountryRepository? _countryRepo;
    private IMunicipalityRepository? _municipalityRepo;
    private ICategoryRepository? _categoryRepo;
    private IProductRepository? _productRepo;
    private bool disposed = false;
    
    public ICountryRepository CountryRepository => _countryRepo ??= new CountryRepository(context);
    public IMunicipalityRepository MunicipalityRepository => _municipalityRepo ??= new MunicipalityRepository(context);
    public ICategoryRepository CategoryRepository => _categoryRepo ??= new CategoryRepository(context);
    public IProductRepository ProductRepository => _productRepo ??= new ProductRepository(context);

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await context.SaveChangesAsync(cancellationToken);
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
        context.Dispose();

        // Note that Dispose has been completed
        disposed = true;
    }
}