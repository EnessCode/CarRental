using CarRental.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarRental.Application.Interfaces.CarFeatureInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
	public class UpdateCarFeatureAvailableCommandHandler(ICarFeatureRepository carFeatureRepository) : IRequestHandler<UpdateCarFeatureAvailableCommand, UpdateCarFeatureAvailableCommand>
	{
		public async Task<UpdateCarFeatureAvailableCommand> Handle(UpdateCarFeatureAvailableCommand request, CancellationToken cancellationToken)
		{
			await carFeatureRepository.ChangeCarFeatureAvailableStatus(request.CarId, request.FeatureId, request.Available); 
			return request;
		}
	}
}
