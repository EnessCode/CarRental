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
	public class UpdateAuthorCommandHandler(IRepository<Author> authorRepository) : IRequestHandler<UpdateAuthorCommand, UpdateAuthorCommand>
	{
		public async Task<UpdateAuthorCommand> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
		{
			var value = await authorRepository.GetByIdAsync(request.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(Author), request.Id);
			}

			value.Name = request.Name;
			value.ImageUrl = request.ImageUrl;
			value.Description = request.Description;

			await authorRepository.UpdateAsync(value);
			return request;
		}
	}
}