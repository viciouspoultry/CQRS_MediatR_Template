using Domain.Entities;

namespace Application.Abstractions.Repositories;

public interface IPostRepository
{
	/* QUERIES */

	Task<IEnumerable<Post>> GetAsync();

	Task<Post?> GetByIdAsync(int id);


	/* COMMANDS */

	Task<Post> CreateAsync(Post newPost);

	Task<Post?> UpdateAsync(Post updatedPost);

	Task<Post?> DeleteAsync(int id);
}
