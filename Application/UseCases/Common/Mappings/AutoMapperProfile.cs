using Application.Dto;
using Application.UseCases.Posts.Commands.CreatePost;
using Application.UseCases.Posts.Commands.UpdatePost;
using AutoMapper;
using Domain.Entities;

namespace Application.UseCases.Common.Mappings;

public class AutoMapperProfile : Profile
{
	public AutoMapperProfile()
	{
		CreateMap<Post, PostDto>()
			.ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category!.Name));
		CreateMap<Post, CreatePostDto>();
		CreateMap<Post, UpdatePostDto>();
		CreateMap<CreatePostCommand, Post>();
		CreateMap<UpdatePostCommand, Post>();
	}
}
