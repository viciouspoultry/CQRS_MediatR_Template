using Application.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
	private readonly DataContext _context;

	public IPostRepository Posts { get; private set; }
	public ICategoryRepository Categories { get; private set; }

	public UnitOfWork(IDbContextFactory<DataContext> dbFactory)
	{
		_context = dbFactory.CreateDbContext();
		Posts = new PostRepository(_context);
		Categories = new CategoryRepository(_context);
	}

	public void Dispose()
	{
		_context.Dispose();
	}

	public async Task<int> CompleteAsync()
	{
		return await _context.SaveChangesAsync();
	}
}
