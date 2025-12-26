using CodePulse.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePulse.Application.Abstractions.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
        Task<IEnumerable<Category>> GetAllCategoryAsync();
        Task<Category?> GetCategoryByIdAsync(Guid id);
        Task<Category?> UpdateAsync(Guid id, Category category);
        Task<Category?> DeleteCategoryByIdAsync(Guid id);

    }
}
