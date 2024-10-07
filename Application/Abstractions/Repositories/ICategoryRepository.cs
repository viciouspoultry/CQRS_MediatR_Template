using Domain.Entities;

namespace Application.Abstractions.Repositories
{
	public interface ICategoryRepository
	{
		Task<IEnumerable<Category>> GetAsync();
		Task<Category?> GetByIdAsync(int id);
	}
}
