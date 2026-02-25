using CarRental.Application.Common;
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
	public class RemoveCommentCommandHandler(ICommentRepository repository) : IRequestHandler<RemoveCommentCommand, RemoveCommentCommand>
	{
		public async Task<RemoveCommentCommand> Handle(RemoveCommentCommand request, CancellationToken cancellationToken)
		{
			var value = await repository.GetByIdAsync(request.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(Blog), request.Id);
			}

			await repository.RemoveAsync(value);
			return request;
		}
	}
}
