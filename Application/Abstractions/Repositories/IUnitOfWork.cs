
namespace Application.Abstractions.Repositories;

public interface IUnitOfWork
{
	IPostRepository Posts { get; }
	ICategoryRepository Categories { get; }

	Task<int> CompleteAsync();
}
