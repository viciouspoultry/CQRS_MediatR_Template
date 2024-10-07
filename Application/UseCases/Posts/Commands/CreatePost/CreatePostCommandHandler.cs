using Application.Abstractions.Repositories;
using Application.Dto;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Posts.Commands.CreatePost;

public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, CreatePostDto>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public CreatePostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}
	public async Task<CreatePostDto> Handle(CreatePostCommand command, CancellationToken cancellationToken)
	{
		var post = _mapper.Map<Post>(command);
		post.Published = DateTime.Now;
		post.LastModified = DateTime.Now;
		var result = await _unitOfWork.Posts.CreateAsync(post);
		await _unitOfWork.CompleteAsync();
		return _mapper.Map<CreatePostDto>(result);
	}
}
