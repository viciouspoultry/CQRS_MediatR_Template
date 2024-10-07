using Application.UseCases.Posts.Commands.CreatePost;
using Application.UseCases.Posts.Commands.DeletePost;
using Application.UseCases.Posts.Commands.UpdatePost;
using Application.UseCases.Posts.Queries.GetPostByIdQuery;
using Application.UseCases.Posts.Queries.GetPostsQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostsController(IMediator mediator) : ControllerBase
{
	[HttpGet]
	public async Task<IActionResult> GetPosts()
	{
		try
		{
			var response = await mediator.Send(new GetPostsQuery());

			return Ok(response);
		}
		catch (Exception ex)
		{
			return StatusCode(StatusCodes.Status500InternalServerError,
				"Error retrieving data from the database: " + ex.Message);
		}
	}

	[HttpGet("{id:int}")]
	public async Task<IActionResult> GetPostById(int id)
	{
		try
		{
			var response = await mediator.Send(new GetPostByIdQuery() { Id = id });

			if (response is null) return NotFound();

			return Ok(response);
		}
		catch (Exception ex)
		{
			return StatusCode(StatusCodes.Status500InternalServerError,
				$"Error retrieving data from the database: {ex.Message}");
		}
	}

	[HttpPost]
	public async Task<IActionResult> InsertPost(CreatePostCommand command)
	{
		try
		{
			if (command is null) return BadRequest();

			var response = await mediator.Send(command);

			return CreatedAtAction(nameof(GetPostById), new { id = response.Id }, response);
		}
		catch (Exception ex)
		{
			return StatusCode(StatusCodes.Status500InternalServerError,
				$"Error creating new data: {ex.Message}");
		}
	}

	[HttpPut]
	public async Task<IActionResult> UpdatePost(UpdatePostCommand command)
	{
		try
		{
			if (command is null) return BadRequest();

			var response = await mediator.Send(command);

			if (response is null) return NotFound($"Post with id: {command.Id} not found.");

			return Ok(response);
		}
		catch (Exception ex)
		{
			return StatusCode(StatusCodes.Status500InternalServerError,
				$"Error updating data: {ex.Message}");
		}
	}

	[HttpDelete("{id:int}")]
	public async Task<IActionResult> DeletePost(int id)
	{
		try
		{
			var response = await mediator.Send(new DeletePostCommand() { Id = id });
			
			if (response is null) return NotFound($"Post with id: {id} not found.");

			return NoContent();
		}
		catch (Exception ex)
		{
			return StatusCode(StatusCodes.Status500InternalServerError,
				$"Error deleting data: {ex.Message}");
		}
	}
}
