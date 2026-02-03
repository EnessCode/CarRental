using CarRental.Application.Common;
using CarRental.Application.Features.Mediator.Commands.FeatureCommands;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.FeatureHandlers
{
	public class RemoveFeatureCommandHandler(IRepository<Feature> featureRepository) : IRequestHandler<RemoveFeatureCommand, RemoveFeatureCommand>
	{
		public async Task<RemoveFeatureCommand> Handle(RemoveFeatureCommand request, CancellationToken cancellationToken)
		{
			var value = await featureRepository.GetByIdAsync(request.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(Feature), request.Id);
			}

			await featureRepository.RemoveAsync(value);
			return request;
		}
	}
}
