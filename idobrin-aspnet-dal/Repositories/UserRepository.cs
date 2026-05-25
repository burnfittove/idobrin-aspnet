using aspnet_domain.Entities;
using aspnet_domain.Interfaces;
using idobrin_aspnet_dal.Configs;
using Microsoft.EntityFrameworkCore;

namespace idobrin_aspnet_dal.Repositories;

public class UserRepository(DatabaseContext context) : BaseRepository<User>(context), IUserRepository
{
    public async Task<User> ReturnUserWithCartById(int id, CancellationToken cancellationToken)
    {
        return await DbSet
            .Include(e => e.Cart)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }
}