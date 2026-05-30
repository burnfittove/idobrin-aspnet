namespace aspnet_domain.Interfaces;

public interface IUnitOfWork : IDisposable
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
    /// Category repository.
    /// </summary>
    ICategoryRepository CategoryRepository { get; }
    
    /// <summary>
    /// Product repository.
    /// </summary>
    IProductRepository ProductRepository { get; }
    
    /// <summary>
    /// CategoryProducts repository.
    /// </summary>
    ICategoryProductsRepository CategoryProductsRepository { get; }
    
    /// <summary>
    /// Cart repository.
    /// </summary>
    IUserRepository UserRepository { get; }
    
    /// <summary>
    /// Cart repository.
    /// </summary>
    ICartRepository CartRepository { get; }
    
    /// <summary>
    /// CartItems repository.
    /// </summary>
    ICartItemsRepository CartItemsRepository { get; }
    
    /// <summary>
    /// Items repository.
    /// </summary>
    IItemRepository ItemRepository { get; }
    
    // <summary>
    /// Items repository.
    /// </summary>
    IAddressRepository AddressRepository { get; }
    
    /// <summary>
    /// Saves all changes in the database. If one change fail, all others fail as well.
    /// </summary>
    /// <returns>int &#8212; The number of saved changes.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}