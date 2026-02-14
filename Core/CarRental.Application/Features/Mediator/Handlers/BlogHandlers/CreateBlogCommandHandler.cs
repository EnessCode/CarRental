using CarRental.Application.Features.Mediator.Commands.BlogCommands;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.BlogHandlers
{
	public class CreateBlogCommandHandler(IRepository<Blog> blogRepository) : IRequestHandler<CreateBlogCommand, CreateBlogCommand>
	{
		public async Task<CreateBlogCommand> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
		{
			var blog = new Blog
			{
				Title = request.Title,
				Description = request.Description,
				CoverImageUrl = request.CoverImageUrl,
				AuthorId = request.AuthorId,
				CategoryId = request.CategoryId,
				CreatedAt = DateTime.Now 
			};

			await blogRepository.CreateAsync(blog);

			return request;
		}
	}
}