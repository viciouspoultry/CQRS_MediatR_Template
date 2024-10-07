using Application.Abstractions.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories
{
	public class CategoryRepository(DataContext context) : ICategoryRepository
	{
		public async Task<IEnumerable<Category>> GetAsync()
		{
			return await context.Categories.ToListAsync();
		}

		public async Task<Category?> GetByIdAsync(int id)
		{
			return await context.Categories.FindAsync(id);
		}
	}
}
