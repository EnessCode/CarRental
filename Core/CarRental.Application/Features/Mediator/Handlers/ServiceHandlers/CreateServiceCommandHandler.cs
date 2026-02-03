using CarRental.Application.Features.Mediator.Commands.ServiceCommands;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.ServiceHandlers
{
	public class CreateServiceCommandHandler(IRepository<Service> serviceRepository) : IRequestHandler<CreateServiceCommand, CreateServiceCommand>
	{
		public async Task<CreateServiceCommand> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
		{
			var service = new Service
			{
				Title = request.Title,
				Description = request.Description,
				IconUrl = request.IconUrl
			};

			await serviceRepository.CreateAsync(service);
			return request;
		}
	}
}