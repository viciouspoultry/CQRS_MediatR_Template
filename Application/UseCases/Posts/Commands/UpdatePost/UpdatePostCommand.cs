using Application.Dto;
using MediatR;

namespace Application.UseCases.Posts.Commands.UpdatePost;

public class UpdatePostCommand : IRequest<UpdatePostDto>
{
	public int Id { get; set; }
	public string Title { get; set; }
	public string Content { get; set; }
	public int CategoryId { get; set; }
}
