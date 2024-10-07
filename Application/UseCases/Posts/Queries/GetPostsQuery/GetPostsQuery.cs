using Application.Dto;
using MediatR;

namespace Application.UseCases.Posts.Queries.GetPostsQuery;

public class GetPostsQuery : IRequest<IEnumerable<PostDto>>
{
}
