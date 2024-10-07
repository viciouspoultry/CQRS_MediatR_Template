using Application.Abstractions.Repositories;
using Application.Dto;
using AutoMapper;
using MediatR;

namespace Application.UseCases.Posts.Commands.DeletePost;

public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, PostDto>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public DeletePostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<PostDto> Handle(DeletePostCommand command, CancellationToken cancellationToken)
	{
		var result =  await _unitOfWork.Posts.DeleteAsync(command.Id);
		await _unitOfWork.CompleteAsync();
		return _mapper.Map<PostDto>(result);
	}
}
