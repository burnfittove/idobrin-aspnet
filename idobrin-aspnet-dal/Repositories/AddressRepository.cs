using aspnet_domain.Entities.Location;
using aspnet_domain.Interfaces;
using idobrin_aspnet_dal.Configs;

namespace idobrin_aspnet_dal.Repositories;

public class AddressRepository(DatabaseContext context) : BaseRepository<Address>(context), IAddressRepository
{
    
}