using CodePulse.API.Models.Domain;

namespace CodePulse.API.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
        Task<IEnumerable<Category>>GetAllCategoryAsync();
        Task<Category?> GetCategoryByIdAsync(Guid id);

    }
}
