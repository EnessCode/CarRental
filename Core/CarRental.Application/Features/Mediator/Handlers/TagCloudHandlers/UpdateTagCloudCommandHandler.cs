using CarRental.Application.Common;
using CarRental.Application.Features.Mediator.Commands.TagCloudCommands;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.TagCloudHandlers
{
	public class UpdateTagCloudCommandHandler(IRepository<TagCloud> repository) : IRequestHandler<UpdateTagCloudCommand, UpdateTagCloudCommand>
	{
		public async Task<UpdateTagCloudCommand> Handle(UpdateTagCloudCommand request, CancellationToken cancellationToken)
		{
			var value = await repository.GetByIdAsync(request.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(TagCloud), request.Id);
			}

			value.Title = request.Title;
			value.BlogId = request.BlogId;

			await repository.UpdateAsync(value);
			return request;
		}
	}
}