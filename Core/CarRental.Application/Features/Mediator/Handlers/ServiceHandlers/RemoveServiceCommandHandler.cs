using CarRental.Application.Common;
using CarRental.Application.Features.Mediator.Commands.ServiceCommands;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.ServiceHandlers
{
	public class RemoveServiceCommandHandler(IRepository<Service> serviceRepository) : IRequestHandler<RemoveServiceCommand, RemoveServiceCommand>
	{
		public async Task<RemoveServiceCommand> Handle(RemoveServiceCommand request, CancellationToken cancellationToken)
		{
			var value = await serviceRepository.GetByIdAsync(request.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(Service), request.Id);
			}

			await serviceRepository.RemoveAsync(value);
			return request;
		}
	}
}