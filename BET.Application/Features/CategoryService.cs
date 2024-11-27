
using BET.Application.Contracts.IRepositories;

namespace BET.Application.Features
{
    public class CategoryService:ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryValidator _categoryValidator;
        public CategoryService(ICategoryRepository categoryRepository, ICategoryValidator categoryValidator)
        {
            _categoryRepository = categoryRepository;
            _categoryValidator = categoryValidator;
        }

        public async Task<Guid> AddCategoryAsync(Category category)
        {
            _categoryValidator.ValidateEntity(category);
           return await _categoryRepository.AddCategoryAsync(category);
        }

        public async Task DeleteCategoryAsync(Guid id)
        {
            await _categoryRepository.DeleteCategoryAsync(id);
        }

        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            return await _categoryRepository.GetAllCategoryAsync();
        }

        public async Task<Category> GetByIdCategoryAsync(Guid id)
        {
            return await _categoryRepository.GetByIdCategoryAsync(id);
        }

        public async Task UpdateCategoryAsync(Guid id, Category category)
        {
            var getByCategory = await _categoryRepository.GetByIdCategoryAsync(id);
            if (getByCategory != null)
            {
                getByCategory.Name = category.Name;
                getByCategory.Description = category.Description;
                getByCategory.IsActive = category.IsActive;
                getByCategory.ModifiedOn = DateTime.Now;
                getByCategory.ModifiedBy = "User1";
                await _categoryRepository.UpdateCategoryAsync(getByCategory);
            }
        }
    }
}
