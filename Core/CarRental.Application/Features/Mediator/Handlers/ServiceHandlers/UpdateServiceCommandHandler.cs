using CarRental.Application.Common;
using CarRental.Application.Features.Mediator.Commands.ServiceCommands;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.ServiceHandlers
{
	public class UpdateServiceCommandHandler(IRepository<Service> serviceRepository) : IRequestHandler<UpdateServiceCommand, UpdateServiceCommand>
	{
		public async Task<UpdateServiceCommand> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
		{
			var value = await serviceRepository.GetByIdAsync(request.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(Service), request.Id);
			}

			value.Title = request.Title;
			value.Description = request.Description;
			value.IconUrl = request.IconUrl;

			await serviceRepository.UpdateAsync(value);
			return request;
		}
	}
}