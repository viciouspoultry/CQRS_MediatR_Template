using Application.Dto;
using MediatR;

namespace Application.UseCases.Posts.Commands.DeletePost;

public class DeletePostCommand : IRequest<PostDto>
{
	public int Id { get; set; }
}
