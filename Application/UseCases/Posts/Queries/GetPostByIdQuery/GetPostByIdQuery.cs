using Application.Dto;
using MediatR;

namespace Application.UseCases.Posts.Queries.GetPostByIdQuery;

public class GetPostByIdQuery : IRequest<PostDto?>
{
	public int Id { get; set; }
}
