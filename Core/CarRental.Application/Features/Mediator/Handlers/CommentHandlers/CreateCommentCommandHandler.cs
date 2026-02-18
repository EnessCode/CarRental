using CarRental.Application.Features.Mediator.Commands.CommentCommands;
using CarRental.Application.Interfaces.CommentInterfaces;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.CommentHandlers
{
	public class CreateCommentCommandHandler(ICommentRepository repository) : IRequestHandler<CreateCommentCommand>
	{
		public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
		{
			await repository.CreateAsync(new Comment
			{
				Name = request.Name,
				Description = request.Description,
				CreatedDate = DateTime.Now,
				BlogId = request.BlogId
			});
		}
	}
}
