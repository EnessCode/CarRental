using CarRental.Application.Common;
using CarRental.Application.Features.Mediator.Commands.AuthorCommands;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.AuthorHandlers
{
	public class RemoveAuthorCommandHandler(IRepository<Author> authorRepository) : IRequestHandler<RemoveAuthorCommand, RemoveAuthorCommand>
	{
		public async Task<RemoveAuthorCommand> Handle(RemoveAuthorCommand request, CancellationToken cancellationToken)
		{
			var value = await authorRepository.GetByIdAsync(request.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(Author), request.Id);
			}

			await authorRepository.RemoveAsync(value);
			return request;
		}
	}
}