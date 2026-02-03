using CarRental.Application.Features.Mediator.Commands.LocationCommands;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.LocationHandlers
{
	public class CreateLocationCommandHandler(IRepository<Location> repository) : IRequestHandler<CreateLocationCommand, CreateLocationCommand>
	{
		public async Task<CreateLocationCommand> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
		{
			var location = new Location
			{
				Name = request.Name
			};

			await repository.CreateAsync(location);

			return request;
		}
	}
}