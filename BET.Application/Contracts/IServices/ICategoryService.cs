
namespace BET.Application.Contracts.IServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoryAsync();
        Task<Category> GetByIdCategoryAsync(Guid id);
        Task<Guid> AddCategoryAsync(Category category);
        Task UpdateCategoryAsync(Guid id,Category category);
        Task DeleteCategoryAsync(Guid id);
    }
}
