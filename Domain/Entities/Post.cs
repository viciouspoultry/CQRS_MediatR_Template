
namespace Domain.Entities;

public class Post
{
	public int Id { get; set; }

	public int CategoryId { get; set; }
	public Category? Category { get; set; }

	public string? Title { get; set; }
	public string? Content { get; set; }

	public DateTime Published { get; set; }
	public DateTime LastModified { get; set; }
}
