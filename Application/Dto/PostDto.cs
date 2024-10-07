
namespace Application.Dto;

public class PostDto
{
	public int Id { get; set; }

	public string? Category { get; set; }

	public string? Title { get; set; }
	public string? Content { get; set; }

	public DateTime Published { get; set; }
	public DateTime LastModified { get; set; }
}