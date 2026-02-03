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
	public class CreateFeatureCommandHandler(IRepository<Feature> featureRepository) : IRequestHandler<CreateFeatureCommand, CreateFeatureCommand>
	{
		public async Task<CreateFeatureCommand> Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
		{
			var feature = new Feature
			{
				Name = request.Name
			};

			await featureRepository.CreateAsync(feature);

			return request;
		}
	}
}
