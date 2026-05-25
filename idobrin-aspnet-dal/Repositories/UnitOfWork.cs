using aspnet_domain.Interfaces;
using idobrin_aspnet_dal.Configs;

namespace idobrin_aspnet_dal.Repositories;

public sealed class UnitOfWork(DatabaseContext context) : IUnitOfWork
{
    private ICountryRepository? _countryRepo;
    private IMunicipalityRepository? _municipalityRepo;
    private ICategoryRepository? _categoryRepo;
    private IProductRepository? _productRepo;
    private ICategoryProductsRepository? _categoryProductsRepo;
    private IUserRepository? _userRepo;
    private ICartRepository? _cartRepo;
    private ICartItemsRepository? _cartItemsRepo;
    private IItemRepository? _itemRepo;
    private bool disposed = false;
    
    public ICountryRepository CountryRepository => _countryRepo ??= new CountryRepository(context);
    public IMunicipalityRepository MunicipalityRepository => _municipalityRepo ??= new MunicipalityRepository(context);
    public ICategoryRepository CategoryRepository => _categoryRepo ??= new CategoryRepository(context);
    public IProductRepository ProductRepository => _productRepo ??= new ProductRepository(context);
    public ICategoryProductsRepository CategoryProductsRepository =>  _categoryProductsRepo ??= new CategoryProductsRepository(context);
    public IUserRepository UserRepository => _userRepo ??= new UserRepository(context);
    public ICartRepository CartRepository =>  _cartRepo ??= new CartRepository(context);
    public ICartItemsRepository CartItemsRepository => _cartItemsRepo ??= new CartItemsRepository(context);
    public IItemRepository ItemRepository => _itemRepo ??= new ItemRepository(context);

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        InvokeDispose();
        GC.SuppressFinalize(this);
    }

    private void InvokeDispose()
    {
        // Return if dispose has already been called
        if (disposed) return;
        
        // Dispose DbContext
        context.Dispose();

        // Note that Dispose has been completed
        disposed = true;
    }
}