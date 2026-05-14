using aspnet_domain.Entities;
using aspnet_domain.Interfaces;
using idobrin_aspnet_dal.Configs;

namespace idobrin_aspnet_dal.Repositories;

public class CategoryRepository(DatabaseContext context) : BaseRepository<Category>(context), ICategoryRepository
{
    
}