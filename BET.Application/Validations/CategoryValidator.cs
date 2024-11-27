
namespace BET.Application.Validations
{
    public class CategoryValidator : ICategoryValidator
    {
        public void ValidateEntity(Category category)
        {
            Guard.IsNotNullOrWhiteSpace(category.Name, nameof(category.Name));  
        }
    }
}
