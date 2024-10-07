using Application.Dto;
using MediatR;

namespace Application.UseCases.Posts.Commands.CreatePost;

public class CreatePostCommand : IRequest<CreatePostDto>
{
	public string Title { get; set; }
	public string Content { get; set; }
	public int CategoryId { get; set; }
}
