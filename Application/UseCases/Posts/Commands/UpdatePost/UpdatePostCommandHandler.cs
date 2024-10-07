using Application.Abstractions.Repositories;
using Application.Dto;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Posts.Commands.UpdatePost;

public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, UpdatePostDto>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public UpdatePostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}
	
	public async Task<UpdatePostDto> Handle(UpdatePostCommand command, CancellationToken cancellationToken)
	{
		var post = _mapper.Map<Post>(command);
		post.LastModified = DateTime.Now;
		var result = await _unitOfWork.Posts.UpdateAsync(post);
		await _unitOfWork.CompleteAsync();
		return _mapper.Map<UpdatePostDto>(result);
	}
}
