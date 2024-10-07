using Application.Abstractions.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class PostRepository(DataContext context) : IPostRepository
{
	/* QUERIES */

	public async Task<IEnumerable<Post>> GetAsync()
	{
		return await context.Posts
			.Include(p => p.Category)
			.ToListAsync();
	}

	public async Task<Post?> GetByIdAsync(int id)
	{
		return await context.Posts
			.Include(p => p.Category)
			.FirstOrDefaultAsync(p => p.Id == id);
	}


	/* COMMANDS */

	public async Task<Post> CreateAsync(Post newPost)
	{
		var result = await context.Posts.AddAsync(newPost);
		return result.Entity;
	}

	public async Task<Post?> UpdateAsync(Post updatedPost)
	{
		Post? toUpdate = await context.Posts.FindAsync(updatedPost.Id);

		if (toUpdate is not null)
		{
			toUpdate.Title = updatedPost.Title;
			toUpdate.Content = updatedPost.Content;
			toUpdate.CategoryId = updatedPost.CategoryId;
			toUpdate.LastModified = updatedPost.LastModified;
			return toUpdate;
		}

		return null;
	}

	public async Task<Post?> DeleteAsync(int id)
	{
		Post? toDelete = await context.Posts.FindAsync(id);

		if (toDelete is not null)
		{
			context.Posts.Remove(toDelete);
			return toDelete;
		}

		return null;
	}
}
