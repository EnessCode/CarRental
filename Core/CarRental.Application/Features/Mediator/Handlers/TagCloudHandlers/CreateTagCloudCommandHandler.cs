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
	public class CreateTagCloudCommandHandler(IRepository<TagCloud> repository) : IRequestHandler<CreateTagCloudCommand, CreateTagCloudCommand>
	{
		public async Task<CreateTagCloudCommand> Handle(CreateTagCloudCommand request, CancellationToken cancellationToken)
		{
			var tagCloud = new TagCloud
			{
				Title = request.Title,
				BlogId = request.BlogId
			};

			await repository.CreateAsync(tagCloud);
			return request;
		}
	}
}