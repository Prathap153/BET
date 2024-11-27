
namespace BET.Persistance.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DataContext context) : base(context) { }

        public async Task<Guid> AddCategoryAsync(Category category)
        {
            await AddAsync(category);
            return category.Id;
        }

        public async Task DeleteCategoryAsync(Guid id)
        {
            await DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
           return await GetAllAsync();
        }

        public async Task<Category> GetByIdCategoryAsync(Guid id)
        {
            return await GetByIdAsync(id);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            await UpdateAsync(category);
        }
    }
}
