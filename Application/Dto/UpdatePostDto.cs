
namespace Application.Dto;

public class UpdatePostDto
{
	public int Id { get; set; }

	public int CategoryId { get; set; }

	public string? Title { get; set; }
	public string? Content { get; set; }

	public DateTime Published { get; set; }
	public DateTime LastModified { get; set; }
}