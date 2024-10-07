using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts;

public class DataContext(DbContextOptions options) : DbContext(options)
{
	public DbSet<Post> Posts { get; set; }
	public DbSet<Category> Categories { get; set; }
}
