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
	public class CreateAuthorCommandHandler(IRepository<Author> authorRepository) : IRequestHandler<CreateAuthorCommand, CreateAuthorCommand>
	{
		public async Task<CreateAuthorCommand> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
		{
			var author = new Author
			{
				Name = request.Name,
				ImageUrl = request.ImageUrl,
				Description = request.Description
			};

			await authorRepository.CreateAsync(author);

			return request;
		}
	}
}
