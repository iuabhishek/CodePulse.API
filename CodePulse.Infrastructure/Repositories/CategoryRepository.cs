using CodePulse.Application.Abstractions.Repositories;
using CodePulse.Domain.Entities;
using CodePulse.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePulse.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CategoryRepository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<Category> CreateAsync(Category category)
        {
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category?> DeleteCategoryByIdAsync(Guid id)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category is not null)
            {
                _dbContext.Categories.Remove(category);
                await _dbContext.SaveChangesAsync();
                return category;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(Guid id)
        {

            return await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Category?> UpdateAsync(Guid id, Category category)
        {
            var response = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (response is not null)
            {
                _dbContext.Entry(response).CurrentValues.SetValues(category);
                await _dbContext.SaveChangesAsync();
                return category;
            }
            return null;
        }
    }
}
