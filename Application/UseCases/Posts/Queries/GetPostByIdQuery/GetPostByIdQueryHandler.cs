using Application.Abstractions.Repositories;
using Application.Dto;
using AutoMapper;
using MediatR;

namespace Application.UseCases.Posts.Queries.GetPostByIdQuery;

public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, PostDto?>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public GetPostByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<PostDto?> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
	{
		var post = await _unitOfWork.Posts.GetByIdAsync(request.Id);
		return _mapper.Map<PostDto>(post);
	}
}
