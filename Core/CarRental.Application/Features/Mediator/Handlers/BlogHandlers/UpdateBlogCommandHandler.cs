using CarRental.Application.Common;
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
	public class UpdateBlogCommandHandler(IRepository<Blog> blogRepository) : IRequestHandler<UpdateBlogCommand, UpdateBlogCommand>
	{
		public async Task<UpdateBlogCommand> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
		{
			var value = await blogRepository.GetByIdAsync(request.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(Blog), request.Id);
			}

			value.Title = request.Title;
			value.Description = request.Description;
			value.CoverImageUrl = request.CoverImageUrl;
			value.AuthorId = request.AuthorId;
			value.CategoryId = request.CategoryId;

			await blogRepository.UpdateAsync(value);
			return request;
		}
	}
}