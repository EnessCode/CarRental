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
	public class RemoveBlogCommandHandler(IRepository<Blog> blogRepository) : IRequestHandler<RemoveBlogCommand, RemoveBlogCommand>
	{
		public async Task<RemoveBlogCommand> Handle(RemoveBlogCommand request, CancellationToken cancellationToken)
		{
			var value = await blogRepository.GetByIdAsync(request.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(Blog), request.Id);
			}

			await blogRepository.RemoveAsync(value);
			return request;
		}
	}
}