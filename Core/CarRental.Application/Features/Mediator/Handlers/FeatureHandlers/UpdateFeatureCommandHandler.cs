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
	public class UpdateFeatureCommandHandler(IRepository<Feature> featureRepository) : IRequestHandler<UpdateFeatureCommand, UpdateFeatureCommand>
	{
		public async Task<UpdateFeatureCommand> Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
		{
			var value = await featureRepository.GetByIdAsync(request.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(Feature), request.Id);
			}

			value.Name = request.Name;

			await featureRepository.UpdateAsync(value);
			return request;
		}
	}
}
