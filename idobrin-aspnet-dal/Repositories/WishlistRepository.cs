using aspnet_domain.Entities;
using aspnet_domain.Interfaces;
using idobrin_aspnet_dal.Configs;

namespace idobrin_aspnet_dal.Repositories;

public class WishlistRepository(DatabaseContext context) : BaseRepository<Wishlist>(context), IWishlistRepository
{
    
}