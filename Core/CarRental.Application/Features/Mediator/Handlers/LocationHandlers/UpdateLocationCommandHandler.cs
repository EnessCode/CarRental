using CarRental.Application.Common;
using CarRental.Application.Features.Mediator.Commands.LocationCommands;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.LocationHandlers
{
	public class UpdateLocationCommandHandler(IRepository<Location> repository) : IRequestHandler<UpdateLocationCommand, UpdateLocationCommand>
	{
		public async Task<UpdateLocationCommand> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
		{
			var value = await repository.GetByIdAsync(request.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(Location), request.Id);
			}

			value.Name = request.Name;

			await repository.UpdateAsync(value);
			return request;
		}
	}
}