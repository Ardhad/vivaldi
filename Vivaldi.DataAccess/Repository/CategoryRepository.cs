using Vivaldi.Api.DataAccess;
using Vivaldi.Api.Model;

namespace Vivaldi.DataAccess.Repository
{
    public class CategoryRepository  : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(VivaldiDbContext dbContext) : base(dbContext)
        {
        }
    }
}