using Application.Abstractions.Repositories;
using Application.Dto;
using AutoMapper;
using MediatR;

namespace Application.UseCases.Posts.Queries.GetPostsQuery;

public class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, IEnumerable<PostDto>>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

    public GetPostsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
		_unitOfWork = unitOfWork;
		_mapper = mapper;
    }

    public async Task<IEnumerable<PostDto>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
	{
		var posts = await _unitOfWork.Posts.GetAsync();
		return _mapper.Map<IEnumerable<PostDto>>(posts);
	}
}
