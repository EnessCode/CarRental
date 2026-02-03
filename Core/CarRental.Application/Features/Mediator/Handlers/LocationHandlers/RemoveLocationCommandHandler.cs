using CarRental.Application.Common;
using CarRental.Application.Features.Mediator.Commands.LocationCommands;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.LocationHandlers
{
	public class RemoveLocationCommandHandler(IRepository<Location> repository) : IRequestHandler<RemoveLocationCommand, RemoveLocationCommand>
	{
		public async Task<RemoveLocationCommand> Handle(RemoveLocationCommand request, CancellationToken cancellationToken)
		{
			var value = await repository.GetByIdAsync(request.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(Location), request.Id);
			}

			await repository.RemoveAsync(value);
			return request;
		}
	}
}